using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Kod_till_Spel;
public class Save
{
    public static List<Hero> heroes = new List<Hero>();
    public static void SaveHeroes(Hero newHero, string filename)
    {
        // Ladda befintliga hjältar från filen
        List<Hero> heroes = LoadHeroes(filename);

        // Lägg till den nya hjälten till listan
        heroes.Add(newHero);

        // Spara hela listan tillbaka till filen
        string json = JsonSerializer.Serialize(heroes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filename, json);
        Console.WriteLine("Hjälten är nu sparad.");
    }
    public static List<Hero> LoadHeroes(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            return JsonSerializer.Deserialize<List<Hero>>(json);
        }
        return new List<Hero>();
    }

    //public static void SaveHero(Hero hero, string filename)
    //{
    //    string json = JsonSerializer.Serialize(hero);
    //    File.WriteAllText(filename, json);
    //    Console.WriteLine("Hjälten är nu sparad.");
    //}
}
