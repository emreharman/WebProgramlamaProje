using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HayvanBarinagiCalisma.Models;
using HayvanBarinagiCalisma.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

namespace HayvanBarinagiCalisma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,IStringLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _context = context;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Hakkimizda()
        {
            //ViewData["BizKimiz"] = _localizer.GetString("BizKimiz");
            return View();
        }
        public IActionResult Iletisim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Iletisim(Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                iletisim.Tarih = DateTime.Now;
                _context.Iletisim.Add(iletisim);
                _context.SaveChanges();
                return RedirectToAction("Iletisim");
            }
            
            return View();
        }
        public IActionResult Sahiplenme()
        {
            var viewModel = new HayvanlarTurCinsViewModel();
            viewModel.Hayvanlar = _context.Hayvan.Where(x=>x.SahiplenildiMi==false).ToList();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            return View(viewModel);
        }
        [Authorize(Roles ="Admin,Uye")]
        public IActionResult SahiplenmeDetay(int id)
        {
            var hayvan = _context.Hayvan.Find(id);
            var tur = _context.Tur.Where(x => x.TurId == hayvan.TurId).FirstOrDefault();
            ViewBag.Turu = tur.TurAdi;
            var cins = _context.Cins.Where(x => x.CinsId == hayvan.CinsId).FirstOrDefault();
            ViewBag.Cinsi = cins.CinsAdi;
            return View(hayvan);
        }
        [Authorize(Roles = "Admin,Uye")]
        public IActionResult SahiplenmeGercekleme(int id)
        {
            var hayvan = _context.Hayvan.Find(id);
            hayvan.SahiplenildiMi = true;
            _context.Hayvan.Update(hayvan);
            _context.SaveChanges();
            return View(hayvan);
        }
        public IActionResult TurDetay(int id) {
            var viewModel = new HayvanlarTurCinsViewModel();
            viewModel.Hayvanlar = _context.Hayvan.Where(x => x.SahiplenildiMi == false && x.TurId==id).ToList();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            return View(viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
