using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Besttellung
{
    public static class Listen
    {
        //index 0 Artikel nummer index1 kundennummer index2 miatarbeiternummer index3 rechnungsNummer
        public static List<StaticNummers> staticNumbers { set; get; } = new List<StaticNummers>()
        {
            new StaticNummers(1,"ArtikelNummer"),
            new StaticNummers(1,"KundenNummer"),
            new StaticNummers(1,"MitarbeiterNummer"),
            new StaticNummers(1,"RechnungsNummer"),
            new StaticNummers(1,"VerkaufteId")
        };
        public static List<Kunden> Kundens { get; set; } = new List<Kunden>();
        public static List<Mitarbeiter> Mitarbeiters { get; set; }= new List<Mitarbeiter>();
        public static List<Artikel> Artikels { get; set; }=new List<Artikel>()
        {
        new Artikel("Laptop", 899.99),
            new Artikel("Fußball", 19.99),
            new Artikel("Schuhe", 49.99),
            new Artikel("Handy", 599.99),
            new Artikel("Kopfhörer", 29.99),
            new Artikel("T-Shirt", 15.99),
            new Artikel("Hose", 39.99),
            new Artikel("Tisch", 119.99),
            new Artikel("Stuhl", 49.99),
            new Artikel("Kühlschrank", 499.99),
            new Artikel("Mikrowelle", 89.99),
            new Artikel("Buch", 9.99),
            new Artikel("Tablet", 299.99),
            new Artikel("Monitor", 199.99),
            new Artikel("Maus", 25.99),
            new Artikel("Tastatur", 49.99),
            new Artikel("Lampe", 24.99),
            new Artikel("Rucksack", 39.99),
            new Artikel("Uhr", 89.99),
            new Artikel("Fahrrad", 299.99)
        };
        public static Dictionary<int ,Artikel> verkaufteArtikels=new Dictionary<int ,Artikel>();
        public static List<Rechnung> rechnungs=new List<Rechnung>();
        
        public static void ersteEinstellung()
        {
            if (!File.Exists("staticnummers.json"))
            {
                JSON.SaveListAsJson<StaticNummers>(staticNumbers, "staticnummers.json");
            }
            else staticNumbers = JSON.ReadListFromJson<StaticNummers>("staticnummers.json");
            
            if (!File.Exists("kundesList.json"))
            {
                JSON.SaveListAsJson<Kunden>(Kundens, "kundesList.json");
            }
            else Kundens = JSON.ReadListFromJson<Kunden>("kundesList.json");
            
            if (!File.Exists("mitarbeiterList.json"))
            {
                JSON.SaveListAsJson<Mitarbeiter>(Mitarbeiters, "mitarbeiterList.json");
            }
            else Mitarbeiters = JSON.ReadListFromJson<Mitarbeiter>("mitarbeiterList.json");
            
            if (!File.Exists("artikelList.json"))
            {
                JSON.SaveListAsJson<Artikel>(Artikels, "artikelList.json");
            }
            else Artikels = JSON.ReadListFromJson<Artikel>("artikelList.json");
            
            if (!File.Exists("rechnungsList.json"))
            {
                JSON.SaveListAsJson<Rechnung>(rechnungs, "rechnungsList.json");
            }
            else rechnungs = JSON.ReadListFromJson<Rechnung>("rechnungsList.json");

            if (!File.Exists("verkaufteArtikelList.json"))
            {
                JSON.saveDictionaryAsJson<int,Artikel>(verkaufteArtikels, "verkaufteArtikelList.json");
            }
            else verkaufteArtikels = JSON.LoadDictionaryFromJson<int,Artikel>("verkaufteArtikelList.json");

        }
        public static void aktuellenStaticNumbers()
        {
            JSON.SaveListAsJson<StaticNummers>(staticNumbers, "staticnummers.json");
            staticNumbers = JSON.ReadListFromJson<StaticNummers>("staticnummers.json");
        }
        public static void aktullenKunden()
        {
            JSON.SaveListAsJson<Kunden>(Kundens, "kundesList.json");
            Kundens = JSON.ReadListFromJson<Kunden>("kundesList.json");
        }
        public static void aktuellenMitarbeiter()
        {
            JSON.SaveListAsJson<Mitarbeiter>(Mitarbeiters, "mitarbeiterList.json");
            Mitarbeiters = JSON.ReadListFromJson<Mitarbeiter>("mitarbeiterList.json");
        }
        public static void aktuellenArtikels()
        {
            JSON.SaveListAsJson<Artikel>(Artikels, "artikelList.json");
            Artikels = JSON.ReadListFromJson<Artikel>("artikelList.json");
        }
        public static void akteullenVerkaufteArtikels()
        {
            JSON.saveDictionaryAsJson<int, Artikel>(verkaufteArtikels, "verkaufteArtikelList.json");
            verkaufteArtikels = JSON.LoadDictionaryFromJson<int, Artikel>("verkaufteArtikelList.json");
        }
        public static void aktuellenRechnungs()
        {
            JSON.SaveListAsJson<Rechnung>(rechnungs, "rechnungsList.json");
            rechnungs = JSON.ReadListFromJson<Rechnung>("rechnungsList.json");
        }
    }
}
