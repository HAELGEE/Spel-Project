using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using Kod_till_Spel.Menus;


namespace SPEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.StartMenu();

            /* Skall inte kunna skapa en hjälte med en tom sträng
             * Ett problem där om jag skapar en ny hjälte och sedan laddar jag en annan hjälte och sedan
             * går in i attack så är det den gamla hjälten som går in i attack och inte nya
             * Problem där om jag möter en healer, tex shaman, och shaman har högre speed än 
             * hero så hamnar texten väldigt till vänster. pga att Healing inte kommer med
             * 
             * Fixa så att man får en viss chans till Poitions vid att roama runt och attackera mobs
             * som man sedan använder i dungeons för att inte dö, dör man börjar man från början i dungeon
             * 
             * Fixa olika hero klasser, Mage, archer, warrior, hunter, rouge
             */
        }
    }
}
