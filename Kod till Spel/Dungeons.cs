using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
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
    *   
    *   Lägga till guld för varje besegrad motståndare eller klarad dungeon? eller både och?
    */
    Hero hero { get; set; }
    Attack attack = new Attack();
    public Dungeons(Hero hero)
    {
        this.hero = hero;
    }

    public void Edungeon()
    {
        if (hero.level > 5)
        {
            attack.DungeonAttack(hero);
        }
        else
        {
            Console.WriteLine("Tyvärr är du för låg level för att köra denna Dungeon");
            Console.ReadKey();
        }
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
