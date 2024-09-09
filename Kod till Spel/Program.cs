using System;
using System.Runtime.InteropServices;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;


namespace SPEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Hero hero01 = new Hero();
            Console.Write("Ange ett namn till din Hjälte: ");
            hero01.name = Console.ReadLine();
            Attack attack = new Attack();
            Healing healing = new Healing();
           
            bool spel = true;
            while (spel)
            {

                Console.WriteLine("\n=== TEXT SPEL ===          A game created by #Christofer Hägg");
                Console.WriteLine("[S]tatus");
                Console.WriteLine("[A]ttack");
                Console.WriteLine("[H]eal");
                Console.WriteLine("Sa[V]e");
                Console.WriteLine("[Load]");
                Console.WriteLine("[Q]uit");
                Console.Write("Val: ");
                string val = Console.ReadLine().ToLower();
                Console.Clear();

                switch (val)
                {
                    case "s":
                        Console.WriteLine("===================================");
                        Console.WriteLine($"Ditt namn på din Hero: {hero01.name}\n");
                        Console.WriteLine("Din hjälte är på Level: " + hero01.level);
                        Console.WriteLine($"Din hjälte har: {hero01.experience}xp");
                        Console.WriteLine($"Din hjälte har: {hero01.maxXp - hero01.experience}xp kvar till nästa level\n");
                        Console.Write($"HP: ");
                        if (hero01.hp < hero01.maxHp)
                        {
                            Red(hero01.hp);
                        }
                        else
                        {
                            Green(hero01.hp);
                        }
                        Console.Write(hero01.hp);
                        Console.ResetColor();
                        Console.Write(" av ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(hero01.maxHp);
                        Console.ResetColor();
                        Console.WriteLine("Styrka: " + hero01.styrka);
                        Console.WriteLine("Agility: " + hero01.agility);
                        Console.WriteLine("Stamina: " + hero01.stamina);
                        Console.WriteLine("Intelligence: " + hero01.intelligence);
                        Console.WriteLine("Charm: " + hero01.charm);
                        Console.WriteLine("Speed: " + hero01.speed);
                        Console.WriteLine("DMG: " + hero01.dmg);
                        Console.WriteLine("===================================");
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case "a":
                        attack._Attack(hero01);
                        break;

                    case "h":
                        healing._Healing(hero01);
                        break;

                    case "v":
                        SaveHero(hero01, "hero_save.json");
                        Console.ReadKey();
                        break;

                    case "load":
                        Hero loadedHero = LoadHero("hero_save.json");
                        if (loadedHero != null)
                        {
                            hero01 = loadedHero;
                        }
                        Console.ReadKey();
                        break;

                    case "q":
                        Console.WriteLine("Tack för att du använder detta programmet, nu avslutas programmet");
                        spel = false;
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val, försök med bokstäverna innanför []");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static void Green(int value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void Red(int value)
        {
            Console.ForegroundColor= ConsoleColor.Red;
        }
        public static void SaveHero(Hero hero, string filename)
        {
            string json = JsonSerializer.Serialize(hero);
            File.WriteAllText(filename, json);
            Console.WriteLine("Hjälten är nu sparad.");
        }
        public static Hero LoadHero(string filename)
        {
            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                Hero hero = JsonSerializer.Deserialize<Hero>(json);
                Console.WriteLine("Hjälten är nu laddad.");
                return hero;
            }
            else
            {
                Console.WriteLine("Ingen sparfil hittades.");
                return null;
            }
        }

    }
}