using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using Kod_till_Spel.Menus;
using Kod_till_Spel.Models;


namespace SPEL
{
    public class Program
    {
        public static bool Running = true;
        static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                Menu menu = new Menu();

                menu.StartMenu();


                /* 
                 * Ett problem där om jag skapar en ny hjälte och sedan laddar jag en annan hjälte och sedan
                 * går in i attack så är det den gamla hjälten som går in i attack och inte nya
                 * 
                 * Problem där om jag möter en healer, tex shaman, och shaman har högre speed än 
                 * hero så hamnar texten väldigt till vänster. pga att Healing inte kommer med
                 * 
                 * //FIXAD// Fixa så att man får en viss chans till Poitions vid att roama runt och attackera mobs
                 *  som man sedan använder i dungeons för att inte dö, dör man börjar man från början i dungeon
                 * 
                 * Fixa olika hero klasser, Mage, archer, warrior, hunter, rouge
                 * 
                 * Fixa Så man kan välja bland Titlarna
                 * Samt att den valda Titen gör så att man ökar Damage emot den typen av enemy.
                 */
            }
        }
    }
}
