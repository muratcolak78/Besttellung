using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Besttellung
{
    static class Menu
    {

        public static void Start()
        {
            Listen.ersteEinstellung();
            Person person = null;
            bool exit = false;

            do
            {

                string auswahl = ErsteMenu();
                switch (auswahl)
                {
                    case "1":
                        
                        string auswahl2 = KundenOderMitarbeiterMenu();

                        switch (auswahl2)
                        {
                            case "1":
                               
                                Kunden kunde = vorhandenenKunde();
                                if (kunde == null) break;
                                printArtikelList();
                                auswahlungsmenu(kunde);

                                break;
                            case "2":
                                Mitarbeiter mitarbeiter = vorhandenenMitarbeiter();
                                if (mitarbeiter == null) break;
                              
                                printArtikelList();
                                auswahlungsmenu(mitarbeiter);
                                break;
                            case "3":
                                mitarbeiter = null;
                                kunde = null;
                                exit = true;
                                break;

                            default:
                                Console.WriteLine("auswahl ist ungültig");
                                break;

                        }
                        break;

                    case "2":
                        newKunden();
                        break;
                    case "3":
                        newMitarbeiter();
                        break;
                    case "4":
                        newArtikel();
                        break;
                    case "5":
                        sucheKunde();
                        break;
                    case "6":
                        artikelList();
                        break;
                    case "8":
                        printKunden();
                        break;
                    case "9":
                        printMitarbeiter();
                        break;
                    case "10":
                        printArtikelList();
                        break;
                    case "11":
                        printStaticnumbers();
                        break;
                    case "12":
                        printVerkaufteArtikels();
                        break;
                    case "13":
                        meistenVerkauf();
                        break;
                    case "14":
                        printRechnungs();
                        break;

                    case "7":

                        exit = true;
                        break;

                    default:
                        Console.WriteLine("auswahl ist ungültig");
                        break;
                }
                   
                
                

            } while (!exit);
        }

        private static void artikelList()
        {
            Listen.Artikels.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }

        private static void newArtikel()
        {
            
            Console.WriteLine("Artikel bezeichnung :");
            string beziechungs =Console.ReadLine();
            Console.WriteLine("Artikel preis (double) :");
            string preis=Console.ReadLine();
            if(double.TryParse(preis, out double preisArtikel))
            {
                Listen.Artikels.Add(new Artikel(beziechungs, preisArtikel));
                Listen.aktuellenArtikels();
            }else Console.WriteLine("preis muss double sein");

        }

        private static void sucheKunde()
        {
           
        }

        private static string ErsteMenu() {
            Console.WriteLine("\n1.Rechnungerstellung");
            Console.WriteLine("2.Neue Kunde");
            Console.WriteLine("3.Neue Mitarbeiter");
            Console.WriteLine("4.neue Artikel");
            Console.WriteLine("5.Suche Kunde");
            Console.WriteLine("6.Verkaufte Artikel list ");
            Console.WriteLine("7. Beendet");
            Console.WriteLine("8. print kunden");
            Console.WriteLine("9. print mitarbeiter");
            Console.WriteLine("10. print artikel");
            Console.WriteLine("11. print staticsnummbers");
            Console.WriteLine("12. print verkaufte Artikels");
            Console.WriteLine("13. meisten verkaufte artikels\n");
            Console.WriteLine("14. print rechnungs");
            string auswahl = Console.ReadLine();
            return auswahl;
        }
        private static string KundenOderMitarbeiterMenu()
        {
            Console.WriteLine("1. Für Kunden");
            Console.WriteLine("2. Für Mitarebeiter");
            string auswahl = Console.ReadLine();
            return auswahl;
        }
        private static void auswahlungsmenu(Person person) {

           
            bool exit = false;
            List<Artikel> list=new List<Artikel>();
            do
            {
                

                Console.WriteLine("Wahlen Sie bitte Artikel.\nFür Rechnung Clicken Sie ^R^\nFür exit clicken Sie ^X^");
                string auswahl = Console.ReadLine();
                if (auswahl.ToLower() == "x")
                {
                    if(list.Count()>0) person.BestellungListen1.Add(list);
                    exit = true;
                }else if (auswahl.ToLower()=="r") 
                {
                    Console.Clear();
                    
                    if (list.Count() > 0) person.BestellungListen1.Add(list);
                    
                    machRecnung(person);
                    
                    Console.ReadLine();
                
                }
                else if (int.TryParse(auswahl, out int artikelNummer))
                {
                    
                    
                    if (artikelNummer>0 && artikelNummer<=Listen.Artikels.Count())
                    {
                        
                        
                        var artikel = Listen.Artikels.Find(p=>p.ANummer==artikelNummer);
                        
                                        
                        list.Add(artikel);
                        person.Artikels.Add(artikel);
                        
                        Listen.verkaufteArtikels.Add(++Listen.staticNumbers[4].Nummer, artikel);
                        Listen.aktuellenStaticNumbers();
                                               
                        Listen.akteullenVerkaufteArtikels();

                        Console.Clear();
                        printArtikelList();
                        Console.WriteLine("============================================");
                        person.printArtikels();
                        

                        

                    }
                    else Console.WriteLine("ungültig wahlung wahlung kann von 0 bis "+ Listen.Artikels.Count());
                }
                else Console.WriteLine("ungültig wahlung");

            } while (!exit);


        }
        
        private static void printArtikelList()
        {
            
            Listen.Artikels.ForEach(artikel => Console.WriteLine(artikel));
        }

        private static string PersonenMenu()
        {
            Console.WriteLine("Bitte geben Sie name");
            string name= Console.ReadLine();
            Console.WriteLine("Bitte geben Sie addresse");
            string adresse= Console.ReadLine();
            return name+","+adresse;
        } 
        private static Kunden newKunden()
        {
            string[] person=PersonenMenu().Split(',');

           
                Kunden kunden = new Kunden(person[0], person[1]);
                Listen.Kundens.Add(kunden);
                Listen.aktullenKunden();
                Console.WriteLine(kunden+"ist zur kunden List hinzugefügt");
                return kunden;
           
        }
        private static Mitarbeiter newMitarbeiter()
        {
            string[] person = PersonenMenu().Split(',');
           
                Mitarbeiter mitarbeiter=new Mitarbeiter(person[0], person[1]);
                Listen.Mitarbeiters.Add(mitarbeiter);
                Listen.aktuellenMitarbeiter();

                Console.WriteLine(mitarbeiter+" ist zur mitarbeiter List hinzugefügt");
           
                return mitarbeiter;

        }
        public static void printKunden()
        {
            Listen.Kundens.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }
        public static void printMitarbeiter()
        {
            Listen.Mitarbeiters.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }
        public static void printStaticnumbers()
        {
            Listen.staticNumbers.ForEach(p =>
            {
                Console.WriteLine(p);
            });
        }

        public static Kunden vorhandenenKunde()
        {

            Kunden kunde = null;
            Console.WriteLine("1. Vorhandene kunden.......... 2. Neue Kunden");
            string auswahl= Console.ReadLine(); 
            switch (auswahl)
            {
                case "1":
                    Console.WriteLine("Bitte geben Sie Ihre Name: ");
                    string suchtePersonName = Console.ReadLine();
                    var p = Listen.Kundens.Find(p => p.Name == suchtePersonName);

                    if (p != null)
                    {
                        kunde = p;
                        Console.WriteLine("Hallo "+kunde.Name);
                    }
                    else
                    {

                        Console.WriteLine("Person nicht gefunden.");
                    }
                    break;
                    case "2":
                        kunde=newKunden();
                    Console.WriteLine("Hallo " + kunde.Name);
                    break;
                default:
                    Console.WriteLine("Ungültige Auswaghlung");
                    break;
            }

            return kunde;
            
        }
        public static Mitarbeiter vorhandenenMitarbeiter()
        {
            Mitarbeiter arbeiter = null;
            Console.WriteLine("1. Vorhandene Mitarbeiter.......... 2. Neue Mitarbeiter");
            string auswahl = Console.ReadLine();
            switch (auswahl)
            {
                case "1":
                    Console.WriteLine("Bitte geben Sie Ihre Name: ");
                    string suchtePersonName = Console.ReadLine();
                    var per = Listen.Mitarbeiters.Find(p => p.Name == suchtePersonName);

                    if (per != null)
                    {
                        arbeiter = per;
                        Console.WriteLine("Hallo " + arbeiter.Name);
                    }
                    else
                    {
                        Console.WriteLine("Person nicht gefunden.");
                        break;
                    }
                    break;

                case "2":
                    arbeiter = newMitarbeiter();
                    if (arbeiter != null)
                    {
                        Console.WriteLine("Hallo " + arbeiter.Name);
                    }
                    break;

                default:
                    Console.WriteLine("Ungültige Auswahl");
                    break;
            }

            return arbeiter;
        }

        public static void printVerkaufteArtikels()
        {
            Listen.aktuellenStaticNumbers();
            Listen.akteullenVerkaufteArtikels();
            Console.WriteLine("Alle verkaufte artikles");
            Console.WriteLine("==================================================");
            Console.WriteLine("Total verkaufte artikel zahlen               : " + Listen.verkaufteArtikels.Count());
                foreach (var key in Listen.verkaufteArtikels)
            {
                Console.WriteLine(key.Key+"  "+key.Value);
            }

        }
        public static void meistenVerkauf()
        {
            var meistenVerkauftes = Listen.verkaufteArtikels.Values.ToList();
            var grouped = from a in meistenVerkauftes
                    group a by a.Bezeichnung into x
                    orderby x.Count() descending
                    select new
                    {
                        Description = x.Key,
                        Count = x.Count()
                    };
            int counter = 1;
            foreach (var item in  grouped)
            {
                Console.WriteLine($"{counter, -2}.  {item.Description,-10} Sold : {item.Count,-15}");
                counter++;
            }
                   

        }
        private static void machRecnung(Person person)
        {
            Rechnung rechnung = new Rechnung(person);
            Listen.rechnungs.Add(rechnung);
            Listen.aktuellenRechnungs();
            
            int rabat = 0;
            if (person.Beg == "Mitarbeiter") rabat = 15;
            
            double betrag = person.Artikels.Sum(p => p.Preis);
            double rabattbetrag = (betrag * rabat) / 100;
            double nettoBetrag = betrag - rabattbetrag;
            
            Console.WriteLine("======================================");
            Console.WriteLine("             Rechnung               \n");
            Console.WriteLine($"User        : {person.Name}");
            Console.WriteLine($"User Typ    : {person.Beg,-20}");
            Console.WriteLine($"Artikel zahl: {person.Artikels.Count(),-20}");
            Console.WriteLine($"Rabat       : {rabat,-20}");
            Console.WriteLine();
            person.printArtikels();
            Console.WriteLine();
            Console.WriteLine($"Brutto Betrag........ {betrag}");
            Console.WriteLine($"Rabatt Betrag........ {rabattbetrag}");
            Console.WriteLine($"Netto Betrag......... {nettoBetrag}");
            Console.WriteLine("======================================");
        }
        private static void printRechnungs()
        {

            foreach (var item in Listen.rechnungs)
            {
               Console.WriteLine(item);
                
            }
        }
    }
}
