using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Kod_till_Spel.Enemys;
using Kod_till_Spel.Menus;
using static Kod_till_Spel.Armor;
using static Kod_till_Spel.EquipAbleItem;

namespace Kod_till_Spel;
public class Dungeons
{
    Hero hero;
    Attack attack = new Attack();
    Enemy enemy;
    public Random random = new Random();
    Healing healing = new Healing();

    public Dungeons(Hero Hero)
    {
        this.hero = GameState.CurrentHero;
        enemy = new Enemy(hero);
    }
    public enum DungeonRank
    {
        E,
        D,
        C,
        B,
        A,
        S
    }
    public DungeonRank Rank { get; set; }
    public Dungeons(DungeonRank rank)
    {
        Rank = rank;
    }

    public bool dungeonLoop = true;
    public string keepGoing;
    public static int roomNumber = 0;

    public int rng = 0;


    public void EnterRoom()
    {
        if (roomNumber == 1 || roomNumber == 3)
            rng = random.Next(1, 4);
        else
            rng = random.Next(2, 6);


        Console.Clear();
        Console.WriteLine(CenterText.CenterTexts($"Du är nu i rum {roomNumber}"));
        attack.DungeonAttack(hero);
        if (hero.hp <= 0)
        {
            bool loop = true;
            do
            {
                Console.Clear();
                Console.WriteLine(CenterText.CenterTexts("Din hjälte är död, du kan inte fortsätta"));
                Console.WriteLine(CenterText.CenterTexts("Meditera för att försöka igen? J/N"));
                string choice = Console.ReadLine().ToUpper();

                if (choice == "J")      //Lägger till ett val för användaren för att se om dom vill försöka på detta rummet igen
                {
                    healing._Healing();     //Om ja
                    roomNumber = 0;
                    loop = false;
                    break;
                }
                if (choice == "N")              //Om nej
                {
                    dungeonLoop = false;
                    loop = false;
                    break;
                }
            } while (!true);
        }
        else
        {
            Console.Clear();
            Console.WriteLine(CenterText.CenterTexts($"Grattis, du klarade rum {roomNumber}"));
            Console.WriteLine(CenterText.CenterTexts($"Du fick {rng} guld för att klara rum {roomNumber}"));
            hero.Guld += rng;
            if (roomNumber == 2)
            {
                hero.Guld += 2;
                Console.WriteLine(CenterText.CenterTexts("Du får även 2 extra guld för att klara Bossen"));
            }

            if (roomNumber == 4)
            {
                hero.Guld += 4;
                Console.WriteLine(CenterText.CenterTexts("Du får även 4 extra guld för att klara sista Bossen\n"));
                EquipableItem loot = currentDungeon.DropLoot();
                if (loot != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(CenterText.CenterTexts($"Du hittade: {loot.Name} av rank {loot.ItemRarity}"));
                }
                else Console.WriteLine(CenterText.CenterTexts("Tyvärr, ingen loot denna gången"));

                Console.ReadKey();
            }
        }
    }
    


