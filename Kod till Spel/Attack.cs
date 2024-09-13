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
        Healing healing = new Healing();

        public void _Attack(Hero hero)
        {
            OrcBase orc;
            Random random = new Random();
            int randomName = random.Next(0, 3); //Lottning mellan om man skall möta en orc, shaman eller grunt

            switch (randomName)
            {
                case 0:
                    orc = new Orc();
                    break;
                case 1:
                    orc = new Shaman();
                    break;
                case 2:
                    orc = new Grunt();
                    break;
                default:
                    orc = new Orc(); 
                    break;
            }

            double randomSpeedHero = hero.speed;        //sätter en tillfällig variabel för att sedan lotta vem som skall börja med speed (om speed = speed)
            double randomSpeedOrc = orc.speed;

            Console.WriteLine($"\nLevel: {orc.level} {orc.name} dyker upp!\n");

            if (hero.speed == orc.speed)
            {
                if (random.Next(0, 2) == 0)     //Här börjar "lottningen"
                {
                    hero.speed += 0.1;
                }
                else
                {
                    orc.speed += 0.1;                    
                }
            }

            Console.Write($"Hero HP: ");
            Green(hero.hp);
            Console.Write(", Orc HP: ");
            Red(orc.hp);
            Console.WriteLine("");
            int randomXp = 0;

            if (hero.level > orc.level)
            {
                randomXp = random.Next(1, 3);
            }
            else if (hero.level < orc.level)
            {
                randomXp = random.Next(5, 8);
            }
            else
            {
                randomXp = random.Next(3, 5);
            }

            while (hero.hp > 0 && orc.hp > 0)
            {
                if (hero.speed > orc.speed)       //Hero speed över orc speed
                {
                    // Hero attackerar först
                    int damage = hero.Attack(orc);     //Hero attackerar
                    orc.hp -= damage;
                    Thread.Sleep(500);

                    if (orc.hp <= 0)
                    {

                        Red(orc.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc.speed = randomSpeedOrc;           //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick {randomXp}xp\n");
                        hero.AddExperience(randomXp);       //Lägger till XP
                        Thread.Sleep(400);
                        Console.WriteLine($"Din hjälte är på level: {hero.level}");
                        Thread.Sleep(400);
                        break;
                    }

                    damage = orc.Attack(hero);        //orc attackerar
                    hero.hp -= damage;
                    Thread.Sleep(500);

                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Green(hero.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        healing._Healing(hero);     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }

                }

                else
                {

                    // Orc attackerar först
                    int damage = orc.Attack(hero);    //Orc speed över hero speed
                    hero.hp -= damage;                  //Orc attackerar
                    Thread.Sleep(500);


                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Green(hero.name);
                        Console.Write(" är besegrad!\n");
                        orc.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        healing._Healing(hero);     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }

                    damage = hero.Attack(orc);         //Hero attackerar
                    orc.hp -= damage;
                    Thread.Sleep(500);

                    if (orc.hp <= 0)
                    {
                        Red(orc.name);
                        Console.WriteLine(" är besegrad!\n");
                        orc.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
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
