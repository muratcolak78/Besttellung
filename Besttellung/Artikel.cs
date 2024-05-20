using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class Artikel
    {
        private int aNummer;
        private string bezeichnung;
        private double preis;
        
        
      

        public Artikel( string bezeichnung, double preis)
        {
            ANummer = Listen.staticNumbers[0].Nummer;
            Listen.staticNumbers[0].Nummer++;
            Bezeichnung = bezeichnung;
            Preis = preis;
            
        }
        public Artikel() { }

        public int ANummer { get => aNummer; set => aNummer = value; }
        public string Bezeichnung { get => bezeichnung; set => bezeichnung = value; }
        public double Preis { get => preis; set => preis = value; }
       

        public override string ToString()
        {
            return $"{ANummer, -4} {Bezeichnung, -15}  {Preis, -10}  ";
        }

        
    }
}
