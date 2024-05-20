using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class Rechnung
    {
        private string rechId;
        private DateTime time;
        private Person person;
        private List<Artikel> artikels;

        public Rechnung(Person person)
        {
            this.person = person;
            this.artikels = person.Artikels;
            this.Time= DateTime.Now;
            this.RechId=Time.ToString().Replace("/","").Replace(":","").Replace(" ","")+person.Name.Substring(0,2);
        }

        public string RechId { get => rechId; set => rechId = value; }
        public DateTime Time { get => time; set => time = value; }
        public Person Person { get => person; set => person = value; }
        public List<Artikel> Artikels { get => artikels; set => artikels = value; }

        public override string ToString()
        {
            int rabat = 0;
            if (person.Beg == "Mitarbeiter") rabat = 15;

            double betrag = person.Artikels.Sum(p => p.Preis);
            double rabattbetrag = (betrag * rabat) / 100;
            double nettoBetrag = betrag - rabattbetrag;
            string x = "";
            foreach (var artikel in artikels)
            {
                x+= artikel.ToString()+"\n";
            }


                return  
                $"User        : {person.Name}\n" +
                $"User Typ    : {person.Beg,-20}\n" +
                $"Artikel zahl: {person.Artikels.Count(),-20}\n" +
                $"Rabat       : {rabat,-20}\n{x}\n" +
                $"Brutto Betrag........ {betrag}\n" +
                $"Rabatt Betrag........ {rabattbetrag}\n" +
                $"Netto Betrag......... {nettoBetrag}";
        }
    }
}
