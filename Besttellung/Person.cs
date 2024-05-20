using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public class Person
    {
        private string name;
        private string adresse;
        private string beg;
        private List<Artikel> artikels;
        private List<List<Artikel>> bestellungListen = new List<List<Artikel>>();

        public Person(string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
            Artikels = new List<Artikel>();
            
        }
        public Person() {
            Artikels = new List<Artikel>();
        }

        public string Name { get => name; set => name = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public List<Artikel> Artikels { get => artikels; set => artikels = value; }
        public string Beg { get => beg; set => beg = value; }
        public List<List<Artikel>> BestellungListen1 { get => bestellungListen; set => bestellungListen = value; }

        public override string ToString()
        {
            return $"{Name,-10} {Adresse, -10}";
            
        }
        public void AddArtikel(Artikel artikel)
        {
            Artikels.Add(artikel);
        }
        public void printArtikels()
        {
            Console.WriteLine(Artikels.Count());
            Artikels.ForEach(artikel =>
            {
                Console.WriteLine(artikel);
            });
        }
        public void printBestellungen()
        {
           foreach(List<Artikel> list in BestellungListen1)
            {
                foreach(Artikel artikel in list)
                {
                    Console.WriteLine(artikel);
                }
            }
           
        }
       
        
    }
}
