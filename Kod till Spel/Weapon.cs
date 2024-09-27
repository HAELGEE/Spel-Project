using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Kod_till_Spel.EquipAbleItem;

namespace Kod_till_Spel;
public class Weapon : EquipableItem
{
    public Weapon(string name, Rarity rarity)
        : base(name, rarity)
    {
    }


    //lista med olika vapen, dessa har olika klasser "Common, rare, mythic osv"
    //public static List<Weapon> GetAllWeapons()
    //{
    //    return new List<Weapon>()  // name, description, itemType, itemClass, value, damage, styrka, agility, stamina, charm, intelligence, lifeSteal
    //    {
    //        //Common 
    //        new Weapon("Short Sword", "Ett litet svärd med grundläggande skada", "Weapon", "Common", 10, 1, 0, 1, 0, 0, 0, 0),
    //        new Weapon("Dagger", "En dagger för lätt rörelse med grundläggande skada", "Weapon", "Common", 10, 0, 1, 0, 0, 0, 0, 0),

    //        //UnCommon

    //        //Rare
    //        new Weapon("Long Sword", "Ett stort svärd med högre skada", "Weapon", "Rare", 50, 0, 0, 0, 0, 1, 1, 1),

    //        //Very Rare

    //        //Epic

    //        //Legendary
    //        new Weapon("LifeStealer", "Ett försvunnet svärd som ger liv tillbaka vid träff", "Weapon", "Legendary", 100, 0, 1, 1, 1, 1, 1, 1),

    //        //Mythic
    //    };
    //}


}