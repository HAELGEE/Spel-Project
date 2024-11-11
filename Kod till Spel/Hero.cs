using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPEL;
using System.IO;
using System.Text.Json;
using System.Security.Cryptography;
using static Kod_till_Spel.Armor;
using static Kod_till_Spel.EquipAbleItem;
using System.Xml.Linq;
using Kod_till_Spel.Enemys;
using Kod_till_Spel.Menus;
using System.Threading.Channels;

namespace Kod_till_Spel;
public class Hero
{
    static void Green(string value)
    {
        Console.ForegroundColor = ConsoleColor.Green;       //Färg metod för GRÖN med variabel String
        Console.Write(CenterText.CenterTextsHeroName(value));
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
        Console.Write(CenterText.CenterTextsHeroName(value));
        Console.ResetColor();
    }

    public string HeroClass { get; set; }
    public string Title { get; set; }
    public static int OrcKiller = 0;
    public static int ElfKiller = 0;
    public static int GhostKiller = 0;
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
    public int charm { get; set; } = 2;
    public int intelligence { get; set; } = 2;
    public int mana { get; set; } = 15;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR
    public double resistance { get; set; } = 1;         //Armor emot magisk dmg
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 50;
    public int lifeSteal { get; set; } = 0;
    public int Guld { get; set; } = 0;
    public int Potions { get; set; } = 0;

