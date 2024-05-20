using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class StaticNummers
    {
        private int nummer;
        private string nummerName;

        public StaticNummers(int nummer, string nummerName)
        {
            
            Nummer = nummer;
            NummerName = nummerName;
        }

        public int Nummer { get => nummer; set => nummer = value; }
        public string NummerName { get => nummerName; set => nummerName = value; }

        public override string ToString()
        {
            return $"Name: {NummerName} Number: {Nummer}";
        }

    }
}
