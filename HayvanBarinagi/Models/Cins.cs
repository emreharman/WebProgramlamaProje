using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class Cins
    {
        public int CinsId { get; set; }
        [Display(Name ="Cins Adı")]
        [Required(ErrorMessage ="Cins Adı Girilmelidir")]
        public string CinsAdi { get; set; }
        //Hayvan ile ilişki
        public virtual List<Hayvan> Hayvanlar { get; set; }
    }
}
