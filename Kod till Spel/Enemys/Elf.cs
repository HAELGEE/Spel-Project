using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel.Enemys;
public class Elf
{    
    public Enemy Stats { get; set; }  

    public Elf(Hero hero, string clas)
    {
        //this.hero = hero;
        Stats = Stats;
        Stats.name = "Elf";
    }

//    public void LevelCheck(Hero hero)
//    {
//        Random random = new Random();

//        int levelOver = hero.level + 3;
//        int levelUnder = hero.level > 3 ? hero.level - 2 : 1;

//        stats.level = random.Next(levelUnder, levelOver);

//        for (int i = 0; i < stats.level; i++)
//        {

//            stats.hp += 3;              //lägger till 3 i hp
//            stats.maxHp += 3;           //lägger till 3 i maxHp
//            stats.minHealing++;      //lägger till 1 i minimum Healing
//            stats.maxHealing++;      //Lägger till 1 i maximum Healing
            
//            switch (random.Next(0, 3))
//            {
//                case 0:
//                    {
//                        stats.styrka++;      //Om lottningen stannade här +1 i styrka
//                        break;
//                    }
//                case 1:
//                    {
//                        stats.agility++;     //Om lottningen stannade här +1 i agility
//                        break;
//                    }
//                case 2:
//                    {
//                        stats.intelligence++;   //Om lottningen stannade här +1 i intelligence
//                        break;
//                    }
//                case 3:
//                    {
//                        stats.stamina++;   // Om lottningen stannade här + 1 i stamina
//                        break;
//                    }
//            }
//        }

//    }
//    public void Green(string value)
//    {
//        Console.ForegroundColor = ConsoleColor.Green;
//        Console.Write(value);
//        Console.ResetColor();
//    }
//    public void Red(string value)
//    {
//        Console.ForegroundColor = ConsoleColor.Red;
//        Console.Write(value);
//        Console.ResetColor();
//    }
//    public void Cyan(int value)
//    {
//        Console.ForegroundColor = ConsoleColor.Cyan;
//        Console.Write(value);
//        Console.ResetColor();
//    }


//    public Random random = new Random();

//    public virtual int Attack(Hero hero)
//    {
//        int value = 0;
//        if (stats.name.Contains("Dungeon"))       //Ökar skada för Dungeon klass mobs
//        {
//            int minDamage = 3;
//            int maxDamage = 11;
//            minDamage += (int)(stats.damage - hero.armor);
//            maxDamage += (int)(stats.damage - hero.armor);
//            value = random.Next(minDamage, maxDamage);
//        }
//        else
//        {
//            int minDamage = 1;
//            int maxDamage = 7;
//            minDamage += (int)(stats.damage - hero.armor);
//            maxDamage += (int)(stats.damage - hero.armor);
//            value = random.Next(minDamage, maxDamage);
//        }

//        if (value < 0)
//        {
//            value = 0;
//        }
//        Red(stats.name);                  //lägger in färgen RÖD på orc
//        Console.Write(" gjorde ");
//        Cyan(value);                //Lägger till färgen CYAN på DMG
//        Console.Write(" slash dmg.");
//        return value;
//    }
//    /// <summary>
//    /// Attack för shaman (Klasser som använder spelldmg)   //Denna rad definierar Metoden så att man vet vad den gör med text
//    /// </summary>
//    /// <param name="hero"></param>                 
//    /// <returns></returns>
//    public virtual int AttackSpellCasters(Hero hero)        //Här skall det modifieras så shaman gör Heal efter varje attack och skadan som görs är Fireball attack
//    {
//        int value = 0;
//        if (stats.name.Contains("Dungeon"))       //Ökar skada för Dungeon klass mobs
//        {
//            int minDamage = 3;
//            int maxDamage = 11;
//            minDamage += (int)(stats.damage - hero.resistance);
//            maxDamage += (int)(stats.damage - hero.resistance);
//            value = random.Next(minDamage, maxDamage);
//        }
//        else
//        {
//            int minDamage = 1;
//            int maxDamage = 7;
//            minDamage += (int)(stats.damage - hero.resistance);
//            maxDamage += (int)(stats.damage - hero.resistance);
//            value = random.Next(minDamage, maxDamage);
//        }

//        if (value < 0)
//        {
//            value = 0;
//        }
//        Red(stats.name);                  //lägger in färgen RÖD på orc
//        Console.Write(" gjorde ");
//        Cyan(value);                //Lägger till färgen CYAN på DMG
//        Console.Write(" fire dmg.");

//        if (stats.hp < stats.maxHp)
//        {
//            int randomHealing = random.Next(stats.minHealing, stats.maxHealing);
//            stats.hp += Convert.ToInt32(stats.healing);
//            Console.Write($" Och healar sig själv med ");
//            Console.ForegroundColor = ConsoleColor.Yellow;
//            Console.Write(stats.healing);
//            Console.ResetColor();
//            Console.Write("hp");
//        }

//        return value;
//    }
//    public virtual int BossAttack(Hero hero)
//    {
//        int minDamage = 2;
//        int maxDamage = 9;
//        minDamage += (int)(stats.damage - hero.armor);
//        maxDamage += (int)(stats.damage - hero.armor);
//        int value = random.Next(minDamage, maxDamage);
//        if (value < 0)
//        {
//            value = 0;
//        }
//        Red(stats.name);                  //lägger in färgen RÖD på orc
//        Console.Write(" gjorde ");
//        Cyan(value);                //Lägger till färgen CYAN på DMG
//        Console.Write(" slash dmg.");
//        return value;
//    }

//    public virtual void GenerateName()
//    {
//        stats.name = "Sylvastra-" + random.Next(1, 3340);
//    }
//}
//public class Sylvastra : Elf
//{
//    public Sylvastra(Hero hero) : base(hero)
//    {
//        stats.damage = 4;
//        stats.speed = 2;
//        stats.armor = 1.5;
//        stats.hp = stats.hp - 2;
//        stats.baseArmor = 1.5;
//        stats.baseSpeed = 2;
//        stats.baseDamage = 4;
//        stats.baseResistance = 1;

//        GenerateName();
//        LevelCheck(hero);   //Kollar vilken Level Hero är på

//        stats.damage = stats.baseDamage + stats.styrka * 1.3;
//        stats.speed = stats.baseSpeed + stats.agility * 1.15;
//        stats.armor = stats.baseArmor + stats.agility * 0.26;
//        stats.resistance = stats.baseResistance + stats.intelligence * 0.2;
//    }

//    public override int Attack(Hero hero)
//    {
//        return base.Attack(hero);      // Specifik attack för Orc        
//    }
//}
//public class Elowen : Elf
//{
//    public Elowen(Hero hero) : base(hero)
//    {
//        stats.damage = 1.5;
//        stats.speed = 1.2;
//        stats.armor = 2;
//        stats.healing = 2;
//        stats.baseArmor = 2;
//        stats.baseSpeed = 1.2;
//        stats.baseDamage = 1.5;
//        stats.baseResistance = 2;

//        stats.name = "Elowen-" + random.Next(1, 3340);
//        LevelCheck(hero);   //Kollar vilken Level Hero är på

//        stats.damage = stats.baseDamage + stats.intelligence * 1;
//        stats.healing = stats.healing + Math.Round(stats.intelligence * 0.9);
//        stats.speed = stats.baseSpeed + stats.agility * 1.15;
//        stats.armor = stats.baseArmor + stats.agility * 0.26;
//        stats.resistance = stats.baseResistance + stats.intelligence * 0.95;
//    }

//    public override int Attack(Hero hero)
//    {
//        return base.AttackSpellCasters(hero);   // Specifik attack för Shaman        
//    }

//}

//public class Tharion : Elf
//{
//    public Tharion(Hero hero) : base(hero)
//    {
//        stats.damage = 1.2;
//        stats.speed = 0.7;
//        stats.armor = 5.5;
//        stats.hp += 10;
//        stats.baseArmor = 5.5;
//        stats.baseSpeed = 0.7;
//        stats.baseDamage = 1.2;
//        stats.baseResistance = 2.5;

//        stats.name = "Tharion-" + random.Next(1, 3340);
//        LevelCheck(hero);   //Kollar vilken Level Hero är på

//        stats.damage = stats.baseDamage + stats.styrka * 1;
//        stats.speed = stats.baseSpeed + stats.agility * 1.10;
//        stats.armor = stats.baseArmor + stats.agility * 0.31;
//        stats.resistance = stats.baseResistance + stats.intelligence * 0.25;

//    }

//    public override int Attack(Hero hero)
//    {

//        return base.Attack(hero);      // Specifik attack för Grunt        
//    }
//}
//public class ElfBoss : Elf
//{
//    public ElfBoss(Hero hero) : base(hero)
//    {
//        stats.hp = 60; // Bossar har mer hälsa
//        stats.damage = 4;
//        stats.speed = 1.5;
//        stats.armor = 3.5;
//        stats.baseArmor = 3.5;
//        stats.baseSpeed = 1.5;
//        stats.baseDamage = 4;
//        stats.baseResistance = 3;

//        stats.name = "DungeonElfBoss-" + random.Next(1, 6666);

//        stats.damage = stats.baseDamage + stats.styrka * 1.05;
//        stats.speed = stats.baseSpeed + stats.agility * 1.10;
//        stats.armor = stats.baseArmor + stats.agility * 0.35;
//        stats.resistance = stats.baseResistance + stats.intelligence * 0.35;
//    }
//    public override int Attack(Hero hero)
//    {
//        return base.BossAttack(hero);      // Specifik attack för Boss       
//    }
//}
//public class DungeonSylvastra : Elf
//{
//    public DungeonSylvastra(Hero hero) : base(hero)
//    {
//        stats.hp = 30;
//        stats.damage = 4;
//        stats.speed = 2.2;
//        stats.armor = 1.2;
//        stats.baseArmor = 1.5;
//        stats.baseSpeed = 2;
//        stats.baseDamage = 4;
//        stats.baseResistance = 1;

//        stats.name = "DungeonSylvastra-" + random.Next(1, 3340);

//        stats.damage = stats.damage + stats.styrka * 1.3;
//        stats.speed = stats.speed + stats.agility * 1.13;
//        stats.armor = stats.armor + stats.agility * 0.22;
//        stats.resistance = stats.resistance + stats.intelligence * 0.2;
//    }

//    public override int Attack(Hero hero)
//    {
//        return base.Attack(hero);      // Specifik attack för Orc        
//    }
//}
//public class DungeonElowen : Elf
//{
//    public DungeonElowen(Hero hero) : base(hero)
//    {
//        stats.hp = 35;
//        stats.damage = 2;
//        stats.healing = 1.2;
//        stats.speed = 1.3;
//        stats.armor = 2;
//        stats.baseArmor = 1.5;
//        stats.baseSpeed = 2;
//        stats.baseDamage = 4;
//        stats.baseResistance = 1;

//        stats.name = "DungeonElowen-" + random.Next(1, 3340);

//        stats.damage = stats.damage + stats.intelligence * 1;
//        stats.healing = stats.healing + Math.Round(stats.intelligence * 0.95);
//        stats.speed = stats.speed + stats.agility * 1.15;
//        stats.armor = stats.armor + stats.agility * 0.26;
//        stats.resistance = stats.resistance + stats.intelligence * 0.2;
//    }

//    public override int Attack(Hero hero)
//    {
//        return base.AttackSpellCasters(hero);   // Specifik attack för Shaman        
//    }

//}

//public class DungeonTharion : Elf
//{
//    public DungeonTharion(Hero hero) : base(hero)
//    {
//        stats.hp = 45;
//        stats.damage = 1.5;
//        stats.speed = 0.8;
//        stats.armor = 3;
//        stats.baseArmor = 1.5;
//        stats.baseSpeed = 2;
//        stats.baseDamage = 4;
//        stats.baseResistance = 1;

//        stats.name = "DungeonTharion-" + random.Next(1, 3340);


//        stats.damage = stats.damage + stats.styrka * 1;
//        stats.speed = stats.speed + stats.agility * 1.10;
//        stats.armor = stats.armor + stats.agility * 0.28;
//        stats.resistance = stats.resistance + stats.intelligence * 0.25;

//    }

//    public override int Attack(Hero hero)
//    {

//        return base.Attack(hero);      // Specifik attack för Grunt        
//    }
}
