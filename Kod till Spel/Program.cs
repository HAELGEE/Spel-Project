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
             *  Problem med attackera mobs då Hero klassen är Null
             *  Problem med att ladda och spara hjälte. FIXA
             *  Kan heller inte ladda en sparad hjälte som har fått items Måste spara med Items till Hjälte Fixa
             */
        }
    }
}
