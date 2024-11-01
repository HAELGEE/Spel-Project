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
             *  Kan skapa en hero som sparas i GameState, men får inte den till att gå vidare och lägga sig som Hero (Hero klassen är tom)
             *  Problem med att ladda och spara hjälte. FIXA
             *  Kan heller inte ladda en sparad hjälte som har fått items Måste spara med Items till Hjälte Fixa
             */
        }
    }
}
