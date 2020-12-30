using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class Iletisim
    {
        public int IletisimId { get; set; }
        [Required(ErrorMessage ="Lütfen Adınızı Girin")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Lütfen Mesajınızı Girin")]
        public string Mesaj { get; set; }
        [Required(ErrorMessage = "Lütfen Email'inizi Girin")]
        public string Email { get; set; }
        public DateTime Tarih { get; set; }
    }
}
