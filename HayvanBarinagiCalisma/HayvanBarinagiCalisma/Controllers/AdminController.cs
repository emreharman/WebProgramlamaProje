using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HayvanBarinagiCalisma.Data;
using HayvanBarinagiCalisma.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Headers;
using System.IO;

namespace HayvanBarinagiCalisma.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
           return View(_context.Iletisim.ToList());
        }
        public IActionResult HayvanEkle()
        {
            var viewModel = new HayvanTurCinsViewModel();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult HayvanEkle(Hayvan hayvan)
        {
            var viewModel = new HayvanTurCinsViewModel();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            if (Request.Form.Files.Count > 0 && ModelState.IsValid)
            {
                string dosyaAdi = Path.GetFileName(Request.Form.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                string dbAd = hayvan.Adi + hayvan.CinsId.ToString() + hayvan.TurId.ToString()+ hayvan.Yasi.ToString() + hayvan.EkBilgiler + uzanti;
                string yol = "wwwroot/img/" + dbAd; //+ uzanti;
                using (FileStream fs = System.IO.File.Create(yol))
                {
                    Request.Form.Files[0].CopyTo(fs);
                    fs.Flush();
                }
                hayvan.Foto = "/img/" + dbAd;
                hayvan.Cins = _context.Cins.Find(hayvan.CinsId);
                hayvan.Tur = _context.Tur.Find(hayvan.TurId);
                _context.Hayvan.Add(hayvan);
                _context.SaveChanges();
                viewModel.Hayvan = hayvan;
                ViewBag.Mesaj = "Ekleme Başarılı";
                return View(viewModel);
            }
            ViewBag.Error = "Ekleme başarısız!";
            return View(viewModel);
        }
        public IActionResult HayvanDuzenle()
        {
            var viewModel = new HayvanlarTurCinsViewModel();
            viewModel.Hayvanlar = _context.Hayvan.ToList();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            return View(viewModel);
        }
        public IActionResult HayvanSil(int id)
        {
            var hayvan=_context.Hayvan.Find(id);
            _context.Hayvan.Remove(hayvan);
            _context.SaveChanges();
            return RedirectToAction("HayvanDuzenle", "Admin");
        }
        public IActionResult HayvanUpdate(int id)
        {
            var hayvan = _context.Hayvan.Find(id);
            var viewModel = new HayvanTurCinsViewModel();
            viewModel.Turler = _context.Tur.ToList();
            viewModel.Cinsler = _context.Cins.ToList();
            viewModel.Hayvan = hayvan;
            
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult HayvanUpdate(Hayvan hayvan,int id)
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(100);
            var hay = _context.Hayvan.Find(id);
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    string dosyaAdi = Path.GetFileName(Request.Form.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Form.Files[0].FileName);
                    string dbAd = hayvan.Adi + hayvan.CinsId.ToString() + hayvan.TurId.ToString() + hayvan.Yasi.ToString() + hayvan.EkBilgiler + sayi.ToString() + uzanti;
                    string yol = "wwwroot/img/" + dbAd; //+ uzanti;
                    using (FileStream fs = System.IO.File.Create(yol))
                    {
                        Request.Form.Files[0].CopyTo(fs);
                        fs.Flush();
                    }
                    hay.Foto = "/img/" + dbAd;
                    hay.Adi = hayvan.Adi;
                    hay.TurId = hayvan.TurId;
                    hay.CinsId = hayvan.CinsId;
                    hay.Cinsiyet = hayvan.Cinsiyet;
                    hay.EkBilgiler = hayvan.EkBilgiler;
                    hay.Yasi = hayvan.Yasi;
                    hay.SahiplenildiMi = hayvan.SahiplenildiMi;
                    hay.Cins = _context.Cins.Find(hayvan.CinsId);
                    hay.Tur = _context.Tur.Find(hayvan.TurId);
                    _context.Hayvan.Update(hay);
                    _context.SaveChanges();
                    return RedirectToAction("HayvanDuzenle", "Admin");
                }
                else
                {
                    hay.Adi = hayvan.Adi;
                    hay.TurId = hayvan.TurId;
                    hay.CinsId = hayvan.CinsId;
                    hay.Cinsiyet = hayvan.Cinsiyet;
                    hay.EkBilgiler = hayvan.EkBilgiler;
                    hay.Yasi = hayvan.Yasi;
                    hay.SahiplenildiMi = hayvan.SahiplenildiMi;
                    hay.Cins = _context.Cins.Find(hayvan.CinsId);
                    hay.Tur = _context.Tur.Find(hayvan.TurId);
                    _context.Hayvan.Update(hay);
                    _context.SaveChanges();
                    return RedirectToAction("HayvanDuzenle", "Admin");
                }
            }
            return RedirectToAction("HayvanDuzenle", "Admin");
        }
        public IActionResult TurEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TurEkle(Tur tur)
        {
            if (ModelState.IsValid)
            {
                _context.Tur.Add(tur);
                _context.SaveChanges();
                ViewBag.Mesaj = "Ekleme İşlemi Başarılı";
                return View();
            }
            ViewBag.Mesaj = "Ekleme İşlemi Başarısız.";
            return View();
        }
        public IActionResult TurDuzenle()
        {
            return View(_context.Tur.ToList());
        }
        [HttpPost]
        public IActionResult TurDuzenle(int id,string duzeltilmis)
        {
            if (ModelState.IsValid)
            {
                var tur = _context.Tur.Find(id);
                if(duzeltilmis != null)
                {
                    tur.TurAdi = duzeltilmis;
                    _context.Tur.Update(tur);
                    _context.SaveChanges();
                    ViewBag.Mesaj = "Düzenleme Başarılı";
                    return View(_context.Tur.ToList());
                }
                else
                {
                    ViewBag.Error = "Lütfen boş bırakmayın!";
                    return View(_context.Tur.ToList());
                }
            }
            return View(_context.Tur.ToList());
        }
        public IActionResult TurSil()
        {
            return View(_context.Tur.ToList());
        }
        [HttpPost]
        public IActionResult TurSil(int id)
        {
            if (ModelState.IsValid)
            {
                var tur=_context.Tur.Find(id);
                _context.Tur.Remove(tur);
                _context.SaveChanges();
                ViewBag.Mesaj = "Silme işlemi başarılı";
                return View(_context.Tur.ToList());
            }
            ViewBag.Error = "Silme işlemi başarısız";
            return View(_context.Tur.ToList());
        }
        public IActionResult CinsEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CinsEkle(Cins cins)
        {
            if (ModelState.IsValid)
            {
                _context.Cins.Add(cins);
                _context.SaveChanges();
                ViewBag.Mesaj = "Ekleme İşlemi Başarılı";
                return View();
            }
            ViewBag.Mesaj = "Ekleme İşlemi Başarısız.";
            return View();
        }
        public IActionResult CinsDuzenle()
        {
            return View(_context.Cins.ToList());
        }
        [HttpPost]
        public IActionResult CinsDuzenle(int id, string duzeltilmis)
        {
            if (ModelState.IsValid)
            {
                var cins = _context.Cins.Find(id);
                if (duzeltilmis != null)
                {
                    cins.CinsAdi = duzeltilmis;
                    _context.Cins.Update(cins);
                    _context.SaveChanges();
                    ViewBag.Mesaj = "Düzenleme Başarılı";
                    return View(_context.Cins.ToList());
                }
                else
                {
                    ViewBag.Error = "Lütfen boş bırakmayın!";
                    return View(_context.Cins.ToList());
                }
            }
            return View(_context.Cins.ToList());
        }
        public IActionResult CinsSil()
        {
            return View(_context.Cins.ToList());
        }
        [HttpPost]
        public IActionResult CinsSil(int id)
        {
            if (ModelState.IsValid)
            {
                var cins = _context.Cins.Find(id);
                _context.Cins.Remove(cins);
                _context.SaveChanges();
                ViewBag.Mesaj = "Silme işlemi başarılı";
                return View(_context.Cins.ToList());
            }
            ViewBag.Error = "Silme işlemi başarısız";
            return View(_context.Cins.ToList());
        }
        public IActionResult Kullanicilar()
        {
            var kullanicilar = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();
            for (int i = 0; i < kullanicilar.Count; i++)
            {
                for (int j = 0; j < kullanicilar.Count; j++)
                {
                    if (kullanicilar[i].Id == userRoles[j].UserId)
                    {
                        kullanicilar[i].Rol = userRoles[j].RoleId;
                        if (kullanicilar[i].Rol == "1")
                        {
                            kullanicilar[i].Rol = "Admin";
                        }
                        else
                        {
                            kullanicilar[i].Rol = "Üye";
                        }
                    }
                }
            }
            return View(kullanicilar);
        }
        public IActionResult RolDegistir(string id)
        {
            var userRole = _context.UserRoles.Where(x => x.UserId == id).FirstOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            if (userRole.RoleId == "1")
            {
                userRole.RoleId = "2";
            }
            else
            {
                userRole.RoleId = "1";
            }
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return RedirectToAction("Kullanicilar", "Admin");
        }
    }
}