using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Kod_till_Spel
{
    class Attack
    {
        static void Green(int value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();       //Reset av färg till standard
        }
        static void Green(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(value);
            Console.ResetColor();       //Reset av färg till standard
        }
        static void Red(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.ResetColor();       //Reset av färg till standard
        }
        static void Red(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(value);
            Console.ResetColor();       //Reset av färg till standard
        }
        public void _Attack(Hero hero)
        {
            Healing healing = new Healing();
            Orc orc01 = new Orc(); // Skapar en ny orc varje gång jag går in i Attack
            Random random = new Random();

            double randomSpeedHero = hero.speed;        //sätter en tillfällig variabel för att sedan lotta vem som skall börja med speed (om speed = speed)
            double randomSpeedOrc = orc01.speed;

            Console.WriteLine($"\n{orc01.name} dyker upp!\n");
            if (hero.speed == orc01.speed)
            {
                if (random.Next(0, 2) == 0)     //Här börjar "lottningen"
                {
                    hero.speed += 0.1;
                }
                else
                {
                    orc01.speed += 0.1;      //HÄR FUCKAS SPEEDEN UPP. MÅSTE FIXA JAG "RESETAR" DEN HELA TIDEN
                }
            }

            Console.Write($"Hero HP: ");
            Green(hero.hp);
            Console.Write(", Orc HP: ");
            Red(orc01.hp);
            Console.WriteLine("");

            int randomXp = random.Next(1, 6);

            while (hero.hp > 0 && orc01.hp > 0)
            {
                if (hero.speed > orc01.speed)       //Hero speed över orc speed
                {                   
                    // Hero attackerar först
                    int damage = hero.Attack(orc01);     //Hero attackerar
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {
                        
                        Red(orc01.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc01.speed = randomSpeedOrc;           //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick {randomXp}xp\n");
                        hero.AddExperience(randomXp);       //Lägger till XP
                        Thread.Sleep(400);
                        Console.WriteLine($"Din hjälte är på level: {hero.level}");
                        Thread.Sleep(400);
                        break;
                    }

                    damage = orc01.Attack(hero);        //orc attackerar
                    hero.hp -= damage;
                    Thread.Sleep(500);
                    
                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Green(hero.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc01.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);                        
                        healing._Healing(hero);     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }

                }

                else
                {
                    
                    // Orc attackerar först
                    int damage = orc01.Attack(hero);    //Orc speed över hero speed
                    hero.hp -= damage;              //Orc attackerar
                    Thread.Sleep(500);

                    
                    if (hero.hp <= 0)
                    {                        
                        hero.hp *= 0;
                        Green(hero.name);
                        Console.Write(" är besegrad!\n");
                        orc01.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);                        
                        healing._Healing(hero);     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }

                    damage = hero.Attack(orc01);         //Hero attackerar
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {                        
                        Red(orc01.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc01.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick {randomXp}xp\n");
                        hero.AddExperience(randomXp);       //Lägger till XP efter besgrad mob
                        Thread.Sleep(400);
                        Console.WriteLine($"{hero.name} är på level: {hero.level}");
                        Thread.Sleep(400);
                        break;
                    }
                }
            }
            

            Thread.Sleep(500);
            Console.Write($"{hero.name} HP: ");
            if (hero.hp <= 0)           //lägger till Färg
            {   
                Red(hero.hp);           //Röd om hero = död
                Console.Write("\n");
            }
            else
            {
                Green(hero.hp);         //Grön om hero har över 0hp
                Console.Write("\n");
            }                              
            Thread.Sleep(700);
        }
        
        
    }
}
