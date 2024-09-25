using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;

namespace Kod_till_Spel;
public class Hero
{
    static void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;       //Färg metod för GRÖN med variabel String
        Console.Write(value);
        Console.ResetColor();
    }
    static void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;        //Färg metod för CYAN med variabel int
        Console.Write(value);
        Console.ResetColor();
    }
    static void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;         //Färg metod för RÖD med variabel String
        Console.Write(value);
        Console.ResetColor();
    }
    public double baseDmg { get; set; } = 2;
    public double baseArmor { get; set; } = 1;
    public double baseSpeed { get; set; } = 1;
    public string name { get; set; }
    public int level { get; set; } = 1;
    public static int savedLevel { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 1;               //ÖKAR SKADA
    public int agility { get; set; } = 1;              //ÖKAR SPEED
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 1;
    public int intelligence { get; set; } = 1;
    public int mana { get; set; } = 10;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR
    public double resistance { get; set; } = 1;         //Armor emot magisk dmg
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 50;
    public int lifeSteal { get; set; } = 0;
    public int Guld { get; set; } = 0;
    public Weapon EquippedWeapon { get; set; }  // Lägger till för att hantera nuvarande utrustat vapen

    private Random random = new Random();

    public void EquipItem(Items item)
    {
        if (item is Weapon)
        {
            EquippedWeapon = (Weapon)item;
            EquippedWeapon.ApplyStats(this);
        }
    }
    public void ShowItems()
    {
        Console.WriteLine("Utrustade föremål:");
        if (EquippedWeapon != null)
        {
            if (EquippedWeapon.ItemClass.Contains("Common"))
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                //Sätter färgen Gray på texten "Vapen" när det innehåller Common
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else if (EquippedWeapon.ItemClass.Contains("UnCommon"))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                //Sätter färgen Green på texten "Vapen" när det innehåller UnCommon
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else if (EquippedWeapon.ItemClass.Contains("Rare"))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                //Sätter färgen Blue på texten "Vapen" när det innehåller Rare
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else if (EquippedWeapon.ItemClass.Contains("VeryRare"))
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                //Sätter färgen DarkBlue på texten "Vapen" när det innehåller VeryRare
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else if (EquippedWeapon.ItemClass.Contains("Epic"))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                //Sätter färgen Magenta på texten "Vapen" när det innehåller Epic
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else if (EquippedWeapon.ItemClass.Contains("Legendary"))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Sätter färgen Yellow på texten "Vapen" när det innehåller Legendary
                Console.Write("Vapen");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //Sätter färgen DarkRed på texten "Vapen" när det innehåller Mythic
                Console.Write("Vapen");
                Console.ResetColor();
            }


            //Visar upp vilka stats som ökar och hur mycket.
            Console.WriteLine($": {EquippedWeapon.ItemName} - Damage: {EquippedWeapon.WeaponDamage}\nStyrka: {EquippedWeapon.styrka}\n" +
                $"Agility: {EquippedWeapon.agility}\nStamina: {EquippedWeapon.stamina}\n" +
                $"Intelligence: {EquippedWeapon.intelligence}\nCharm: {EquippedWeapon.charm}\nLifesteal: {EquippedWeapon.lifeSteal}");

        }
        else
        {
            Console.WriteLine("Inget vapen utrustat."); //Om inget vapen är utrustat
        }
    }

    public Hero()
    {
        maxHp = hp;    //Denna raden är bara till för att veta vad MAX HP till Hero är!
        //HeroLevels(savedLevel);
        Stats();
        AddExperience(this.experience);
    }
    public void AddExperience(double amount)
    {
        experience += amount;
        while (experience >= maxXp)
        {
            experience -= maxXp;
            LevelUp();
        }
    }

    public void LifeStealing()
    {
        if (lifeSteal > 0)
        {
            if (hp < maxHp)
            {
                hp = hp + lifeSteal;
                if (hp > maxHp)
                {
                    hp = maxHp;
                }
                Console.Write($" och du lifestealade ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(lifeSteal);
                Console.ResetColor();
                Console.WriteLine("hp");
            }
            else
            {
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("");
        }
    }

    public void LevelUp()
    {
        level++;
        maxXp *= 2;
        maxHp = maxHp + 5;
        hp = maxHp;
        int statIncrease = 2;

        Console.Write($"Du gick precis upp i level!");
        while (statIncrease != 0)
        {
            Console.WriteLine($" Du har {statIncrease} kvar att välj en stat att öka:");
            Console.WriteLine($"1. Styrka \n2. Agility \n3. Stamina \n4. Charm \n5. Intelligence \n");
            string str = Console.ReadLine()!;

            if (str == "1")
            {
                styrka++;
                statIncrease--;
            }
            else if (str == "2")
            {
                agility++;
                statIncrease--;
            }
            else if (str == "3")
            {
                stamina++;
                statIncrease--;
            }
            else if (str == "4")
            {
                charm++;
                statIncrease--;
            }
            else if (str == "5")
            {
                intelligence++;
                statIncrease--;
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen!");
                str = Console.ReadLine()!;
            }

        }
        Stats();
    }

    public void Stats()
    {
        dmg = baseDmg + (styrka * 1.1);   //Avgör dmg (drar av skada beroende på armor)
        speed = baseSpeed + (agility * 1.05);    //För att se vem som skall starta attackera vem.
        armor = baseArmor + (agility * 0.16);    //För att göra "avdrag" av dmg    
        resistance = resistance + (intelligence * 0.1); //Resistance "avdrag" utav spell dmg 
    }

    public int Attack(OrcBase orc)      //Tvungen att lägga in Orc här för att hämta statsen ifrån Orc klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg - (int)orc.armor;
        maxDamage += (int)dmg - (int)orc.armor;
        int value = random.Next(minDamage, maxDamage);
        if (value < 0)
        {
            value = 0;
        }
        Console.Write("\n");
        Green(name);                //Lägger till Färgen GRÖN på Hero
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" slash dmg.");
        LifeStealing();
        return value;
    }

}
