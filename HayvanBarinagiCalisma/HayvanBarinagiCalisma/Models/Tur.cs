using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class Tur
    {
        public int TurId { get; set; }
        [Display(Name ="Tür Adı")]
        [Required(ErrorMessage ="Tür Adı Girilmelidir")]
        public string TurAdi { get; set; }

        //Hayvan ile ilişki
        public virtual List<Hayvan> Hayvanlar { get; set; }
    }
}
