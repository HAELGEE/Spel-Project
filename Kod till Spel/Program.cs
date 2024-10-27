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

            // MÅSTE FIXA SÅ ATT INTE " ORC " GÅR IN I ATTACK OCH SÅNT. HAR LAGT TILL GHOST OCH ELF KLASSEN!
            // SKAPA EN CLASS FÖR EGEN ATTACK/STATS FÖR MOBS KANSKE?
        }
    }
}
