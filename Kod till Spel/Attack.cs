using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using Kod_till_Spel.Enemys;
using System.Security.Cryptography.X509Certificates;
using Kod_till_Spel.Menus;

namespace Kod_till_Spel
{
    class Attack
    {
        public Hero hero = GameState.CurrentHero;
        //public OrcBase orc = new OrcBase(hero);
        //public Elf elf = new Enemy.Elf();
        //public Ghost ghost = new Enemy.Ghost(hero);
        public Enemy enemy = new Enemy();
        static void Green(int value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(CenterText.CenterNumbers(value));
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
            Console.Write(CenterText.CenterNumbers(value));
            Console.ResetColor();       //Reset av färg till standard
        }
        static void Red(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(CenterText.CenterTexts(value));
            Console.ResetColor();       //Reset av färg till standard
        }

        Healing healing = new Healing();

        public void _Attack()
        {

            Random random = new Random();
            int randomName = random.Next(0, 3); //Lottning mellan om man skall möta en orc, shaman eller grunt      
            int randomClass = random.Next(0, 3); // Lottning mellan vilken klass som skall mötas

            if (randomClass == 0)
            {
                switch (randomName)
                {
                    case 0:
                        enemy = new Enemy.Orc(hero);
                        break;
                    case 1:
                        enemy = new Enemy.Shaman(hero);
                        break;
                    case 2:
                        enemy = new Enemy.Grunt(hero);
                        break;
                    default:
                        enemy = new Enemy.Orc(hero);
                        break;
                }
            }
            else if (randomClass == 1)
            {
                switch (randomName)
                {
                    case 0:
                        enemy = new Enemy.Sylvastra(hero);
                        break;
                    case 1:
                        enemy = new Enemy.Elowen(hero);
                        break;
                    case 2:
                        enemy = new Enemy.Tharion(hero);
                        break;
                    default:
                        enemy = new Enemy.Sylvastra(hero);
                        break;
                }
            }
            else if (randomClass == 2)
            {
                switch (randomName)
                {
                    case 0:
                        enemy = new Enemy.Wraithon(hero);
                        break;
                    case 1:
                        enemy = new Enemy.Hauntress(hero);
                        break;
                    case 2:
                        enemy = new Enemy.Gravemourn(hero);
                        break;
                    default:
                        enemy = new Enemy.Wraithon(hero);
                        break;
                }
            }

            double randomSpeedHero = hero.speed; //sätter en tillfällig variabel för att sedan lotta vem som skall börja med speed (om speed = speed)
            double randomSpeedOrc = enemy.speed;

            Console.WriteLine(CenterText.CenterTexts($"\nLevel: {enemy.level.ToString()} {enemy.name} dyker upp!\n"));

            if (hero.speed == enemy.speed)
            {
                if (random.Next(0, 2) == 0)     //Här börjar "lottningen"
                    hero.speed += 0.1;
                else
                    enemy.speed += 0.1;
            }

            Console.Write($"Hero HP: ");
            Green(hero.hp);
            Console.Write(", Orc HP: ");
            Red(enemy.hp);
            Console.WriteLine(CenterText.CenterTexts(""));
            double randomXp = 0;

            if (hero.level > enemy.level)
            {
                randomXp = random.Next(1, 4);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));
            }
            else if (hero.level < enemy.level)
            {
                randomXp = random.Next(5, 8);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));
            }
            else
            {
                randomXp = random.Next(3, 6);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));

            }

            while (hero.hp > 0 && enemy.hp > 0)
            {
                if (hero.speed > enemy.speed)     //Hero speed över orc speed
                {
                    // Hero attackerar först
                    int damage = hero.Attack(enemy);  //Hero attackerar

                    enemy.hp -= damage;
                    Thread.Sleep(500);

                    if (enemy.hp <= 0)
                    {

                        Red(enemy.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedOrc;           //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Du fick {randomXp}xp\n"));
                        hero.AddExperience(randomXp);       //Lägger till XP
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Din hjälte är på level: {hero.level}"));
                        Thread.Sleep(400);
                        break;
                    }
                    if (enemy.name.Contains("Shaman") || enemy.name.Contains("Hauntress") || enemy.name.Contains("Elowen"))                                            
                            damage = enemy.AttackSpellCasters(hero);  //enemy attackerar  
                    else
                    {
                        damage = enemy.Attack(hero);
                    }
                    hero.hp -= damage;
                    Thread.Sleep(500);

                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Console.Write("\n");
                        Green(hero.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        healing._Healing();     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }
                }
                else
                {
                    int damage;
                    // Orc attackerar först
                    if (enemy.name.Contains("Shaman"))
                    {
                        damage = enemy.AttackSpellCasters(hero);  //orc attackerar
                    }
                    else
                    {
                        damage = enemy.Attack(hero);
                    }
                    //int damage = orc.Attack(hero);    //Orc speed över hero speed
                    hero.hp -= damage;                  //Orc attackerar
                    Thread.Sleep(500);


                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Console.Write("\n");
                        Green(hero.name);
                        Console.Write(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        healing._Healing();     //Lagt till HEALING automatiskt om Hero blir besegrad
                        break;
                    }

                    damage = hero.Attack(enemy);         //Hero attackerar
                    enemy.hp -= damage;
                    Thread.Sleep(500);

                    if (enemy.hp <= 0)
                    {
                        Red(enemy.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedOrc;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Du fick {randomXp}xp\n"));
                        hero.AddExperience(randomXp);       //Lägger till XP efter besgrad mob
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"{hero.name} är på level: {hero.level}"));
                        Thread.Sleep(400);
                        break;
                    }
                }
            }

            Thread.Sleep(500);
            Console.Write(CenterText.CenterTexts($"{hero.name} HP: "));
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
            Thread.Sleep(1000);
        }

        public void DungeonAttack(Hero hero)
        {
            //Här skall det läggas in attacker för en dungeon.
            //Hur många mobs? Ska det randomatiseras?
            //Möta en boss? Kanske en mellan boss och en sista boss?

            //OrcBase orc = new OrcBase(hero);
            //Enemy enemy = null;

            Random random = new Random();
            int randomName = random.Next(0, 3); //Lottning mellan om man skall möta en orc, shaman eller grunt


            if (Dungeons.roomNumber == 1 || Dungeons.roomNumber == 3)
            {

                if (randomName == 0)
                    enemy = new Enemy.DungeonOrc(hero);
                else if (randomName == 1)
                    enemy = new Enemy.DungeonShaman(hero);
                else if (randomName == 2)
                    enemy = new Enemy.DungeonGrunt(hero);
                else
                    enemy = new Enemy.DungeonOrc(hero);




                enemy.level = 7;
                if (enemy.level > 1)     //Om fiende level är över 1 tar man och sparar den i levelLeft -1
                {
                    int levelLeft = enemy.level - 1;


                    for (int i = 0; i < levelLeft; i++)
                    {

                        enemy.hp += 3;           //lägger till 3 i hp
                        enemy.maxHp += 3;        //lägger till 3 i maxHp
                        enemy.minHealing++;      //lägger till 1 i minimum Healing
                        enemy.maxHealing++;      //Lägger till 1 i maximum Healing

                        int statIncrease = random.Next(0, 4);
                        switch (statIncrease)
                        {
                            case 0:
                                {
                                    enemy.styrka++;      //Om lottningen stannade här +1 i styrka
                                    break;
                                }
                            case 1:
                                {
                                    enemy.agility++;     //Om lottningen stannade här +1 i agility
                                    break;
                                }
                            case 2:
                                {
                                    enemy.stamina++;     //Om lottningen stannade här +1 i stamina
                                    break;
                                }
                            case 3:
                                {
                                    enemy.intelligence++;    //Om lottningen stannade här +1 i intelligence
                                    break;
                                }
                        }
                    }
                }
            }
            else
            {
                enemy = new Enemy.Boss(hero);
                enemy.level = 8;
                if (enemy.level > 1)     //Om fiende level är över 1 tar man och sparar den i levelLeft -1
                {
                    int levelLeft = enemy.level - 1;


                    for (int i = 0; i < levelLeft; i++)
                    {

                        enemy.hp += 3;           //lägger till 3 i hp
                        enemy.maxHp += 3;        //lägger till 3 i maxHp
                        enemy.minHealing++;      //lägger till 1 i minimum Healing
                        enemy.maxHealing++;      //Lägger till 1 i maximum Healing

                        int statIncrease = random.Next(0, 3);
                        switch (statIncrease)
                        {
                            case 0:
                                {
                                    enemy.styrka++;      //Om lottningen stannade här +1 i styrka
                                    break;
                                }
                            case 1:
                                {
                                    enemy.agility++;     //Om lottningen stannade här +1 i agility
                                    break;
                                }
                            case 2:
                                {
                                    enemy.intelligence++;   //Om lottningen stannade här +1 i intelligence
                                    break;
                                }
                            case 3:
                                {
                                    enemy.stamina++;   // Om lottningen stannade här + 1 i stamina
                                    break;
                                }
                        }
                    }

                }
            }

            double randomSpeedHero = hero.speed;        // Sätter en tillfällig variabel för att sedan lotta vem som skall börja med speed (om speed = speed)
            double randomSpeedEnemy = enemy.speed;

            Console.WriteLine(CenterText.CenterTexts($"\nLevel: {enemy.level} {enemy.name} dyker upp!\n"));

            if (hero.speed == enemy.speed)
            {
                if (random.Next(0, 2) == 0)     // Här börjar "lottningen"
                {
                    hero.speed += 0.1;
                }
                else
                {
                    enemy.speed += 0.1;
                }
            }

            Console.Write($"Hero HP: ");
            Green(hero.hp);
            Console.Write(", Enemy HP: ");
            Red(enemy.hp);
            Console.WriteLine(CenterText.CenterTexts(""));
            double randomXp = 0;

            if (hero.level > enemy.level)
            {
                randomXp = random.Next(1, 4);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));
            }
            else if (hero.level < enemy.level)
            {
                randomXp = random.Next(5, 8);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));
            }
            else
            {
                randomXp = random.Next(3, 6);
                randomXp = Math.Round(randomXp + (hero.level * 1.3));

            }

            while (hero.hp > 0 && enemy.hp > 0)
            {
                if (hero.speed > enemy.speed)     //Hero speed över fiende speed
                {
                    // Hero attackerar först
                    int damage = hero.Attack(enemy);  //Hero attackerar

                    enemy.hp -= damage;
                    Thread.Sleep(500);

                    if (enemy.hp <= 0)
                    {

                        Red(enemy.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedEnemy;           //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Du fick {randomXp}xp\n"));
                        hero.AddExperience(randomXp);       //Lägger till XP
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Din hjälte är på level: {hero.level}"));
                        Thread.Sleep(400);
                        break;
                    }

                    if (enemy.name.Contains("Shaman"))
                        damage = enemy.AttackSpellCasters(hero);  // Fiende attackerar                    
                    else if (enemy.name.Contains("Boss"))
                        damage = enemy.BossAttack(hero);
                    else
                        damage = enemy.Attack(hero);

                    hero.hp -= damage;
                    Thread.Sleep(500);

                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Console.Write("\n");
                        Green(hero.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedEnemy;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        break;
                    }
                }
                else
                {
                    int damage;
                    // Fiende attackerar först
                    if (enemy.name.Contains("Shaman"))
                    {
                        damage = enemy.AttackSpellCasters(hero);  //Fiende attackerar
                    }
                    else if (enemy.name.Contains("Boss"))
                    {
                        damage = enemy.BossAttack(hero);
                    }
                    else
                    {
                        damage = enemy.Attack(hero);
                    }

                    hero.hp -= damage;                  //Fiende attackerar
                    Thread.Sleep(500);


                    if (hero.hp <= 0)
                    {
                        hero.hp *= 0;
                        Console.Write("\n");
                        Green(hero.name);
                        Console.Write(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedEnemy;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        break;
                    }

                    damage = hero.Attack(enemy);         //Hero attackerar
                    enemy.hp -= damage;
                    Thread.Sleep(500);

                    if (enemy.hp <= 0)
                    {
                        Red(enemy.name);
                        Console.WriteLine(CenterText.CenterTexts(" är besegrad!\n"));
                        enemy.speed = randomSpeedEnemy;       //Stänger av tillfälliga speed ökningen
                        hero.speed = randomSpeedHero;
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"Du fick {randomXp}xp\n"));
                        hero.AddExperience(randomXp);       //Lägger till XP efter besgrad fiende
                        Thread.Sleep(400);
                        Console.WriteLine(CenterText.CenterTexts($"{hero.name} är på level: {hero.level}"));
                        Thread.Sleep(400);
                        break;
                    }
                }
            }

            Thread.Sleep(500);
            Console.Write(CenterText.CenterTexts($"{hero.name} HP: "));
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
            Thread.Sleep(1000);
        }
    }
}
