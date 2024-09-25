using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class Items
{
    public double baseDmg { get; set; } = 2;
    public double baseArmor { get; set; } = 1;
    public double baseSpeed { get; set; } = 1;
    public string name { get; set; }   
    public int hp { get; set; } = 10;
    public int maxHp { get; set; } = 10;
    public int styrka { get; set; } = 1;               //ÖKAR SKADA
    public int agility { get; set; } = 1;              //ÖKAR SPEED
    public int stamina { get; set; } = 1;
    public int charm { get; set; } = 0;
    public int intelligence { get; set; } = 0;
    public int mana { get; set; } = 0;
    public double dmg { get; set; } = 2;                //SKADA
    public double speed { get; set; } = 1;              //SPEED
    public double armor { get; set; } = 1;              //ARMOR
        public int maxXp { get; set; } = 50;
    public int lifeSteal { get; set; } = 0;

    public string ItemName { get; set; }
    public string ItemDescription { get; set; }
    public string ItemClass { get; set; } //Tex Common(grå färg), uncommon(grön färg), rare(blå färg), very rare, Epic(Rosa färg), Legendary(guld färg), Mythic(röd färg)
    public string ItemType { get; set; } //Weapon, cheast, gloves, legs, head, boots
    public int Value { get; set; }
   
    /***	Fixa så man kan ha på sig grejer? Typ Hjälm, tröja, handskar, byxor och skor?
    ***	Och allt detta ger olika attribut beroende på vilken "LEVEL" det är på, kanske levling gear?
    *** Göra så det blir procent på detta? varav 10000 är högst då kan man rolla 00.01% att få saker
    *** Olika rang på saker
    *** Common ca 20% chans? uncommon 10%? rare 5%? very rare 2%? Epic 1%? Legendary 00.5%? Mythic 00.03%? Beroende på vad dom ger kanske?
    ***	Detta droppas från olika dungeons? Beroende på vilken dungeon man befinner sig i.
    */
 

    public Items(string name, string description, string itemType, string itemClass, int value)
    {
        ItemName = name;
        ItemDescription = description;
        ItemType = itemType;
        Value = value;
        ItemClass = itemClass;
    }
    public virtual void ApplyStats(Hero hero)
    {
        //Console.WriteLine("Huvud: ");
        //Console.WriteLine("Kropp: ");
        //Console.WriteLine("Ben: ");
        //Console.WriteLine("Händer: ");
        //Console.WriteLine("Fötter: ");
        //Console.WriteLine($"Vapen: ");
    }
}
class CommonItems    //20%? drop chans
{
    //List<Items> CommonItems = new List<Items>();
    //List<Items> UnCommonItems = new List<Items>();
    //List<Items> RareItems = new List<Items>();
    //List<Items> VeryRareItems = new List<Items>();
    //List<Items> VeryRareItems = new List<Items>();
    //List<Items> EpicItems = new List<Items>();
    //List<Items> LegendaryItems = new List<Items>();
    //List<Items> MythicItems = new List<Items>();
    public void Common()
    {
        InitializeCommonItems();        ;
    }

    public void InitializeCommonItems()
    { 
        //commonItems.Add(new Items("LifeStealer", "Ett försvunnet svärd som ger liv tillbaka vid träff", "Weapon", "Common", 10));
        //commonItems.Add(new Items("Plate", "En stekpanna som armor för bröstet", "Cheast", "Common", 1));

    }

    //Här skall jag bygga in så jag får ett random item ur mina items. Så jag inte alltid har dom! Och om jag får ett jag redan har så skall det komma upp
    //public Items GetRandomCommonItem()      
    //{
    //    Random random = new Random();
    //    int rng = random.Next(0, 101);
    //    //if (rng <= 20)
    //    //{
    //    //    return commonItems[rng];
    //    //}
    //    //else if (rng <= 5)
    //    //{
    //    //    return UnCommonItems[rng];
    //    //}
    //    //else
    //    //    return null;
    //}



    //VAPEN
    //void lifeStealer()
    //{

    //    this.styrka++;
    //    this.agility++;
    //    this.stamina++;
    //    this.intelligence++;
    //    this.charm++;
    //    this.lifeSteal += 2;
    //}
}


//class UncommonItems : Items  //10%?
//{

//}

//class RareItems : Items  //5%?
//{

//}
//class VeryRareItems : Items  //2%?
//{

//}
//class EpicItems : Items    //1%?
//{

//}
//class LegendaryItems : Items     //0.5% ?
//{

//}
//class MythicItems : Items   //0.03%?
//{

//}

