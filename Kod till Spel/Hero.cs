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
    public int experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 1;               //ÖKAR SKADA
    public int agility { get; set; } = 1;              //ÖKAR SPEED
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 50;

    private Random random = new Random();



    public Hero()
    {
        maxHp = hp;    //Denna raden är bara till för att veta vad MAX HP till Hero är!
        Stats();
        AddExperience(this.experience);
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        while (experience >= maxXp)
        {
            experience -= maxXp;
            LevelUp();
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
            string str = Console.ReadLine();

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
                str = Console.ReadLine();
            }

        }
        Stats();
    }

    public void Stats()
    {
        dmg = baseDmg + (styrka * 1.1);   //Avgör dmg (drar av skada beroende på armor)
        speed = baseSpeed + (agility * 1.05);    //För att se vem som skall starta attackera vem.
        armor = baseArmor + ((agility / 2) * 1.01);    //För att göra "avdrag" av dmg    
    }

    public int Attack(OrcBase orc)      //Tvungen att lägga in Orc här för att hämta statsen ifrån Orc klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg - (int)orc.armor;
        maxDamage += (int)dmg - (int)orc.armor;
        int value = random.Next(minDamage, maxDamage);
        Green(name);                //Lägger till Färgen GRÖN på Hero
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.WriteLine(" skada.");
        return value;
    }
}
