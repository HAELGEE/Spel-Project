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
        public void _Attack(Hero hero)
        {
            Orc orc01 = new Orc(); // Skapar en ny orc varje gång jag går in i Attack
            Random random = new Random();
            double randomSpeedHero = hero.speed;
            double randomSpeedOrc = orc01.speed;

            Console.WriteLine($"\n{orc01.name} dyker upp!\n");
            
            while (hero.hp > 0 && orc01.hp > 0)
            {
                if (random.Next(0, 2) == 0)
                {
                    hero.speed += 0.1;
                }
                else
                {
                    orc01.speed += 0.1;
                }

                if (hero.speed > orc01.speed)
                {
                    // Hero attackerar först
                    int damage = hero.Attack();
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {
                        Console.WriteLine(orc01.name + " är besegrad!");
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick 3xp\n");
                        hero.AddExperience(3);
                        Thread.Sleep(400);
                        Console.WriteLine($"Din hjälte är på level: {hero.level}");
                        Thread.Sleep(400);
                        break;
                    }

                    damage = orc01.Attack();
                    hero.hp -= damage;
                    Thread.Sleep(500);

                    if (hero.hp <= 0)
                    {
                        Console.WriteLine(hero.name + " är besegrad!");
                        Thread.Sleep(400);
                        break;
                    }
                }
                else
                {
                    // Orc attackerar först
                    int damage = orc01.Attack();
                    hero.hp -= damage;
                    Thread.Sleep(500);

                    if (hero.hp <= 0)
                    {
                        Console.WriteLine(hero.name + " är besegrad!");
                        Thread.Sleep(300);
                        break;
                    }

                    damage = hero.Attack();
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {
                        Console.WriteLine(orc01.name + " är besegrad!");
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick 3xp\n");
                        hero.AddExperience(3);
                        Thread.Sleep(400);
                        Console.WriteLine($"{hero.name} är på level: {hero.level}");
                        Thread.Sleep(400);
                        break;
                    }
                }
            }

            hero.speed = randomSpeedHero;
            orc01.speed = randomSpeedOrc;

            Thread.Sleep(500);
            Console.Write($"{hero.name} HP: ");
            if (hero.hp <= 0)
            {
                Red(hero.hp);
            }
            else
            {
                Green(hero.hp);
            }
            Console.WriteLine(hero.hp);
            Console.ResetColor();
            Thread.Sleep(700);
        }

        static void Green(int value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        static void Red(int value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
