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
    public Hero hero = new Hero();
    public void LevelCheck(Hero hero)
    {
        Random random = new Random();

        int levelOver = 0;
        int levelUnder = 1;
        if (levelUnder < 1)     //Kollar om levelUnder ligger under 1 isf sätter den upp den till 1
        {
            levelUnder = 1;
        }

        if (hero.level >= this.level)       //Kollar vilken level Hero är på och jämför med orc level (this.level)
        {
            levelOver = hero.level + 3;     //Om hero level är över orc level tar man hero level + 3 för att få "levelOver"

            if (hero.level > 3)             //Kollar om Hero level är över 3
            {
                levelUnder = hero.level - 2;    //Om hero level är över 3 tar man av 2 så får man en motståndare som har max 2 level under och max 2 level över hero
            }

            this.level = random.Next(levelUnder, levelOver);    //Randomiserar vilken level orc skall bli
        }
        else
        {
            levelOver = hero.level + 3;     //Om hero level är över orc level tar man hero level + 3 för att få "levelOver"

            this.level = random.Next(levelUnder, levelOver);    //Randomiserar vilken level orc skall bli
        }

        if (this.level > 1)     //Om orc level är över 1 tar man och sparar den i levelLeft -1
        {
            int levelLeft = this.level - 1;
            

            for (int i = 0; i < levelLeft; i++)
            {
                
                this.hp++;              //lägger till 1 i hp
                this.maxHp++;           //lägger till 1 i maxHp
                this.minHealing++;      //lägger till 1 i minimum Healing
                this.maxHealing++;      //Lägger till 1 i maximum Healing

                int statIncrease = random.Next(0, 4);
                switch (statIncrease)
                {
                    case 0:
                        {
                            this.styrka++;      //Om lottningen stannade här +1 i styrka
                            break;
                        }
                    case 1:
                        {
                            this.agility++;     //Om lottningen stannade här +1 i agility
                            break;
                        }
                    case 2:
                        {
                            this.stamina++;     //Om lottningen stannade här +1 i stamina
                            break;
                        }
                    case 3:
                        {
                            this.intelligence++;    //Om lottningen stannade här +1 i intelligence
                            break;
                        }
                }
            }
        }
    }
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
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 1;
    public int agility { get; set; } = 1;
    public int stamina { get; set; } = 1;
    public int intelligence { get; set; } = 1;
    public int mana { get; set; } = 0;
    public int charm { get; set; } = 0;
    public double damage { get; set; }
    public double speed { get; set; }
    public double armor { get; set; }
    public double healing { get; set; } = 0;
    public int minHealing { get; set; } = 1;
    public int maxHealing { get; set; } = 3;

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
        Console.Write(" slash dmg.");
        return value;
    }
    /// <summary>
    /// Attack för shaman (Klasser som använder spelldmg)   //Denna rad definierar Metoden så att man vet vad den gör med text
    /// </summary>
    /// <param name="hero"></param>                 
    /// <returns></returns>
    public int AttackSpellCasters(Hero hero)        //Här skall det modifieras så shaman gör Heal efter varje attack och skadan som görs är Fireball attack
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)damage - (int)hero.armor;
        maxDamage += (int)damage - (int)hero.armor;
        int value = random.Next(minDamage, maxDamage);
        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" fire dmg.");

        if (this.hp < this.maxHp)
        {
            int randomHealing = random.Next(this.minHealing, this.maxHealing);
            this.hp += Convert.ToInt32(this.healing);
            Console.Write($" Och healar sig själv med ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.healing);
            Console.ResetColor();
            Console.Write("hp");
        }

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
        this.damage = 3;
        this.speed = 1;
        this.armor = 0.65;
        this.hp = this.hp - 2;

        GenerateName();        
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.damage + (styrka * 1.1);
        this.speed = this.speed + (agility * 1.05);
        this.armor = this.armor + (agility / 2) * 1.01;
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
        this.damage = 1;
        this.speed = 0.9;
        this.armor = 1;

        this.name = "Shaman-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.damage + (intelligence * 0.8);
        this.healing = this.healing + (intelligence * 1);
        this.speed = this.speed + (agility * 1.05);
        this.armor = this.armor + (agility / 2) * 1.01;
    }

    public virtual int Attack(Hero hero)
    {
        return base.AttackSpellCasters(hero);   // Specifik attack för Shaman        
    }
    
}

public class Grunt : OrcBase
{
    public Grunt()
    {
        this.damage = 1;
        this.speed = 0.5;
        this.armor = 2;
        this.hp += 2;
        

        this.name = "Grunt-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.damage + (styrka * 0.9);
        this.speed = this.speed + (agility * 1.00);
        this.armor = this.armor + (agility / 2) * 1.01;
    }

    public virtual int Attack(Hero hero)
    {

        return base.Attack(hero);      // Specifik attack för Grunt        
    }
}



