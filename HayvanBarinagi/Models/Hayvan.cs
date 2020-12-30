using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class Hayvan
    {
        public int HayvanId { get; set; }
        [Display(Name ="Adı")]
        [Required(ErrorMessage ="Hayvanın Adını Girmelisiniz")]
        public string Adi { get; set; }
        [Display(Name ="Yaşı")]
        [Required(ErrorMessage ="Bilmiyorsanız Tahmini bir Değer Giriniz")]
        public int Yasi { get; set; }
        [Display(Name ="Cinsiyeti")]
        [Required(ErrorMessage ="Cinsiyetini Girmelisiniz")]
        public bool Cinsiyet { get; set; }
        [Display(Name = "Sahiplenildi mi?")]
        public bool SahiplenildiMi { get; set; } = false;
        [Display(Name ="Varsa hayvan hakkında ek bilgiler")]
        public string EkBilgiler { get; set; }
        [Display(Name ="Fotoğraf")]
        public string Foto { get; set; }

        //Cins ile İlişki
        public int CinsId { get; set; }
        public virtual Cins Cins { get; set; }
        //Tür ile ilişki
        public int TurId { get; set; }
        public virtual Tur Tur { get; set; }
    }
}
