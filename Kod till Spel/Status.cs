using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
internal class Status
{
    public Colour colour = new Colour();    

    public void StatusMenu()
    {
        Hero hero = GameState.CurrentHero;

        Console.WriteLine("===================================");
        Console.WriteLine($"Ditt namn på din Hero: {hero.name}\n");
        Console.WriteLine("Din hjälte är på Level: " + hero.level);
        Console.WriteLine($"Din hjälte har: {hero.experience}xp");
        Console.WriteLine($"Din hjälte har: {hero.maxXp - hero.experience}xp kvar till nästa level\n");
        Console.WriteLine($"Du har för närvarande {hero.Guld} guld\n");
        Console.Write($"HP: ");
        if (hero.hp < hero.maxHp)
        {
            colour.Red(hero.hp);
        }
        else
        {
            colour.Green(hero.hp);
        }        
        Console.ResetColor();
        Console.Write(" av ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(hero.maxHp);
        Console.ResetColor();
        Console.WriteLine("Styrka: " + hero.styrka);
        Console.WriteLine("Agility: " + hero.agility);
        Console.WriteLine("Stamina: " + hero.stamina);
        Console.WriteLine("Intelligence: " + hero.intelligence);
        Console.WriteLine("Charm: " + hero.charm);
        Console.WriteLine("Speed: " + hero.speed);
        Console.WriteLine("DMG: " + hero.dmg);
        Console.WriteLine("ARMOR: " + hero.armor);
        Console.WriteLine($"LifeSteal: {hero.lifeSteal}");
        Console.WriteLine("===================================");
        Console.ReadKey();
        Console.Clear();
    }
}
