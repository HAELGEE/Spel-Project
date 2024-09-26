using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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

    public bool dungeonLoop = true;
    public string keepGoing;
    public static int roomNumber = 0;
    public static char rank;
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
                    ResetDungeon();
                    Edungeon('E');
                    break;
                case "2":
                    ResetDungeon();
                    Edungeon('D');
                    break;
                case "3":
                    ResetDungeon();
                    Edungeon('C');
                    break;
                case "4":
                    ResetDungeon();
                    Edungeon('B');
                    break;
                case "5":
                    ResetDungeon();
                    Edungeon('A');
                    break;
                case "6":
                    ResetDungeon();
                    Edungeon('S');
                    break;

                case "7":
                    Console.WriteLine("Du går nu tillbaka");
                    Console.ReadKey();
                    loop = false;
                    break;
            }
        }
    }
    public void Edungeon(char rank)
    {
        if (hero.level > 5 && hero.hp > 0)
        {
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

    //public string Rank { get; set; }
    //public List<Room> Rooms { get; set; }

    //public Dungeons(string rank)
    //{
    //    Rank = rank;
    //    Rooms = GenerateRoomsForRank(rank);
    //}

    //private List<Room> GenerateRoomsForRank(string rank)
    //{
    //    // Skapa en lista med rum och sätt deras innehåll baserat på rank
    //    List<Room> rooms = new List<Room>();
    //    rooms.Add(new Room("Room 1 - Mobs", GenerateEnemy(rank), null));
    //    rooms.Add(new Room("Room 2 - Mid Boss", GenerateBoss(rank), null));
    //    rooms.Add(new Room("Room 3 - Mobs", GenerateEnemy(rank), null));
    //    rooms.Add(new Room("Room 4 - Final Boss", GenerateBoss(rank), GenerateLoot(rank)));

    //    return rooms;
    //}

    //private Enemy GenerateEnemy(string rank)
    //{
    //    // Logik för att skapa fiender baserat på dungeon-rank
    //    return new Enemy("Standard Mob", CalculateEnemyStats(rank));
    //}

    //private Enemy GenerateBoss(string rank)
    //{
    //    // Logik för att skapa bossar baserat på rank
    //    return new Enemy("Dungeon Boss", CalculateBossStats(rank));
    //}

    //private Item GenerateLoot(string rank)
    //{
    //    Random rand = new Random();
    //    int roll = rand.Next(1, 101);  // Slumpar från 1 till 100

    //    switch (rank)
    //    {
    //        case "E":
    //            if (roll <= 20) return new Item("Common Item");
    //            else if (roll <= 22) return new Item("Uncommon Item");
    //            break;
    //        case "D":
    //            if (roll <= 30) return new Item("Common Item");
    //            else if (roll <= 35) return new Item("Uncommon Item");
    //            break;
    //        // Lägg till logik för andra ranker...
    //        case "S":
    //            if (roll <= 50) return new Item("Rare Item");
    //            else if (roll <= 55) return new Item("Mythic Item");
    //            break;
    //    }
    //    return new Item("Nothing");
    //}



    //public void CompleteDungeon(Dungeons dungeon)
    //{
    //    foreach (Room room in dungeon.Rooms)
    //    {
    //        Console.WriteLine(room.Description);

    //        if (room.Enemy != null)
    //        {
    //            Console.WriteLine($"You encountered {room.Enemy.Name}");
    //            attack.DungeonAttack(hero, room.Enemy);

    //            // Belöning för besegrad fiende
    //            int goldReward = room.Enemy.GoldDrop;
    //            hero.Guld += goldReward;
    //            Console.WriteLine($"You earned {goldReward} gold.");
    //        }

    //        if (room.Loot != null)
    //        {
    //            Console.WriteLine($"You found a {room.Loot.Name}!");
    //            hero.Inventory.Add(room.Loot);
    //        }
    //    }

    //    // Extra belöning för att klara hela dungeonen
    //    hero.Guld += dungeon.CompletionReward;
    //    Console.WriteLine($"Dungeon completed! You earned an additional {dungeon.CompletionReward} gold.");
    //}
}
