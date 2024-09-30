using System;
using System.Runtime.InteropServices;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;


namespace SPEL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.StartMenu();
        }
    }
}
