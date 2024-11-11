using Kod_till_Spel.Menus;
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

        Console.WriteLine(CenterText.CenterTexts("==========================================================="));
        Console.WriteLine(CenterText.CenterTexts($"Ditt namn på din Hero: {hero.name}\n"));
        Console.WriteLine(CenterText.CenterTexts($"Titel: {hero.Title}\n"));
        Console.WriteLine(CenterText.CenterTexts("Din hjälte är på Level: " + hero.level));
        Console.WriteLine(CenterText.CenterTexts($"Din hjälte har: {hero.experience}xp"));
        Console.WriteLine(CenterText.CenterTexts($"Din hjälte har: {hero.maxXp - hero.experience}xp kvar till nästa level\n"));
        Console.WriteLine(CenterText.CenterTexts($"Du har för närvarande {hero.Guld} guld\n"));
        Console.Write(CenterText.CenterHpText($"HP:"));
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
        Console.WriteLine(CenterText.CenterTexts("Styrka: " + hero.styrka));
        Console.WriteLine(CenterText.CenterTexts("Agility: " + hero.agility));
        Console.WriteLine(CenterText.CenterTexts("Stamina: " + hero.stamina));
        Console.WriteLine(CenterText.CenterTexts("Intelligence: " + hero.intelligence));
        Console.WriteLine(CenterText.CenterTexts("Charm: " + hero.charm));
        Console.WriteLine(CenterText.CenterTexts("Speed: " + hero.speed));
        Console.WriteLine(CenterText.CenterTexts("DMG: " + hero.dmg));
        Console.WriteLine(CenterText.CenterTexts("ARMOR: " + hero.armor));
        Console.WriteLine(CenterText.CenterTexts($"LifeSteal: {hero.lifeSteal}"));
        Console.WriteLine(CenterText.CenterTexts("==========================================================="));
        Console.ReadKey();
        Console.Clear();
    }
}
