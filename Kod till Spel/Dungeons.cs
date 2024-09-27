using System;
using System.Collections.Generic;
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
    /*  Skapa olika slags "dungeons" där det klassas från olika levels (Kanske varje "dungeon" skall vara en viss värld?)
    *   Kanske varje dungeon skall vara rankade från E till S? E, D, C, B, A, S ?
    *   Där varje dungeon har en chans till dropp av items. Som tex en E dungeon enbart kan droppa common och som högst uncommon fast med låg chans?
    *   Typ common = 20% och uncommon 2% ? och Fortsätta så genom alla dungeons där S dungeons är den som har högst chans till att droppa mythic items (men också
    *   svårast att gå igenom)
    *   
    *   Varje dungeon skall innehålla 4 rum där första och tredje rummet innehåller fiender/mobs och andra rummet innehåller en mellan Boss och sista innehåller en Slut boss
    *   Hur får jag bossen till "starkare" ?
    *   
    *   Lägga till guld för varje besegrad motståndare eller klarad dungeon? eller både och?
    */
    Hero hero;
    Attack attack = new Attack();
    OrcBase orc;
    public Random random = new Random();
    Healing healing = new Healing();

    public Dungeons(Hero hero)
    {
        this.hero = hero;
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
                Console.WriteLine(". Och du får 2 extra guld för att klara Bossen");
            }

            if (roomNumber == 4)
            {
                hero.Guld += 4;
                Console.WriteLine(". Och du får 4 extra guld för att klara Bossen");
                EquipableItem loot = currentDungeon.DropLoot();
                Console.WriteLine($"You received: {loot.Name} of rarity {loot.ItemRarity}");
                Console.ReadKey();
            }
            Console.ReadLine();
        }
    }

    public void EnterDungeon()
    {
        bool loop = true;
        while (loop)
        {
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
                    currentDungeon = new Dungeons(DungeonRank.E);
                    Edungeon(DungeonRank.E);
                    break;
                case "2":
                    currentDungeon = new Dungeons(DungeonRank.D);
                    Edungeon(DungeonRank.D);
                    break;
                case "3":
                    currentDungeon = new Dungeons(DungeonRank.C);
                    Edungeon(DungeonRank.C);
                    break;
                case "4":
                    currentDungeon = new Dungeons(DungeonRank.B);
                    Edungeon(DungeonRank.B);
                    break;
                case "5":
                    currentDungeon = new Dungeons(DungeonRank.A);
                    Edungeon(DungeonRank.A);
                    break;
                case "6":
                    currentDungeon = new Dungeons(DungeonRank.S);
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
        roomNumber = 0;
        currentDungeon = new Dungeons(rank);
        if (hero.level > 5 && hero.hp > 0)
        {
            currentDungeon = new Dungeons(rank); // Sätt aktuell dungeon här
            while (dungeonLoop)
            {
                Console.Clear();
                Console.WriteLine($"=== Du har nu gått in i en {rank}-Rank Dungeon ===");
                Console.WriteLine("Du har fyra stycken rum att klara!");
                Console.WriteLine("1. Fortsätt");
                Console.WriteLine("2. Avbryt");
                Console.WriteLine("Vill du fortsätta eller avbryta?");
                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        roomNumber++;
                        if (roomNumber <= 4)
                        {
                            EnterRoom();
                        }
                        else
                        {
                            Console.WriteLine("Du har redan klarat denna Dungeon");
                            Console.ReadKey();
                        }
                        break;

                    case "2":
                        Console.WriteLine("Du går nu ut ur denna Dungeon!");
                        Console.ReadKey();
                        dungeonLoop = false;
                        break;
                }
            }
        }else if (hero.hp <= 0)
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
        int dropChance = random.Next(1, 10001); // Slumpa 1-100

        Rarity? rarity = DetermineRarity(dropChance);

        // Om rarity är null, returnerar vi ingen loot.
        if (rarity == null)
        {
            Console.WriteLine("Tyvärr, ingen loot denna gången");
            return null;
        }

        // Annars generera ett föremål.
        bool isWeapon = random.Next(0, 2) == 0;
        if (isWeapon)
        {
            return new Weapon("Dungeon Weapon", rarity.Value);
        }
        else
        {
            ArmorSlot slot = (ArmorSlot)random.Next(0, 5); // Slumpa slot
            return new Armor("Dungeon Armor", rarity.Value, slot);
        }
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
