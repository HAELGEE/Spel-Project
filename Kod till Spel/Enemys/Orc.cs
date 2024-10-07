using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using System.IO;
using System.Text.Json;
using System.Runtime.Intrinsics.Arm;
using System.Xml.Linq;

namespace Kod_till_Spel.Enemys;

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

        if (hero.level >= level)       //Kollar vilken level Hero är på och jämför med orc level (this.level)
        {
            levelOver = hero.level + 3;     //Om hero level är över orc level tar man hero level + 3 för att få "levelOver"

            if (hero.level > 3)             //Kollar om Hero level är över 3
            {
                levelUnder = hero.level - 2;    //Om hero level är över 3 tar man av 2 så får man en motståndare som har max 2 level under och max 2 level över hero
            }

            level = random.Next(levelUnder, levelOver);    //Randomiserar vilken level orc skall bli
        }
        else
        {
            levelOver = Hero.savedLevel + 3;     //Om hero level är över orc level tar man hero level + 3 för att få "levelOver"

            level = random.Next(levelUnder, levelOver);    //Randomiserar vilken level orc skall bli
        }

        if (level > 1)     //Om orc level är över 1 tar man och sparar den i levelLeft -1
        {
            int levelLeft = level - 1;


            for (int i = 0; i < levelLeft; i++)
            {

                hp += 3;              //lägger till 3 i hp
                maxHp += 3;           //lägger till 3 i maxHp
                minHealing++;      //lägger till 1 i minimum Healing
                maxHealing++;      //Lägger till 1 i maximum Healing

                int statIncrease = random.Next(0, 3);
                switch (statIncrease)
                {
                    case 0:
                        {
                            styrka++;      //Om lottningen stannade här +1 i styrka
                            break;
                        }
                    case 1:
                        {
                            agility++;     //Om lottningen stannade här +1 i agility
                            break;
                        }
                    case 2:
                        {
                            intelligence++;   //Om lottningen stannade här +1 i intelligence
                            break;
                        }
                    case 3:
                        {
                            stamina++;   // Om lottningen stannade här + 1 i stamina
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
            int maxDamage = 7;
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
            int maxDamage = 7;
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

        if (hp < maxHp)
        {
            int randomHealing = random.Next(minHealing, maxHealing);
            hp += Convert.ToInt32(healing);
            Console.Write($" Och healar sig själv med ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(healing);
            Console.ResetColor();
            Console.Write("hp");
        }

        return value;
    }
    public virtual int BossAttack(Hero hero)
    {
        int minDamage = 2;
        int maxDamage = 9;
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
        name = "Orc-" + random.Next(1, 3340);
    }
}

public class Orc : OrcBase
{
    public Orc(Hero hero) : base(hero)
    {
        damage = 4;
        speed = 2;
        armor = 1.5;
        hp = hp - 2;
        baseArmor = 1.5;
        baseSpeed = 2;
        baseDamage = 4;
        baseResistance = 1;

        GenerateName();
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        damage = baseDamage + styrka * 1.3;
        speed = baseSpeed + agility * 1.15;
        armor = baseArmor + agility * 0.26;
        resistance = baseResistance + intelligence * 0.2;
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
        damage = 1.5;
        speed = 1.2;
        armor = 2;
        healing = 2;
        baseArmor = 2;
        baseSpeed = 1.2;
        baseDamage = 1.5;
        baseResistance = 2;

        name = "Shaman-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        damage = baseDamage + intelligence * 1;
        healing = healing + Math.Round(intelligence * 0.9);
        speed = baseSpeed + agility * 1.15;
        armor = baseArmor + agility * 0.26;
        resistance = baseResistance + intelligence * 0.95;
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
        damage = 1.2;
        speed = 0.7;
        armor = 5.5;
        hp += 10;
        baseArmor = 5.5;
        baseSpeed = 0.7;
        baseDamage = 1.2;
        baseResistance = 2.5;

        name = "Grunt-" + random.Next(1, 3340);
        LevelCheck(hero);   //Kollar vilken Level Hero är på

        damage = baseDamage + styrka * 1;
        speed = baseSpeed + agility * 1.10;
        armor = baseArmor + agility * 0.31;
        resistance = baseResistance + intelligence * 0.25;

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
        hp = 60; // Bossar har mer hälsa
        damage = 4;
        speed = 1.5;
        armor = 3.5;
        baseArmor = 3.5;
        baseSpeed = 1.5;
        baseDamage = 4;
        baseResistance = 3;

        name = "DungeonBoss-" + random.Next(1, 6666);

        damage = baseDamage + styrka * 1.05;
        speed = baseSpeed + agility * 1.10;
        armor = baseArmor + agility * 0.35;
        resistance = baseResistance + intelligence * 0.35;
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
        hp = 30;
        damage = 4;
        speed = 2.2;
        armor = 1.2;
        baseArmor = 1.5;
        baseSpeed = 2;
        baseDamage = 4;
        baseResistance = 1;

        name = "DungeonOrc-" + random.Next(1, 3340);

        damage = damage + styrka * 1.3;
        speed = speed + agility * 1.13;
        armor = armor + agility * 0.22;
        resistance = resistance + intelligence * 0.2;
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
        hp = 35;
        damage = 2;
        healing = 1.2;
        speed = 1.3;
        armor = 2;
        baseArmor = 1.5;
        baseSpeed = 2;
        baseDamage = 4;
        baseResistance = 1;

        name = "DungeonShaman-" + random.Next(1, 3340);

        damage = damage + intelligence * 1;
        healing = healing + Math.Round(intelligence * 0.95);
        speed = speed + agility * 1.15;
        armor = armor + agility * 0.26;
        resistance = resistance + intelligence * 0.2;
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
        hp = 45;
        damage = 1.5;
        speed = 0.8;
        armor = 3;
        baseArmor = 1.5;
        baseSpeed = 2;
        baseDamage = 4;
        baseResistance = 1;

        name = "DungeonGrunt-" + random.Next(1, 3340);


        damage = damage + styrka * 1;
        speed = speed + agility * 1.10;
        armor = armor + agility * 0.28;
        resistance = resistance + intelligence * 0.25;

    }

    public override int Attack(Hero hero)
    {

        return base.Attack(hero);      // Specifik attack för Grunt        
    }
}



