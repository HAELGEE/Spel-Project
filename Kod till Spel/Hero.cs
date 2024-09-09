using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using Kod_till_Spel;

namespace Kod_till_Spel;
public class Hero
{
    
    public string name { get; set; }
    public int level { get; set; } = 1;
    public int experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 10;
    public int agility { get; set; } = 1;
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;
    public double speed { get; set; } = 2;
    public double armor { get; set; } = 1;
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 200;

    private Random random = new Random();


    public Hero()
    {
        Stats();
        AddExperience(this.experience);
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        while (experience >= maxXp)
        { 
        LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        maxXp *= 2;
        experience -= maxXp;
        

        Console.WriteLine("Du gick precis upp i level, välj en stat att öka:");
        Console.WriteLine($"1. Styrka \n2. Agility \n3. Stamina \n4. Charm \n5. Intelligence \n");
        string str = Console.ReadLine();
        while (true)
        {
            if (str == "1")
            {
                int statIncrease = Convert.ToInt32(str);
                this.styrka++;
                break;
            }
            else if (str == "2")
            {
                int statIncrease = Convert.ToInt32(str);
                this.agility++;
                break;
            }
            else if (str == "3")
            {
                int statIncrease = Convert.ToInt32(str);
                this.stamina++;
                break;
            }
            else if (str == "4")
            {
                int statIncrease = Convert.ToInt32(str);
                this.charm++;
                break;
            }
            else if (str == "5")
            {
                int statIncrease = Convert.ToInt32(str);
                this.intelligence++;
                break;
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen!");
                str = Console.ReadLine();
            }
            
        }



    }  
    public void Stats()
    {
        maxHp = hp;    //Denna raden är bara till för att veta vad MAX HP till Hero är!
        dmg = (dmg + (styrka * 1.1)) - armor;
        speed = speed + (agility * 1.05);    //För att se vem som skall starta attackera vem.
        armor = armor + (agility / 2) * 1.01;    //För att göra "avdrag" av dmg
    }

    public int Attack()
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg;
        maxDamage += (int)dmg;
        int value = random.Next(minDamage, maxDamage);
        Console.WriteLine(name + " gjorde " + value + " skada.");
        return value;
    }
}
