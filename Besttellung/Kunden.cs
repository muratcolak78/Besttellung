using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class Kunden:Person
    {
        private int kundenId;
        private string beg;

        public Kunden(string name, string adresse):base(name, adresse)
        {
            KundenId = Listen.staticNumbers[1].Nummer;
            Listen.staticNumbers[1].Nummer++;
            Beg = "Kunden";
        }
        public Kunden() {
            Beg = "Kunden";
        }

        public int KundenId { get => kundenId; set => kundenId = value; }

        public override string ToString()
        {
            return $"{KundenId,-10}" + base.ToString();
        }
       
    }
}
