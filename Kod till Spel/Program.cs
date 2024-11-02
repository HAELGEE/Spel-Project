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

            /*
             * Ett problem där om jag skapar en ny hjälte och sedan laddar jag en annan hjälte och sedan
             * går in i attack så är det den gamla hjälten som går in i attack och inte nya
             * Och tar jag ladda hjälte och det inte finns någon så går man vidare till menyn och spelet krashar sen för att Hero = null
             */
        }
    }
}
