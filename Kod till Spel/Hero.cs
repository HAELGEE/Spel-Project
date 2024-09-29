using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using Kod_till_Spel;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;
using static Kod_till_Spel.Armor;
using static Kod_till_Spel.EquipAbleItem;
using System.Xml.Linq;

namespace Kod_till_Spel;
public class Hero
{
    static void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;       //Färg metod för GRÖN med variabel String
        Console.Write(value);
        Console.ResetColor();
    }
    static void Cyan(int value)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;        //Färg metod för CYAN med variabel int
        Console.Write(value);
        Console.ResetColor();
    }
    static void Red(string value)
    {
        Console.ForegroundColor = ConsoleColor.Red;         //Färg metod för RÖD med variabel String
        Console.Write(value);
        Console.ResetColor();
    }
    public double baseDmg { get; set; } = 3;
    public double baseArmor { get; set; } = 1.5;
    public double baseSpeed { get; set; } = 2;
    public string name { get; set; }
    public int level { get; set; } = 1;
    public static int savedLevel { get; set; } = 1;
    public double experience { get; set; } = 0;
    public int hp { get; set; } = 15;
    public int maxHp { get; set; } = 15;
    public int styrka { get; set; } = 2;               //ÖKAR SKADA
    public int agility { get; set; } = 2;              //ÖKAR SPEED
    public int stamina { get; set; } = 2;
    public int charm { get; set; } = 1;
    public int intelligence { get; set; } = 1;
    public int mana { get; set; } = 15;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR
    public double resistance { get; set; } = 1;         //Armor emot magisk dmg
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 50;
    public int lifeSteal { get; set; } = 0;
    public int Guld { get; set; } = 0;

    public Weapon EquippedWeapon { get; set; }  // Lägger till för att hantera nuvarande utrustat vapen
    public List<EquipableItem> Inventory { get; set; } = new List<EquipableItem>(); //Skapar en lista för items som är hittade

    private Random random = new Random();
    public Colour colour = new Colour();

    public Armor Head { get; set; }
    public Armor Chest { get; set; }
    public Armor Hands { get; set; }
    public Armor Legs { get; set; }
    public Armor Feet { get; set; }
    public Weapon Weapon { get; set; }

    // Metod för att lägga till ett item i inventariet
    public void AddToInventory(EquipableItem item)
    {
        Inventory.Add(item);
        Console.WriteLine($"{item.Name} har lagts till i ditt inventarium.");
    }

    // Metod för att utrusta ett item
    public void Equip(EquipableItem item)
    {
        if (item is Armor armor)
        {
            switch (armor.Slot)
            {
                case ArmorSlot.Head:
                    Head = armor;
                    break;
                case ArmorSlot.Chest:
                    Chest = armor;
                    break;
                case ArmorSlot.Hands:
                    Hands = armor;
                    break;
                case ArmorSlot.Legs:
                    Legs = armor;
                    break;
                case ArmorSlot.Feet:
                    Feet = armor;
                    break;
            }
        }
        else if (item is Weapon weapon)
        {
            Weapon = weapon;
        }
    }

    // Metod för att ta av ett item
    public void UnequipItem(EquipableItem item)
    {
        // Logik för att ta av item, t.ex. återställa stats
        Console.WriteLine($"Du har tagit av {item.Name}.");
    }

    // Metod för att visa inventory
    public void ShowInventory()
    {
        Console.WriteLine("Dina items:");
        foreach (var item in Inventory)
        {
            Console.Write($"Namn: {item.Name}, Rarity: ");

            // Här lägs färg in för rätt vapen/armor
            switch (item.ItemRarity.ToString())
            {
                case "Common":
                    colour.Green(item.ItemRarity.ToString());
                    break;
                case "Uncommon":
                    colour.Green(item.ItemRarity.ToString());
                    break;
                case "Rare":
                    colour.Blå(item.ItemRarity.ToString());
                    break;
                case "Epic":
                    colour.Magenta(item.ItemRarity.ToString());
                    break;
                case "Legendary":
                    colour.Gul(item.ItemRarity.ToString());
                    break;
                case "Mythic":
                    colour.Red(item.ItemRarity.ToString());
                    break;
            }

            Console.WriteLine();
        }
    }
    public void ManageInventory()
    {
        bool loop = true;
        while (true)
        {
            Console.Clear();
            ShowInventory();

            Console.WriteLine("Vill du utrusta ett item? Skriv namnet på itemet eller 'back' för att gå tillbaka:");
            string choice = Console.ReadLine();

            var itemToEquip = Inventory.FirstOrDefault(i => i.Name.IndexOf(choice, StringComparison.OrdinalIgnoreCase) >= 0);

            if (itemToEquip != null)
            {
                Equip(itemToEquip);                
                Console.ReadKey();
                loop = false;
                return;
            }
            else if (choice.ToLower() == "back")
            {
                loop = false; // Gå tillbaka
                return;
            }
            else
            {
                Console.WriteLine("Itemet finns inte i inventariet.");
            }
            Console.ReadKey();
        }
    }

    public void ShowEquippedItems()
    {
        Console.WriteLine("Equipped Items:");
        if (Head != null) Console.WriteLine($"Huvudet: {Head.Name}, Attributes: {string.Join(", ", Head.Attributes)}");
        else Console.WriteLine("Du har inget på Huvudet");
        if (Chest != null) Console.WriteLine($"Bröst: {Chest.Name}, Attributes: {string.Join(", ", Chest.Attributes)}");
        else Console.WriteLine("Du har inget på Bröstet");
        if (Hands != null) Console.WriteLine($"Händer: {Hands.Name}, Attributes: {string.Join(", ", Hands.Attributes)}");
        else Console.WriteLine("Du har inget på Händerna");
        if (Legs != null) Console.WriteLine($"Byxor: {Legs.Name}, Attributes: {string.Join(", ", Legs.Attributes)}");
        else Console.WriteLine("Du har inga Byxor");
        if (Feet != null) Console.WriteLine($"Fötter: {Feet.Name}, Attributes: {string.Join(", ", Feet.Attributes)}");
        else Console.WriteLine("Du har inget på Fötterna");
        if (Weapon != null) Console.WriteLine($"Vapen: {Weapon.Name}, Attributes: {string.Join(", ", Weapon.Attributes)}");
        else Console.WriteLine("Du har inget vapen");

        // Kontrollera attributen och uppdaterar attributen
        UpdateAttributes(Head);
        UpdateAttributes(Chest);
        UpdateAttributes(Hands);
        UpdateAttributes(Legs);
        UpdateAttributes(Feet);
        UpdateAttributes(Weapon);
    }   

    private void UpdateAttributes(EquipableItem item)
    {
        if (item != null && item.Attributes != null)
        {
            // Lista över attribut som vi vill kontrollera
            string[] attributeKeys = { "Strength", "Agility", "HPBoost", "Lifesteal", "Intelligence", "Mana" };

            foreach (var key in attributeKeys)
            {
                if (item.Attributes.ContainsKey(key))
                {
                    // Beroende på vilket attribut som finns, uppdatera den relevanta egenskapen
                    switch (key)
                    {
                        case "Strength":
                            this.styrka += item.Attributes[key];
                            break;
                        case "Agility":
                            this.agility += item.Attributes[key];
                            break;
                        case "HPBoost":
                            this.maxHp += item.Attributes[key];
                            break;
                        case "Lifesteal":
                            this.lifeSteal += item.Attributes[key];
                            break;
                        case "Intelligence":
                            this.intelligence += item.Attributes[key];
                            break;
                        case "Mana":
                            this.mana += item.Attributes[key];
                            break;
                    }
                }
            }
        }
    }

    public Hero()
    {
        maxHp = hp;    //Denna raden är bara till för att veta vad MAX HP till Hero är!
                       //HeroLevels(savedLevel);
        Stats();
        AddExperience(this.experience);
    }
    public void AddExperience(double amount)
    {
        experience += amount;
        while (experience >= maxXp)
        {
            experience -= maxXp;
            LevelUp();
        }
    }

    public void LifeStealing()
    {
        if (lifeSteal > 0)
        {
            if (hp < maxHp)
            {
                hp = hp + lifeSteal;
                if (hp > maxHp)
                {
                    hp = maxHp;
                }
                Console.Write($" och du lifestealade ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(lifeSteal);
                Console.ResetColor();
                Console.WriteLine("hp");
            }
            else
            {
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("");
        }
    }

    public void LevelUp()
    {
        level++;
        maxXp *= 2;
        maxHp = maxHp + 5;
        hp = maxHp;
        int statIncrease = 2;

        Console.Write($"Du gick precis upp i level!");
        while (statIncrease != 0)
        {
            Console.WriteLine($" Du har {statIncrease} kvar att välj en stat att öka:");
            Console.WriteLine($"1. Styrka \n2. Agility \n3. Stamina \n4. Charm \n5. Intelligence \n");
            string str = Console.ReadLine()!;

            if (str == "1")
            {
                styrka++;
                statIncrease--;
            }
            else if (str == "2")
            {
                agility++;
                statIncrease--;
            }
            else if (str == "3")
            {
                stamina++;
                statIncrease--;
            }
            else if (str == "4")
            {
                charm++;
                statIncrease--;
            }
            else if (str == "5")
            {
                intelligence++;
                statIncrease--;
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen!");
                str = Console.ReadLine()!;
            }

        }
        Stats();
    }

    public void Stats()
    {
        dmg = baseDmg + (styrka * 1.2);   //Avgör dmg (drar av skada beroende på armor)
        speed = baseSpeed + (agility * 1.15);    //För att se vem som skall starta attackera vem.
        armor = baseArmor + (agility * 0.26);    //För att göra "avdrag" av dmg    
        resistance = resistance + (intelligence * 0.2); //Resistance "avdrag" utav spell dmg 
    }

    public int Attack(OrcBase orc)      //Tvungen att lägga in Orc här för att hämta statsen ifrån Orc klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 4;
        minDamage += (int)dmg - (int)orc.armor;
        maxDamage += (int)dmg - (int)orc.armor;
        int value = random.Next(minDamage, maxDamage);
        if (value < 0)
        {
            value = 0;
        }
        Console.Write("\n");
        Green(name);                //Lägger till Färgen GRÖN på Hero
        Console.Write(" gjorde ");
        Cyan(value);                //Lägger till färgen CYAN på DMG
        Console.Write(" slash dmg.");
        LifeStealing();
        return value;
    }

}
