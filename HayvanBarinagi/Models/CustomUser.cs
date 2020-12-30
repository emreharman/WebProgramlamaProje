using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class CustomUser:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [Display(Name ="Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime DogumTarihi { get; set; }
        public string Adres { get; set; }
        public int HayvanId { get; set; }
        public string Rol { get; set; }
    }
}
