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
public class Orc
{
    static void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value);
        Console.ResetColor();
    }
    static void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();
    }
    static void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(value);
        Console.ResetColor();
    }
    public double orcBaseDmg { get; set; } = 2;
    public double orcBaseArmor { get; set; } = 1;
    public double orcBaseSpeed { get; set; } = 1;
    
    public string name { get; set; }
    public int level { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 10;
    public int styrka { get; set; } = 1;                //Ökar skada
    public int agility { get; set; } = 1;               //Ökar speed
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR

    private Random random = new Random();
    

    public Orc()
    {
        Namn(); //Ger orcen ett random namn
        Stats();
    }
    public void Stats()
    {
        dmg = orcBaseDmg + (styrka * 1.1);
        speed = orcBaseSpeed + (agility * 1.05);
        armor = orcBaseArmor + (agility / 2) * 1.01;
    }

    public void Namn()
    {
        this.name = "Grunt-" + random.Next(1, 3340);
    }

    public int Attack(Hero hero)    //Tvungen att lägga in Hero här för att hämta statsen ifrån Hero klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg - (int)hero.armor;
        maxDamage += (int)dmg - (int)hero.armor;
        int value = random.Next(minDamage, maxDamage);
        Red(name);                  //lägger in färgen RÖD på orc
        Console.Write(" gjorde ");  
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.WriteLine(" skada.");
        return value;
    }
}
