using Kod_till_Spel.Menus;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using static Kod_till_Spel.Enemys.Enemy;

namespace Kod_till_Spel.Enemys;
public class Enemy
{
    public Hero hero { get; set; }
    public string name { get; set; }
    public int level { get; set; } = 1;
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

    public static Random random = new Random();

    public Enemy(Hero hero) : this()
    {
        this.hero = hero;
    }
    public Enemy()
    {
    }

    public void LevelCheck(Hero hero)
    {

        int levelOver = hero.level + 3;
        int levelUnder = hero.level > 3 ? hero.level - 2 : 1;

        level = random.Next(levelUnder, levelOver);

        for (int i = 0; i < level; i++)
        {

            hp += 3;              //lägger till 3 i hp
            maxHp += 3;           //lägger till 3 i maxHp
            minHealing++;      //lägger till 1 i minimum Healing
            maxHealing++;      //Lägger till 1 i maximum Healing

            switch (random.Next(0, 3))
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
    public void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(CenterText.CenterTextsHeroName(value));
        Console.ResetColor();
    }
    public void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(CenterText.CenterTextsEnemyName(value));
        Console.ResetColor();
    }
    public void RedSpellCasters(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.Write(value);
        Console.Write(CenterText.CenterTextsEnemySpellCasters(value));
        Console.ResetColor();
    }
    public void RedSpellCastersNoHealing(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.Write(CenterText.CenterTextsss(value));
        Console.Write(CenterText.CenterTextsEnemySpellCastersWhenNoHealing(value));
        Console.ResetColor();
    }
    public void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(value);
        Console.ResetColor();
    }
    public void CyanNotCentered(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(value);
        Console.ResetColor();
    }

    public virtual int Attack(Hero hero)
    {
        int value = 0;
        if (name.Contains("Dungeon"))       //Ökar skada för Dungeon klass mobs
        {
            int minDamage = 3;
            int maxDamage = 11;
            minDamage += (int)(damage - hero.armor);
            maxDamage += (int)(damage - hero.armor);
            value = random.Next(minDamage, maxDamage);
        }
        else
        {
            int minDamage = 1;
            int maxDamage = 7;
            minDamage += (int)(damage - hero.armor);
            maxDamage += (int)(damage - hero.armor);
            value = random.Next(minDamage, maxDamage);
        }

        if (value < 0)
            value = 0;

        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" slash dmg.");

        return value;
    }

    /// <summary>
    /// Attack för Klasser som använder spelldmg   //Denna rad definierar Metoden så att man vet vad den gör med text
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
            minDamage += (int)(damage - hero.resistance);
            maxDamage += (int)(damage - hero.resistance);
            value = random.Next(minDamage, maxDamage);
        }
        else
        {
            int minDamage = 1;
            int maxDamage = 7;
            minDamage += (int)(damage - hero.resistance);
            maxDamage += (int)(damage - hero.resistance);
            value = random.Next(minDamage, maxDamage);
        }

        // så att man inte gör minus skada, utan 0 istället
        if (value < 0)
        {
            value = 0;
        }

        if (hp < maxHp)
        {
            if (hp > maxHp) 
                hp = maxHp;

            RedSpellCasters(name);                  //lägger in färgen RÖD på orc
            Console.Write(" gjorde ");
            Cyan(value);                //Lägger till färgen CYAN på DMG
            Console.Write(" fire dmg.");
            int randomHealing = random.Next(minHealing, maxHealing);
            hp += Convert.ToInt32(healing);
            Console.Write($" Och healar sig själv med ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(healing);
            Console.ResetColor();
            Console.Write("hp");
        }
        else
        {
        RedSpellCastersNoHealing(name);      //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" fire dmg.");
        }

        return value;
    }
    public virtual int BossAttack(Hero hero)
    {
        int minDamage = 2;
        int maxDamage = 9;
        minDamage += (int)(damage - hero.armor);
        maxDamage += (int)(damage - hero.armor);
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

    public class Orc : Enemy
    {
        public Orc(Hero hero)
        {
            damage = 4;
            speed = 2;
            armor = 1.5;
            hp = hp - 2;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;


            name = "Orc-" + random.Next(1, 3340);
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
    public class Shaman : Enemy
    {
        public Shaman(Hero hero)
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
    public class Grunt : Enemy
    {
        public Grunt(Hero hero)
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
    public class Boss : Enemy
    {
        public Boss(Hero hero)
        {
            hp = 60; // Bossar har mer hälsa
            damage = 4;
            speed = 1.5;
            armor = 3.5;
            baseArmor = 3.5;
            baseSpeed = 1.5;
            baseDamage = 4;
            baseResistance = 3;

            name = "DungeonOrcBoss-" + random.Next(1, 6666);

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
    public class DungeonOrc : Enemy
    {
        public DungeonOrc(Hero hero)
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
    public class DungeonShaman : Enemy
    {
        public DungeonShaman(Hero hero)
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
    public class DungeonGrunt : Enemy
    {
        public DungeonGrunt(Hero hero)
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
    public class Sylvastra : Enemy
    {
        public Sylvastra(Hero hero)
        {
            damage = 4;
            speed = 2;
            armor = 1.5;
            hp = hp - 2;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "Sylvastra-" + random.Next(1, 3340);
            LevelCheck(hero);   //Kollar vilken Level Hero är på

            damage = baseDamage + styrka * 1.3;
            speed = baseSpeed + agility * 1.15;
            armor = baseArmor + agility * 0.26;
            resistance = baseResistance + intelligence * 0.2;
        }

        public override int Attack(Hero hero)
        {
            return base.Attack(hero);      // Specifik attack för Sylvastra        
        }
    }
    public class Elowen : Enemy
    {
        public Elowen(Hero hero)
        {
            damage = 1.5;
            speed = 1.2;
            armor = 2;
            healing = 2;
            baseArmor = 2;
            baseSpeed = 1.2;
            baseDamage = 1.5;
            baseResistance = 2;

            name = "Elowen-" + random.Next(1, 3340);
            LevelCheck(hero);   //Kollar vilken Level Hero är på

            damage = baseDamage + intelligence * 1;
            healing = healing + Math.Round(intelligence * 0.9);
            speed = baseSpeed + agility * 1.15;
            armor = baseArmor + agility * 0.26;
            resistance = baseResistance + intelligence * 0.95;
        }

        public override int Attack(Hero hero)
        {
            return base.AttackSpellCasters(hero);   // Specifik attack för Elowen        
        }

    }
    public class Tharion : Enemy
    {
        public Tharion(Hero hero)
        {
            damage = 1.2;
            speed = 0.7;
            armor = 5.5;
            hp += 10;
            baseArmor = 5.5;
            baseSpeed = 0.7;
            baseDamage = 1.2;
            baseResistance = 2.5;

            name = "Tharion-" + random.Next(1, 3340);
            LevelCheck(hero);   //Kollar vilken Level Hero är på

            damage = baseDamage + styrka * 1;
            speed = baseSpeed + agility * 1.10;
            armor = baseArmor + agility * 0.31;
            resistance = baseResistance + intelligence * 0.25;
        }

        public override int Attack(Hero hero)
        {

            return base.Attack(hero);      // Specifik attack för Tharion        
        }
    }
    public class ElfBoss : Enemy
    {
        public ElfBoss(Hero hero)
        {
            hp = 60; // Bossar har mer hälsa
            damage = 4;
            speed = 1.5;
            armor = 3.5;
            baseArmor = 3.5;
            baseSpeed = 1.5;
            baseDamage = 4;
            baseResistance = 3;

            name = "DungeonElfBoss-" + random.Next(1, 6666);

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
    public class DungeonSylvastra : Enemy
    {
        public DungeonSylvastra(Hero hero)
        {
            hp = 30;
            damage = 4;
            speed = 2.2;
            armor = 1.2;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "DungeonSylvastra-" + random.Next(1, 3340);

            damage = damage + styrka * 1.3;
            speed = speed + agility * 1.13;
            armor = armor + agility * 0.22;
            resistance = resistance + intelligence * 0.2;
        }

        public override int Attack(Hero hero)
        {
            return base.Attack(hero);      // Specifik attack för DungeonSylvastra        
        }
    }
    public class DungeonElowen : Enemy
    {
        public DungeonElowen(Hero hero)
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

            name = "DungeonElowen-" + random.Next(1, 3340);

            damage = damage + intelligence * 1;
            healing = healing + Math.Round(intelligence * 0.95);
            speed = speed + agility * 1.15;
            armor = armor + agility * 0.26;
            resistance = resistance + intelligence * 0.2;
        }

        public override int Attack(Hero hero)
        {
            return base.AttackSpellCasters(hero);   // Specifik attack för DungeonElowen        
        }

    }
    public class DungeonTharion : Enemy
    {
        public DungeonTharion(Hero hero)
        {
            hp = 45;
            damage = 1.5;
            speed = 0.8;
            armor = 3;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "DungeonTharion-" + random.Next(1, 3340);


            damage = damage + styrka * 1;
            speed = speed + agility * 1.10;
            armor = armor + agility * 0.28;
            resistance = resistance + intelligence * 0.25;
        }

        public override int Attack(Hero hero)
        {

            return base.Attack(hero);      // Specifik attack för DungeonTharion      
        }
    }
    public class Wraithon : Enemy
    {
        public Wraithon(Hero hero)
        {
            damage = 4;
            speed = 2;
            armor = 1.5;
            hp = hp - 2;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "Wraithon-" + random.Next(1, 3340);
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
    public class Hauntress : Enemy
    {
        public Hauntress(Hero hero)
        {
            damage = 1.5;
            speed = 1.2;
            armor = 2;
            healing = 2;
            baseArmor = 2;
            baseSpeed = 1.2;
            baseDamage = 1.5;
            baseResistance = 2;

            name = "Hauntress-" + random.Next(1, 3340);
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
    public class Gravemourn : Enemy
    {
        public Gravemourn(Hero hero)
        {
            damage = 1.2;
            speed = 0.7;
            armor = 5.5;
            hp += 10;
            baseArmor = 5.5;
            baseSpeed = 0.7;
            baseDamage = 1.2;
            baseResistance = 2.5;

            name = "Gravemourn-" + random.Next(1, 3340);
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
    public class GhostBoss : Enemy
    {
        public GhostBoss(Hero hero)
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
            return base.BossAttack(hero);      // Specifik attack för DungeonBoss       
        }
    }
    public class DungeonWraithon : Enemy
    {
        public DungeonWraithon(Hero hero)
        {
            hp = 30;
            damage = 4;
            speed = 2.2;
            armor = 1.2;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "DungeonWraithon-" + random.Next(1, 3340);

            damage = damage + styrka * 1.3;
            speed = speed + agility * 1.13;
            armor = armor + agility * 0.22;
            resistance = resistance + intelligence * 0.2;
        }

        public override int Attack(Hero hero)
        {
            return base.Attack(hero);      // Specifik attack för DungeonWraithon        
        }
    }
    public class DungeonHauntress : Enemy
    {
        public DungeonHauntress(Hero hero)
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

            name = "DungeonHauntress-" + random.Next(1, 3340);

            damage = damage + intelligence * 1;
            healing = healing + Math.Round(intelligence * 0.95);
            speed = speed + agility * 1.15;
            armor = armor + agility * 0.26;
            resistance = resistance + intelligence * 0.2;
        }

        public override int Attack(Hero hero)
        {
            return base.AttackSpellCasters(hero);   // Specifik attack för DungeonHauntress        
        }

    }
    public class DungeonGravemourn : Enemy
    {
        public DungeonGravemourn(Hero hero)
        {
            hp = 45;
            damage = 1.5;
            speed = 0.8;
            armor = 3;
            baseArmor = 1.5;
            baseSpeed = 2;
            baseDamage = 4;
            baseResistance = 1;

            name = "DungeonGravemourn-" + random.Next(1, 3340);

            damage = damage + styrka * 1;
            speed = speed + agility * 1.10;
            armor = armor + agility * 0.28;
            resistance = resistance + intelligence * 0.25;
        }

        public override int Attack(Hero hero)
        {

            return base.Attack(hero);      // Specifik attack för DungeonGravemourn        
        }
    }
}
