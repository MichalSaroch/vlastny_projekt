using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vlastny_projekt.DataLayer.Entities
{
    public class TransakciaOsoby
    {
        public int IDTransakcie { get; set; }
        public string prihlMeno { get; set; }
        public string menoZamestnanca { get; set; }
        public string priezviskoZamestnanca { get; set; }
        public string menoZakaznika { get; set; }
        public string priezviskoZakaznika { get; set; }
        public string typTransakcie { get; set; }
    }
}
