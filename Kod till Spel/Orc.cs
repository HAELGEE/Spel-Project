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
    public Hero hero { get; set; }
    public string name { get; set; }
    public int level { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 1;
    public int agility { get; set; } = 1;
    public int stamina { get; set; } = 1;
    public int intelligence { get; set; } = 1;
    public int mana { get; set; } = 10;
    public int charm { get; set; } = 1;
    public double damage { get; set; }
    public double baseDamage { get; set; }
    public double speed { get; set; }
    public double baseSpeed { get; set; }
    public double armor { get; set; }
    public double baseArmor { get; set; }
    public double resistance { get; set; } = 1;
    public double baseResistance { get; set; } = 1;
    public double healing { get; set; } = 2;
    public int minHealing { get; set; } = 1;
    public int maxHealing { get; set; } = 3;

    public OrcBase(Hero hero)
    {
        this.hero = hero;
    }


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
            levelOver = Hero.savedLevel + 3;     //Om hero level är över orc level tar man hero level + 3 för att få "levelOver"

            level = random.Next(levelUnder, levelOver);    //Randomiserar vilken level orc skall bli
        }

        if (this.level > 1)     //Om orc level är över 1 tar man och sparar den i levelLeft -1
        {
            int levelLeft = this.level - 1;


            for (int i = 0; i < levelLeft; i++)
            {

                this.hp += 3;              //lägger till 3 i hp
                this.maxHp += 3;           //lägger till 3 i maxHp
                this.minHealing++;      //lägger till 1 i minimum Healing
                this.maxHealing++;      //Lägger till 1 i maximum Healing

                int statIncrease = random.Next(0, 3);
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
                            this.intelligence++;   //Om lottningen stannade här +1 i intelligence
                            break;
                        }
                    case 3:
                        {
                            this.stamina++;   // Om lottningen stannade här + 1 i stamina
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


    public Random random = new Random();

    public virtual int Attack(Hero hero)
    {
        int value = 0;
        if (name.Contains("Dungeon"))       //Ökar skada för Dungeon klass mobs
        {
            int minDamage = 3;
            int maxDamage = 11;
            minDamage += (int)damage - (int)hero.armor;
            maxDamage += (int)damage - (int)hero.armor;
            value = random.Next(minDamage, maxDamage);
        }
        else
        {
            int minDamage = 1;
            int maxDamage = 11;
            minDamage += (int)damage - (int)hero.armor;
            maxDamage += (int)damage - (int)hero.armor;
            value = random.Next(minDamage, maxDamage);
        }

        if (value < 0)
        {
            value = 0;
        }
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
    public virtual int AttackSpellCasters(Hero hero)        //Här skall det modifieras så shaman gör Heal efter varje attack och skadan som görs är Fireball attack
    {
        int value = 0;
        if (name.Contains("Dungeon"))       //Ökar skada för Dungeon klass mobs
        {
            int minDamage = 3;
            int maxDamage = 11;
            minDamage += (int)damage - (int)hero.resistance;
            maxDamage += (int)damage - (int)hero.resistance;
            value = random.Next(minDamage, maxDamage);
        }
        else
        {
            int minDamage = 1;
            int maxDamage = 11;
            minDamage += (int)damage - (int)hero.resistance;
            maxDamage += (int)damage - (int)hero.resistance;
            value = random.Next(minDamage, maxDamage);
        }

        if (value < 0)
        {
            value = 0;
        }
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
    public virtual int BossAttack(Hero hero)
    {
        int minDamage = 2;
        int maxDamage = 11;
        minDamage += (int)damage - (int)hero.armor;
        maxDamage += (int)damage - (int)hero.armor;
        int value = random.Next(minDamage, maxDamage);
        if (value < 0)
        {
            value = 0;
        }
        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" slash dmg.");
        return value;
    }

    public virtual void GenerateName()
    {
        this.name = "Orc-" + random.Next(1, 3340);
    }
}

public class Orc : OrcBase
{
    public Orc(Hero hero) : base(hero)
    {
        this.damage = 4;
        this.speed = 2;
        this.armor = 1.5;
        this.hp = this.hp - 2;
        this.baseArmor = 1.5;
        this.baseSpeed = 2;
        this.baseDamage = 4;
        this.baseResistance = 1;

        GenerateName();        
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.baseDamage + (styrka * 1.3);
        this.speed = this.baseSpeed + (agility * 1.15);
        this.armor = this.baseArmor + (agility * 0.26);
        this.resistance = this.baseResistance + (intelligence * 0.2);
    }

    public override int Attack(Hero hero)
    {
        return base.Attack(hero);      // Specifik attack för Orc        
    }
}
public class Shaman : OrcBase
{
    public Shaman(Hero hero) : base(hero)
    {
        this.damage = 1.5;
        this.speed = 1.2;
        this.armor = 2;
        this.healing = 2;
        this.baseArmor = 2;
        this.baseSpeed = 1.2;
        this.baseDamage = 1.5;
        this.baseResistance = 2;

        this.name = "Shaman-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.baseDamage + (intelligence * 1);
        this.healing = this.healing + (Math.Round(intelligence * 0.9));
        this.speed = this.baseSpeed + (agility * 1.15);
        this.armor = this.baseArmor + (agility * 0.26);
        this.resistance = this.baseResistance + (intelligence * 0.95);
    }

    public override int Attack(Hero hero)
    {
        return base.AttackSpellCasters(hero);   // Specifik attack för Shaman        
    }

}

public class Grunt : OrcBase
{
    public Grunt(Hero hero) : base(hero)
    {
        this.damage = 1.2;
        this.speed = 0.7;
        this.armor = 5.5;
        this.hp += 10;
        this.baseArmor = 5.5;
        this.baseSpeed = 0.7;
        this.baseDamage = 1.2;
        this.baseResistance = 2.5;

        this.name = "Grunt-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        this.damage = this.baseDamage + (styrka * 1);
        this.speed = this.baseSpeed + (agility * 1.10);
        this.armor = this.baseArmor + (agility * 0.31);
        this.resistance = this.baseResistance + (intelligence * 0.25);

    }

    public override int Attack(Hero hero)
    {

        return base.Attack(hero);      // Specifik attack för Grunt        
    }
}
public class Boss : OrcBase
{
    public Boss(Hero hero) : base(hero)
    {
        this.hp = 60; // Bossar har mer hälsa
        this.damage = 4;
        this.speed = 1.5;
        this.armor = 3.5;
        this.baseArmor = 3.5;
        this.baseSpeed = 1.5;
        this.baseDamage = 4;
        this.baseResistance = 3;

        this.name = "DungeonBoss-" + random.Next(1, 6666);

        this.damage = this.baseDamage + (styrka * 1.05);
        this.speed = this.baseSpeed + (agility * 1.10);
        this.armor = this.baseArmor + (agility * 0.35);
        this.resistance = this.baseResistance + (intelligence * 0.35);
    }
    public override int Attack(Hero hero)
    {
        return base.BossAttack(hero);      // Specifik attack för Boss       
    }
}
public class DungeonOrc : OrcBase
{
    public DungeonOrc(Hero hero) : base(hero)
    {
        this.hp = 30;
        this.damage = 4;
        this.speed = 2.2;
        this.armor = 1.2;        
        this.baseArmor = 1.5;
        this.baseSpeed = 2;
        this.baseDamage = 4;
        this.baseResistance = 1;

        this.name = "DungeonOrc-" + random.Next(1, 3340);

        this.damage = this.damage + (styrka * 1.3);
        this.speed = this.speed + (agility * 1.13);
        this.armor = this.armor + (agility * 0.22);
        this.resistance = this.resistance + (intelligence * 0.2);
    }

    public override int Attack(Hero hero)
    {
        return base.Attack(hero);      // Specifik attack för Orc        
    }
}
public class DungeonShaman : OrcBase
{
    public DungeonShaman(Hero hero) : base(hero)
    {
        this.hp = 35;
        this.damage = 2;
        this.healing = 1.2;
        this.speed = 1.3;
        this.armor = 2;
        this.baseArmor = 1.5;
        this.baseSpeed = 2;
        this.baseDamage = 4;
        this.baseResistance = 1;

        this.name = "DungeonShaman-" + random.Next(1, 3340);

        this.damage = this.damage + (intelligence * 1);
        this.healing = this.healing + (Math.Round(intelligence * 0.95));
        this.speed = this.speed + (agility * 1.15);
        this.armor = this.armor + (agility * 0.26);
        this.resistance = this.resistance + (intelligence * 0.2);
    }

    public override int Attack(Hero hero)
    {
        return base.AttackSpellCasters(hero);   // Specifik attack för Shaman        
    }

}

public class DungeonGrunt : OrcBase
{
    public DungeonGrunt(Hero hero) : base(hero)
    {
        this.hp = 45;
        this.damage = 1.5;
        this.speed = 0.8;
        this.armor = 3;
        this.baseArmor = 1.5;
        this.baseSpeed = 2;
        this.baseDamage = 4;
        this.baseResistance = 1;

        this.name = "DungeonGrunt-" + random.Next(1, 3340);


        this.damage = this.damage + (styrka * 1);
        this.speed = this.speed + (agility * 1.10);
        this.armor = this.armor + (agility * 0.28);
        this.resistance = this.resistance + (intelligence * 0.25);

    }

    public override int Attack(Hero hero)
    {

        return base.Attack(hero);      // Specifik attack för Grunt        
    }
}



