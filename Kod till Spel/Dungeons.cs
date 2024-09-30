using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static Kod_till_Spel.Armor;
using static Kod_till_Spel.EquipAbleItem;

namespace Kod_till_Spel;
public class Dungeons
{
    Hero hero;
    Attack attack = new Attack();
    OrcBase orc;
    public Random random = new Random();
    Healing healing = new Healing();

    public int dungeonWeaponCount = 0;
    public int dungeonHeadCount = 0;
    public int dungeonChestCount = 0;
    public int dungeonHandsCount = 0;
    public int dungeonLegsCount = 0;
    public int dungeonFeetCount = 0;

    public Dungeons(Hero Hero)
    {
        this.hero = Hero;
        orc = new OrcBase(hero);
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
        Console.WriteLine($"Du är nu i rum {roomNumber}");
        attack.DungeonAttack(hero);
        if (hero.hp <= 0)
        {
            bool loop = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Din hjälte är död, du kan inte fortsätta");
                Console.WriteLine("Meditera för att försöka igen? J/N");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "J")      //Lägger till ett val för användaren för att se om dom vill försöka på detta rummet igen
                {
                    healing._Healing(hero);     //Om ja
                    roomNumber--;
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
            Console.WriteLine($"Grattis, du klarade rum {roomNumber}");
            Console.Write($"\nDu fick {rng} guld för att klara rum {roomNumber}");
            hero.Guld += rng;
            if (roomNumber == 2)
            {
                hero.Guld += 2;
                Console.Write(". Och du får 2 extra guld för att klara Bossen");
            }

            if (roomNumber == 4)
            {
                hero.Guld += 4;
                Console.Write(". Och du får 4 extra guld för att klara Bossen");
                EquipableItem loot = currentDungeon.DropLoot();
                if (loot != null)
                    Console.WriteLine($"Du hittade: {loot.Name} av rank {loot.ItemRarity} ");
                else Console.WriteLine("\nTyvärr, ingen loot denna gången");

                Console.ReadKey();
            }

        }
    }

    public void EnterDungeon()
    {
        bool loop = true;
        while (loop)
        {
            Console.Clear();
            Console.WriteLine("Vilken dungeon vill du gå in i?");
            Console.WriteLine("1. E-Dungeon");
            Console.WriteLine("2. D-Dungeon");
            Console.WriteLine("3. C-Dungeon");
            Console.WriteLine("4. B-Dungeon");
            Console.WriteLine("5. A-Dungeon");
            Console.WriteLine("6. S-Dungeon");
            Console.WriteLine("7. Tillabaka");
            string val = Console.ReadLine()!.ToUpper();

            switch (val)
            {
                case "1":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.E);
                    break;
                case "2":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.D);
                    break;
                case "3":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.C);
                    break;
                case "4":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.B);
                    break;
                case "5":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.A);
                    break;
                case "6":
                    ResetDungeon();
                    currentDungeon = new Dungeons(hero);
                    Edungeon(DungeonRank.S);
                    break;

                case "7":
                    Console.WriteLine("Du går nu tillbaka");
                    Console.ReadKey();
                    loop = false;
                    break;
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
            Console.WriteLine($"=== Du har nu gått in i en {rank}-Rank Dungeon ===");
            Console.Write("Du har fyra stycken rum att klara!");
            while (dungeonLoop)
            {

                Console.WriteLine("\n\n1. Fortsätt");
                Console.WriteLine("2. Avbryt");
                Console.WriteLine("Vill du fortsätta eller avbryta?");
                string val = Console.ReadLine();
                switch (val)
                {
                    case "1":
                        if (roomNumber < 4)
                        {
                            roomNumber++;
                            EnterRoom();
                        }
                        else
                        {
                            Console.WriteLine("Du har klarat denna Dungeon redan\n");
                            Console.ReadKey();
                            roomNumber = 0;
                            dungeonLoop = false;
                        }
                        break;

                    case "2":
                        Console.WriteLine("Du går nu ut ur denna Dungeon!\n");
                        Console.ReadKey();
                        dungeonLoop = false;
                        break;
                }
            }
        }
        else if (hero.hp <= 0)
        {
            Console.WriteLine($"Din hjälte har {hero.hp}:hp, du kan ej fortsätta utan att meditera");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Tyvärr är du för låg level för att köra denna Dungeon");
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
            dungeonWeaponCount++;
            item = new Weapon($"Dungeon Weapon {dungeonWeaponCount++}", rarity.Value);
        }
        else
        {            
            ArmorSlot slot = (ArmorSlot)random.Next(0, 5); // Slumpa slot 
            if (slot == ArmorSlot.Head)
            {
                dungeonHeadCount++;
                item = new Armor($"Dungeon {slot} Armor {dungeonHeadCount++}", rarity.Value, slot);
            }else if (slot == ArmorSlot.Chest)
            {
                dungeonChestCount++;
                item = new Armor($"Dungeon {slot} Armor {dungeonChestCount++}", rarity.Value, slot);
            }else if (slot == ArmorSlot.Legs)
            {
                dungeonLegsCount++;
                item = new Armor($"Dungeon {slot} Armor {dungeonLegsCount++}", rarity.Value, slot);
            }else if (slot == ArmorSlot.Feet)
            {
                dungeonFeetCount++;
                item = new Armor($"Dungeon {slot} Armor {dungeonFeetCount++}", rarity.Value, slot);
            }else 
            {
                dungeonHandsCount++;
                item = new Armor($"Dungeon {slot} Armor {dungeonHandsCount++}", rarity.Value, slot);
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
