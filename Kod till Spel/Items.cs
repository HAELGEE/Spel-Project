using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
internal class Items
{    public double baseDmg { get; set; } = 2;
    public double baseArmor { get; set; } = 1;
    public double baseSpeed { get; set; } = 1;
    public string name { get; set; }
    public int level { get; set; } = 4;
    public double experience { get; set; } = 0;
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
    public int xp { get; set; } = 0;
    public int maxXp { get; set; } = 50;
    public int lifeSteal { get; set; } = 0;

    private Random random = new Random();
    /***	Fixa så man kan ha på sig grejer? Typ Hjälm, tröja, handskar, byxor och skor?
    ***	Och allt detta ger olika attribut beroende på vilken "LEVEL" det är på, kanske levling gear?
    *** Göra så det blir procent på detta? varav 10000 är högst då kan man rolla 00.01% att få saker
    *** Olika rang på saker
    *** Common ca 20% chans? uncommon 10%? rare 5%? very rare 2%? Epic 1%? Legendary 00.5%? Mythic 00.03%? Beroende på vad dom ger kanske?
    ***	Detta droppas från olika dungeons? Beroende på vilken dungeon man befinner sig i.
    */
    public void lifeStealer()
    {
        styrka++;
        agility++;
        stamina++;
        intelligence++;
        charm++;
        lifeSteal += 2;
    }
}
