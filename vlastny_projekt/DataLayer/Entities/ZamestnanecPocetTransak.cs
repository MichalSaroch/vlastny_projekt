using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vlastny_projekt.DataLayer.Entities
{
    public class ZamestnanecPocetTransak
    {
        public int ID_Zamesntanec { get; set; }
        public string prihlMeno { get; set; }
        public string meno { get; set; }
        public string priezvisko { get; set; }
        public int pocetTransakcii { get; set; }
        public int rebricekPoctuTransakcii { get; set; }
    }
}
