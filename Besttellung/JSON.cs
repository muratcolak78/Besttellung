using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Besttellung
{
    public static class JSON
    {
        public static void SaveListAsJson<T>(List<T> list, string filePath)
        {
            try
            {
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                File.WriteAllText(filePath, json);

                Console.WriteLine("\nList wurde erfolgreich als Json gespeichert");


            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler bei der dateischreibung as Json  " + ex.Message);
            }
        }

        internal static List<T> ReadListFromJson<T>(string path)
        {
            try
            {
                string jsonToString = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(jsonToString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("fehler bei der Lesung und convert zu string");
                return new List<T> { };
            }

        }

        public static void saveDictionaryAsJson<TKey, TValue>(Dictionary<TKey, TValue> list, string path)
        {
            try
            {
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions
                {
                    WriteIndented = true,
                });
                File.WriteAllText(path, json);

                Console.WriteLine("\nList wurde erfolgreich als Json gespeichert");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Dictionary<TKey, TValue> LoadDictionaryFromJson<TKey, TValue>(string path)
        {
            try
            {
                // Dosya içeriğini oku
                string json = File.ReadAllText(path);

                // JSON stringini Dictionary'ye dönüştür
               

                Console.WriteLine("JSON dosyasından dictionary başarıyla okundu.");
                return JsonSerializer.Deserialize<Dictionary<TKey,TValue>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("JSON dosyasından okunurken bir hata oluştu: " + ex.Message);
                return null;
            }
        }
    }
}

