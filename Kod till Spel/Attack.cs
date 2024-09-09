using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel
{
    class Attack
    {
        

        public void _Attack()
        {
            Hero hero01 = new Hero();

            Orc orc01 = new Orc(); // Skapar en ny orc varje gång jag går in i Attack

            Console.WriteLine($"\n{orc01.name} dyker upp!\n");
            
            while (hero01.hp > 0 && orc01.hp > 0)
            {
                if (hero01.speed > orc01.speed)
                {
                    // Hero attackerar först
                    int damage = hero01.Attack();
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {
                        Console.WriteLine(orc01.name + " är besegrad!");
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick 3xp\n");
                        hero01.experience = hero01.experience + 3;
                        Thread.Sleep(400);
                        Console.WriteLine($"Din hjälte är på level: {hero01.level}");
                        Thread.Sleep(400);
                        break;
                    }

                    damage = orc01.Attack();
                    hero01.hp -= damage;
                    Thread.Sleep(500);

                    if (hero01.hp <= 0)
                    {
                        Console.WriteLine(hero01.name + " är besegrad!");
                        Thread.Sleep(400);
                        break;
                    }
                }
                else
                {
                    // Orc attackerar först
                    int damage = orc01.Attack();
                    hero01.hp -= damage;
                    Thread.Sleep(500);

                    if (hero01.hp <= 0)
                    {
                        Console.WriteLine(hero01.name + " är besegrad!");
                        Thread.Sleep(300);
                        break;
                    }

                    damage = hero01.Attack();
                    orc01.hp -= damage;
                    Thread.Sleep(500);

                    if (orc01.hp <= 0)
                    {
                        Console.WriteLine(orc01.name + " är besegrad!");
                        Thread.Sleep(400);
                        Console.WriteLine($"Du fick 3xp\n");
                        hero01.experience = hero01.experience + 3;
                        Thread.Sleep(400);
                        Console.WriteLine($"{hero01.name} är på level: {hero01.level}");
                        Thread.Sleep(400);
                        break;
                    }
                }
            }
            Thread.Sleep(500);
            Console.WriteLine($"{hero01.name} HP: {hero01.hp}");
        }
    }
}
