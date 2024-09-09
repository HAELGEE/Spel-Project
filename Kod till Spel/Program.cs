using System;
using System.Runtime.InteropServices;
using Kod_till_Spel;


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
           
            bool spel = true;
            while (spel)
            {

                Console.WriteLine("\n=== TEXT SPEL ===");
                Console.WriteLine("[S]tatus");
                Console.WriteLine("[A]ttack");
                Console.WriteLine("[H]eal");
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
                        Console.WriteLine($"Din hjälte har: {hero01.xp}xp kvar till nästa level\n");
                        Console.WriteLine("HP: " + hero01.hp);
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
                        attack._Attack();
                        break;




                    case "h":
                        
                        if (hero01.hp == hero01.Maxhp)
                        {
                            Console.WriteLine("Din hjälte har redan fullt HP");                            
                        }else
                        {
                            Console.WriteLine("Din hjälte börjar Meditera för att återställa HP");
                            while (hero01.hp < hero01.Maxhp)
                            {
                                hero01.hp += 1;
                                Console.WriteLine($"Nuvarande hp: {hero01.hp}");
                                Thread.Sleep(1000);
                            }
                        
                        
                            Console.WriteLine($"Din hjälte har {hero01.hp}hp av {hero01.hp}hp");
                        }
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
    }
}