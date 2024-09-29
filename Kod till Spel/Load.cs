using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace Kod_till_Spel;
public class Load
{
    public static List<Hero> LoadHeroes(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<List<Hero>>(json);
    }



    //public static Hero LoadHero(string filename)
    //{
    //    if (File.Exists(filename))
    //    {
    //        string json = File.ReadAllText(filename);
    //        Hero hero = JsonSerializer.Deserialize<Hero>(json);
    //        Console.WriteLine("Hjälten är nu laddad.");
    //        return hero;
    //    }
    //    else
    //    {
    //        Console.WriteLine("Ingen sparfil hittades.");
    //        return null;
    //    }
    //}
}
