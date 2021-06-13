using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vlastny_projekt.DataLayer.Entities
{
    public class Zamestnanec_udaje
    {
        public int ID { get; set; }
        public int ID_Zamestnanec { get; set; }
        public string meno { get; set; }
        public string priezvisko { get; set; }
        public string datum_narodenia { get; set; }
        public string mesto { get; set; }
        public string adresa { get; set; }
        public string psc { get; set; }
        public string telefonne_cislo { get; set; }
    }
}
