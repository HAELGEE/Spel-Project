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
using static Kod_till_Spel.Armor;
using static Kod_till_Spel.EquipAbleItem;

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
    public double baseDmg { get; set; } = 3;
    public double baseArmor { get; set; } = 1.5;
    public double baseSpeed { get; set; } = 2;
    public string name { get; set; }
    public int level { get; set; } = 1;
    public static int savedLevel { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 15;
    public int maxHp { get; set; } = 15;
    public int styrka { get; set; } = 2;               //ÖKAR SKADA
    public int agility { get; set; } = 2;              //ÖKAR SPEED
    public int stamina { get; set; } = 2;
    public int charm { get; set; } = 1;
    public int intelligence { get; set; } = 1;
    public int mana { get; set; } = 15;
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

    public Armor Head { get; set; }
    public Armor Chest { get; set; }
    public Armor Hands { get; set; }
    public Armor Legs { get; set; }
    public Armor Feet { get; set; }
    public Weapon Weapon { get; set; }

    public void Equip(EquipableItem item)
    {
        if (item is Armor armor)
        {
            switch (armor.Slot)
            {
                case ArmorSlot.Head:
                    Head = armor;
                    break;
                case ArmorSlot.Chest:
                    Chest = armor;
                    break;
                case ArmorSlot.Hands:
                    Hands = armor;
                    break;
                case ArmorSlot.Legs:
                    Legs = armor;
                    break;
                case ArmorSlot.Feet:
                    Feet = armor;
                    break;
            }
        }
        else if (item is Weapon weapon)
        {
            Weapon = weapon;
        }
    }

    public void ShowEquippedItems()
    {
        Console.WriteLine("Equipped Items:");
        if (Head != null) Console.WriteLine($"Head: {Head.Name}, Attributes: {string.Join(", ", Head.Attributes)}");
        if (Chest != null) Console.WriteLine($"Chest: {Chest.Name}, Attributes: {string.Join(", ", Chest.Attributes)}");
        if (Hands != null) Console.WriteLine($"Hands: {Hands.Name}, Attributes: {string.Join(", ", Hands.Attributes)}");
        if (Legs != null) Console.WriteLine($"Legs: {Legs.Name}, Attributes: {string.Join(", ", Legs.Attributes)}");
        if (Feet != null) Console.WriteLine($"Feet: {Feet.Name}, Attributes: {string.Join(", ", Feet.Attributes)}");
        if (Weapon != null) Console.WriteLine($"Weapon: {Weapon.Name}, Attributes: {string.Join(", ", Weapon.Attributes)}");
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
        dmg = baseDmg + (styrka * 1.2);   //Avgör dmg (drar av skada beroende på armor)
        speed = baseSpeed + (agility * 1.15);    //För att se vem som skall starta attackera vem.
        armor = baseArmor + (agility * 0.26);    //För att göra "avdrag" av dmg    
        resistance = resistance + (intelligence * 0.2); //Resistance "avdrag" utav spell dmg 
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
