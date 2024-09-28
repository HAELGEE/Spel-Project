using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class Colour
{
    public void Green(int value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Red(int value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Gul(int value)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Gul(string value)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Blå(int value)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Blå(string value)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Grå(int value)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Grå(string value)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Magenta(int value)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }
    public void Magenta(string value)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write(value);
        Console.ResetColor();       //Reset av färg till standard
    }



}


