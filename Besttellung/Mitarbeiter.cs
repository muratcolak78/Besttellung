using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class Mitarbeiter:Person
    {
        private int IDnummer;
        private double rabat=15;


        public Mitarbeiter(string name, string adresse):base(name, adresse)
        {
            IDnummer1 = Listen.staticNumbers[2].Nummer;
            Listen.staticNumbers[2].Nummer++;
            Beg ="Mitarbeiter";
    }
        public Mitarbeiter(){ }

        public int IDnummer1 { get => IDnummer; set => IDnummer = value; }
        

        public override string ToString()
        {
            return $"{IDnummer1, -10}" + base.ToString();
        }

       
    }
}
