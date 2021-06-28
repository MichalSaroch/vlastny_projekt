using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vlastny_projekt.DataLayer.Entities
{
    public class Produkt
    {
        public int ID { get; set; }
        public string vyrobcaMeno { get; set; }
        public string nazov { get; set; }
        public decimal cena { get; set; }
        public bool dostupne { get; set; }
    }
}
