using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class Weapon : Item
{
    public int WeaponDamage { get; set; }           //Ökar damage
    public int styrka {  get; set; }                //Ökar damage
    public int agility { get; set; }                //ÖKAR SPEED och armor
    public int stamina { get; set; }
    public int charm { get; set; }
    public int intelligence { get; set; }           //Ökar spellDmg
    public int lifeSteal { get; set; }   
    //Ökar lifesteal
    //public Weapon(string name, string description, string itemType, string itemClass, int value, int damage, int styrka, int agility, int stamina, int charm, int intelligence, int lifeSteal)
    //    : base(name, description, itemType, itemClass, value)
    //{
    //    WeaponDamage = damage;
    //    this.styrka = styrka;
    //    this.agility = agility;
    //    this.stamina = stamina;
    //    this.charm = charm;
    //    this.intelligence = intelligence;
    //    this.lifeSteal = lifeSteal;
    //}

    //public override void ApplyStats(Hero hero)
    //{
    //    hero.dmg += WeaponDamage;
    //    hero.styrka += this.styrka;
    //    hero.agility += this.agility;
    //    hero.charm += this.charm;
    //    hero.intelligence += this.intelligence;
    //    hero.stamina += this.stamina;
    //    hero.lifeSteal += this.lifeSteal;

    //}

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