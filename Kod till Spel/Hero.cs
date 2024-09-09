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
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int Maxhp { get; set; } = 10;
    public int styrka { get; set; } = 1;
    public int agility { get; set; } = 1;
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;
    public double speed { get; set; } = 2;
    public double armor { get; set; } = 1;
    public int xp { get; set; } = 0;
    public int Maxxp { get; set; } = 200;

    private Random random = new Random();


    public Hero()
    {
        Stats();
        Level();
        Name();
    }

    public void Name()
    {
        this.name = "HAELGE";       //DENNA MÅSTE FIXAS PÅ NÅGOT SÄTT. NU HAR JAG SATT PERMANENT NAMN PÅ HJÄLTEN!!!!!!
    }


    public void Level()
    {
        /*Måste göra något för att få in Hur mycket XP det ska vara mellan varje level.       
         * Sen ska jag få statsen till att öka för varje level, där Du som karaktär får välja vad du vill levla upp för stats.
         */

      
            if (experience >= Maxxp)
            {
                level++;
                experience = 0;
                Maxxp = Maxxp * 2;
            }
           
        
        xp = Maxxp - xp;
    }


    public void Stats()
    {
        Maxhp = hp; //Denna raden är bara till för att veta vad MAX HP till Hero är!
        dmg = dmg + (styrka * 1.5);
        speed = speed + (agility * 1.2);
        armor = armor + (agility * 1.1);
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