    public Hero()
    {
        maxHp = hp;    //Denna raden är bara till för att veta vad MAX HP till Hero är!

        Stats();
        AddExperience(experience);
        Titles();
    }



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
        Console.WriteLine(CenterText.CenterTexts($"Du har tagit av {item.Name}."));
    }

    // Metod för att visa inventory
    public void ShowInventory()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(CenterText.CenterTexts("Dina items:"));
        Console.WriteLine();
        Console.WriteLine(CenterText.CenterTexts($"Healing Potions: {Potions}st"));
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

            foreach (var att in item.Attributes)
                Console.Write($", {att}");

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

            Console.WriteLine();
            Console.WriteLine(CenterText.CenterTexts("Vill du använda en Healing Potion, skriv Potion"));
            Console.WriteLine(CenterText.CenterTexts("Vill du utrusta ett item? Skriv namnet på itemet eller 'back' för att gå tillbaka:"));
            string choice = Console.ReadLine();

            if (choice.ToLower() == "Potion")
            {
                if (hp > maxHp)
                    hp = maxHp;

                hp = hp + 10;
            }

            var itemToEquip = Inventory.FirstOrDefault(i => i.Name.IndexOf(choice, StringComparison.OrdinalIgnoreCase) >= 0);

            if (itemToEquip != null)
            {
                Equip(itemToEquip);
                itemToEquip.Name = $"{itemToEquip.Name} [EQUIPED]";
                Console.WriteLine(CenterText.CenterTexts($"Du utrustade dig med: {itemToEquip.Name}"));
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
                Console.WriteLine(CenterText.CenterTexts("Itemet finns inte i inventariet."));
            }
            Console.ReadKey();
        }
    }

    public void ShowEquippedItems()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(CenterText.CenterTexts("Equipped Items:"));
        if (Head != null) Console.WriteLine(CenterText.CenterTexts($"Huvudet: {Head.Name}, Attributes: {string.Join(", ", Head.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inget på Huvudet"));
        if (Chest != null) Console.WriteLine(CenterText.CenterTexts($"Bröst: {Chest.Name}, Attributes: {string.Join(", ", Chest.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inget på Bröstet"));
        if (Hands != null) Console.WriteLine(CenterText.CenterTexts($"Händer: {Hands.Name}, Attributes: {string.Join(", ", Hands.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inget på Händerna"));
        if (Legs != null) Console.WriteLine(CenterText.CenterTexts($"Byxor: {Legs.Name}, Attributes: {string.Join(", ", Legs.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inga Byxor"));
        if (Feet != null) Console.WriteLine(CenterText.CenterTexts($"Fötter: {Feet.Name}, Attributes: {string.Join(", ", Feet.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inget på Fötterna"));
        if (Weapon != null) Console.WriteLine(CenterText.CenterTexts($"Vapen: {Weapon.Name}, Attributes: {string.Join(", ", Weapon.Attributes)}"));
        else Console.WriteLine(CenterText.CenterTexts("Du har inget vapen"));

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
                            styrka += item.Attributes[key];
                            break;
                        case "Agility":
                            agility += item.Attributes[key];
                            break;
                        case "HPBoost":
                            maxHp += item.Attributes[key];
                            break;
                        case "Lifesteal":
                            lifeSteal += item.Attributes[key];
                            break;
                        case "Intelligence":
                            intelligence += item.Attributes[key];
                            break;
                        case "Mana":
                            mana += item.Attributes[key];
                            break;
                    }
                }
            }
        }
    }

    public List<string> titles = new List<string>();
    public void Titles()
    {
        if (OrcKiller >= 100)
            titles.Add("Orc Slayer");

        if (ElfKiller >= 100)
            titles.Add("Elf Slayer");

        if (GhostKiller >= 100)
            titles.Add("Ghost Slayer");

    }
    public void TitleManagement()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();

        if (titles.Count > 0)
        {
            int i = 0;
            
            foreach (var Titel in titles)
            {
                Console.WriteLine(CenterText.CenterTexts($"{i++}. {Titel}"));
            }
            Console.WriteLine(CenterText.CenterTexts("Vilken titel vill du välja?"));
           string choice = Console.ReadLine();
            if (choice == "1")
            {
                if (Title.Contains("Orc"))
                    Title = "Orc slayer";
                else if (Title.Contains("Elf"))
                    Title = "Elf slayer";
                else
                    Title = "Ghost slayer";
            }
            else if (choice == "2")
            {
                if (Title.Contains("Orc"))
                    Title = "Orc slayer";
                else if (Title.Contains("Elf"))
                    Title = "Elf slayer";
                else
                    Title = "Ghost slayer";
            }
            else if (choice == "3")
            {
                if (Title.Contains("Orc"))
                    Title = "Orc slayer";
                else if (Title.Contains("Elf"))
                    Title = "Elf slayer";
                else
                    Title = "Ghost slayer";
            }


        }
        else
            Console.WriteLine(CenterText.CenterTexts("Du har för närvande inga Titlar."));

        Console.ReadKey();
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

        Console.Write(CenterText.CenterTexts($"Du gick precis upp i level!"));
        while (statIncrease != 0)
        {
            //if (level > 4)
            //{
            //    string[] String =
            //    {
            //    "Warrior",
            //    "Rouge",
            //    "Mage",
            //    "Archer"
            //    };

            //    MenuChoice.MenuChoices(String, 4, "Grattis till nivå 5, du kan nu välja en klass");

            //}
            Console.Clear();

            Console.WriteLine(CenterText.CenterTexts($" Du har {statIncrease} stat increase kvar: "));
            Console.WriteLine(CenterText.CenterTexts($"1. Styrka"));
            Console.WriteLine(CenterText.CenterTexts("2. Agility"));
            Console.WriteLine(CenterText.CenterTexts("3. Stamina"));
            Console.WriteLine(CenterText.CenterTexts("4. Charm"));
            Console.WriteLine(CenterText.CenterTexts("5. Intelligence"));
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
                Console.WriteLine(CenterText.CenterTexts("Ogiltigt val, försök igen!"));
                str = Console.ReadLine()!;
            }

        }
        Stats();
    }

    public void Stats()
    {
        dmg = baseDmg + styrka * 1.2;   //Avgör dmg (drar av skada beroende på armor)
        speed = baseSpeed + agility * 1.15;    //För att se vem som skall starta attackera vem.
        armor = baseArmor + agility * 0.26;    //För att göra "avdrag" av dmg    
        resistance = resistance + intelligence * 0.2; //Resistance "avdrag" utav spell dmg 
    }

    public int Attack(Enemy enemy)      //Tvungen att lägga in Orc här för att hämta statsen ifrån Orc klassen för att sedan dra Minus på dmg med armor
    {
        int minDamage = 1;
        int maxDamage = 7;
        minDamage += (int)dmg - (int)enemy.armor;
        maxDamage += (int)dmg - (int)enemy.armor;
        double value = random.Next(minDamage, maxDamage);
        if (value < 0)
        {
            value = 0;
        }
        if (Title == "Orc slayer")
            value = (value * 1.1);
        else if (Title == "Elf slayer")
            value = (value * 1.1);
        else if (Title == "Ghost slayer")
            value = (value * 1.1);

        Math.Round(value);
        
        Console.Write("\n");
        Green(name);                //Lägger till Färgen GRÖN på Hero
        Console.Write(" gjorde ");
        Cyan(Convert.ToInt32(value));                //Lägger till färgen CYAN på DMG
        Console.Write(" slash dmg.");
        LifeStealing();
        return Convert.ToInt32(value);
    }

}
