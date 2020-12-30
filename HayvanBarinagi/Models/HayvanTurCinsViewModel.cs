using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HayvanBarinagiCalisma.Models
{
    public class HayvanTurCinsViewModel
    {
        public Hayvan Hayvan { get; set; }
        public List<Tur> Turler { get; set; }
        public List<Cins> Cinsler { get; set; }
    }
}
