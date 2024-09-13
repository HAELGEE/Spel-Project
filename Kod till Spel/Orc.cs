using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace Kod_till_Spel;
public class OrcBase
{
    public void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value);
        Console.ResetColor();
    }
    public void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();
    }
    public void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(value);
        Console.ResetColor();
    }

    public string name { get; set; }
    public int level { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int styrka { get; set; } = 1;
    public int agility { get; set; } = 1;
    public int stamina { get; set; } = 1;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public int charm { get; set; } = 0;    
    public double damage { get; set; }
    public double speed { get; set; }
    public double armor { get; set; }

    public Random random = new Random();

    public int Attack(Hero hero)
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)damage - (int)hero.armor;
        maxDamage += (int)damage - (int)hero.armor;
        int value = random.Next(minDamage, maxDamage);
        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.WriteLine(" skada.");     
        return value;
    }

    public virtual void GenerateName()
    {
        this.name = "Orc-" + random.Next(1, 3340);
    }
}

public class Orc : OrcBase
{
    public Orc()
    {
        this.damage = 2;
        this.speed = 1;
        this.armor = 1;
        GenerateName();
    }

    public virtual int Attack(Hero hero)
    {
        return base.Attack(hero);      // Specifik attack för Orc        
    }
}
public class Shaman : OrcBase
{
    public Shaman()
    {
        this.damage = 3;
        this.speed = 0.9;
        this.armor = 1;
        this.name = "Shaman-" + random.Next(1, 3340);
    }

    public virtual int Attack(Hero hero)
    {
        return base.Attack(hero);   // Specifik attack för Shaman        
    }
}

public class Grunt : OrcBase
{
    public Grunt()
    {
        this.damage = 1;
        this.speed = 0.5;
        this.armor = 3;
        this.name = "Grunt-" + random.Next(1, 3340);
    }

    public virtual int Attack(Hero hero)
    {
        return base.Attack(hero);      // Specifik attack för Grunt        
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
}