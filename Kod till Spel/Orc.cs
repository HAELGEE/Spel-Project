using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;

namespace Kod_till_Spel;
public class Orc
{
    static void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value);
        Console.ResetColor();
    }
    static void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();
    }
    static void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(value);
        Console.ResetColor();
    }
    public double orcBaseDmg { get; set; } = 2;
    public double orcBaseArmor { get; set; } = 1;
    public double orcBaseSpeed { get; set; } = 1;


    public string name { get; set; }
    public int level { get; set; } = 7;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int styrka { get; set; } = 1;                //Ökar skada
    public int agility { get; set; } = 1;               //Ökar speed
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR

    private Random random = new Random();


    public Orc()
    {
        Hero hero = new Hero();
        Namn(); //Ger orcen ett random namn
        LevelCheck(hero);   //Kollar level emot Hero för att avgöra vilken level orc skall bli
        Stats();            
    }

    private void LevelCheck(Hero hero)
    {
        int levelOver = 0;
        int levelUnder = 1;

        if (hero.level >= this.level)
        {
            levelOver += hero.level + 3;

            if (hero.level > 3)
            {
                levelUnder = hero.level - 2;
            }

            this.level = random.Next(levelUnder, levelOver);
        }
        else
        {
            levelOver += hero.level + 3;

            this.level = random.Next(levelUnder, levelOver);
        }

        if (this.level > 1)
        {
            int levelLeft = this.level - 1;
            int j = 4;
            
            for (int i = 0; i < levelLeft; i++)
            {
                j = j - i;

                int statIncrease = random.Next(j);
                switch (statIncrease)
                {
                    case 0:
                        {
                            this.styrka++;
                            break;
                        }
                    case 1:
                        {
                            this.agility++;
                            break;
                        }
                    case 2:
                        {
                            this.stamina++;
                            break;
                        }
                    case 3:
                        {
                            this.intelligence++;
                            break;
                        }
                }
            }
        }
    }

    public void Stats()
    {
        dmg = orcBaseDmg + (styrka * 1.1);
        speed = orcBaseSpeed + (agility * 1.05);
        armor = orcBaseArmor + (agility / 2) * 1.01;
    }

    public void Namn()
    {
        this.name = "Grunt-" + random.Next(1, 3340);
    }

    public int Attack(Hero hero)    //Tvungen att lägga in Hero här för att hämta statsen ifrån Hero klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg - (int)hero.armor;
        maxDamage += (int)dmg - (int)hero.armor;
        int value = random.Next(minDamage, maxDamage);
        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.WriteLine(" skada.");
        return value;
    }
}