    public void EnterDungeon(Hero hero)
    {
        string dung = CenterText.CenterTexts("E-Dungeon");
        string dung2 = CenterText.CenterTexts("D-Dungeon");
        string dung3 = CenterText.CenterTexts("C-Dungeon");
        string dung4 = CenterText.CenterTexts("B-Dungeon");
        string dung5 = CenterText.CenterTexts("A-Dungeon");
        string dung6 = CenterText.CenterTexts("S-Dungeon");
        string dung7 = CenterText.CenterTexts("Tillabaka");

        string[] dungeonOption = {
        dung,
        dung2,
        dung3,
        dung4,
        dung5,
        dung6,
        dung7
    };
        int menuPicker = 0;

        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(CenterText.CenterTexts("Vilken dungeon vill du gå in i?"));
            for (int i = 0; i < dungeonOption.Length; i++)
            {
                if (i == menuPicker)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{(dungeonOption[i])}\t <---");
                    Console.ResetColor();
                    Console.CursorVisible = false;
                }
                else
                {
                    Console.WriteLine(dungeonOption[i]);
                }
            }

            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow && menuPicker < dungeonOption.Length - 1)
                menuPicker++;
            else if (key == ConsoleKey.UpArrow && menuPicker >= 1)
                menuPicker--;
            else if (key == ConsoleKey.Enter)
            {

                switch (menuPicker)
                {
                    case 0:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.E);
                        break;
                    case 1:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.D);
                        break;
                    case 2:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.C);
                        break;
                    case 3:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.B);
                        break;
                    case 4:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.A);
                        break;
                    case 5:
                        ResetDungeon();
                        currentDungeon = new Dungeons(hero);
                        Edungeon(DungeonRank.S);
                        break;

                    case 6:
                        Console.WriteLine(CenterText.CenterTexts("Du går nu tillbaka"));
                        Console.ReadKey();
                        loop = false;
                        break;
                }
            }

        }
    }
    private Dungeons currentDungeon;
    public void Edungeon(DungeonRank rank)
    {
        roomNumber = 3;

        if (hero.level > 5 && hero.hp > 0)
        {
            Console.Clear();
            while (dungeonLoop)
            {
                Console.Clear();

                Console.WriteLine(CenterText.CenterTexts($"=== Du är nu i en {rank}-Rank Dungeon ==="));
                Console.WriteLine(CenterText.CenterTexts($"Du har {4 - roomNumber} rum att klara!\n"));
                
                Console.WriteLine(CenterText.CenterTexts("1. Fortsätt"));
                Console.WriteLine(CenterText.CenterTexts("2. Avbryt"));
                Console.WriteLine(CenterText.CenterTexts("Vill du fortsätta eller avbryta?"));
                string val = Console.ReadLine();
                switch (val)
                {
                    case "1":
                        if (roomNumber < 4)
                        {
                           // Console.Clear();
                            roomNumber++;
                            EnterRoom();

                            // Så att inte Loopen startar om
                            if (roomNumber == 4)
                                dungeonLoop = false;
                        }
                        else
                        {
                            Console.WriteLine(CenterText.CenterTexts("Du har klarat denna Dungeon redan\n"));
                            Console.ReadKey();
                            roomNumber = 0;
                            dungeonLoop = false;
                        }
                        break;

                    case "2":
                        Console.WriteLine(CenterText.CenterTexts("Du går nu ut ur denna Dungeon!\n"));
                        Console.ReadKey();
                        dungeonLoop = false;
                        break;
                }

            }
        }
        else if (hero.hp <= 0)
        {
            Console.WriteLine(CenterText.CenterTexts($"Din hjälte har {hero.hp}:hp, du kan ej fortsätta utan att meditera"));
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine(CenterText.CenterTexts("Tyvärr är du för låg level för att köra denna Dungeon, behöver vara level 5"));
            Console.ReadKey();
        }
    }
    public void ResetDungeon()
    {
        roomNumber = 0;  // Återställ rumsnumret
        dungeonLoop = true;  // Gör det möjligt att starta om dungeonen
    }

    public EquipableItem DropLoot()
    {
        Random random = new Random();
        int dropChance = random.Next(1, 10001); // Slumpa 00.01% till 100%        

        Rarity? rarity = DetermineRarity(dropChance);

        // Om rarity är null, returnerar vi ingen loot.
        if (rarity == null)
        {
            return null;
        }

        // Annars generera ett föremål.
        bool isWeapon = random.Next(0, 2) == 0;        
        EquipableItem item;

        if (isWeapon)
        {
            EquipAbleItem.dungeonWeaponCount++;
            item = new Weapon(CenterText.CenterTexts($"Dungeon Weapon {EquipAbleItem.dungeonWeaponCount}"), rarity.Value);
        }
        else
        {
            ArmorSlot slot = (ArmorSlot)random.Next(0, 5); // Slumpa slot 
            if (slot == ArmorSlot.Head)
            {
                EquipAbleItem.dungeonHeadCount++;
                item = new Armor(CenterText.CenterTexts($"Dungeon {slot} Armor {EquipAbleItem.dungeonHeadCount}"), rarity.Value, slot);
            }
            else if (slot == ArmorSlot.Chest)
            {
                EquipAbleItem.dungeonChestCount++;
                item = new Armor(CenterText.CenterTexts($"Dungeon {slot} Armor {EquipAbleItem.dungeonChestCount}"), rarity.Value, slot);
            }
            else if (slot == ArmorSlot.Legs)
            {
                EquipAbleItem.dungeonLegsCount++;
                item = new Armor(CenterText.CenterTexts($"Dungeon {slot} Armor {EquipAbleItem.dungeonLegsCount}"), rarity.Value, slot);
            }
            else if (slot == ArmorSlot.Feet)
            {
                EquipAbleItem.dungeonFeetCount++;
                item = new Armor(CenterText.CenterTexts($"Dungeon {slot} Armor {EquipAbleItem.dungeonFeetCount}"), rarity.Value, slot);
            }
            else
            {
                EquipAbleItem.dungeonHandsCount++;
                item = new Armor(CenterText.CenterTexts($"Dungeon {slot} Armor {EquipAbleItem.dungeonHandsCount}"), rarity.Value, slot);
            }
        }

        hero.AddToInventory(item);
        return item;

    }

    private Rarity? DetermineRarity(int dropChance)
    {
        switch (Rank)
        {
            case DungeonRank.E:
                if (dropChance <= 2000) return Rarity.Common;           // 20%
                else if (dropChance <= 3000) return Rarity.Uncommon;    // 10% (Över 20%)
                else if (dropChance <= 3100) return Rarity.Rare;        // 1%
                else return null;
            // VeryRare och uppåt är ej tillgängliga i rank E.
            case DungeonRank.D:
                if (dropChance <= 60) return Rarity.Common;
                else if (dropChance <= 85) return Rarity.Uncommon;
                else if (dropChance <= 95) return Rarity.Rare;
                else return Rarity.VeryRare;
            case DungeonRank.C:
                if (dropChance <= 50) return Rarity.Common;
                else if (dropChance <= 80) return Rarity.Uncommon;
                else if (dropChance <= 90) return Rarity.Rare;
                else if (dropChance <= 98) return Rarity.VeryRare;
                else return Rarity.Epic;
            case DungeonRank.B:
                if (dropChance <= 40) return Rarity.Common;
                else if (dropChance <= 70) return Rarity.Uncommon;
                else if (dropChance <= 85) return Rarity.Rare;
                else if (dropChance <= 95) return Rarity.VeryRare;
                else return Rarity.Epic;
            case DungeonRank.A:
                if (dropChance <= 30) return Rarity.Common;
                else if (dropChance <= 60) return Rarity.Uncommon;
                else if (dropChance <= 80) return Rarity.Rare;
                else if (dropChance <= 90) return Rarity.VeryRare;
                else if (dropChance <= 98) return Rarity.Epic;
                else return Rarity.Legendary;
            case DungeonRank.S:
                if (dropChance <= 20) return Rarity.Common;
                else if (dropChance <= 50) return Rarity.Uncommon;
                else if (dropChance <= 70) return Rarity.Rare;
                else if (dropChance <= 85) return Rarity.VeryRare;
                else if (dropChance <= 95) return Rarity.Epic;
                else return Rarity.Mythic;
            default:
                return null; // Standard fallback
        }
    }
}
