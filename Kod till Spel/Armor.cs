using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kod_till_Spel.EquipAbleItem;

namespace Kod_till_Spel;
public class Armor : EquipableItem
{
    public ArmorSlot Slot { get; set; }

    public Armor(string name, Rarity rarity, ArmorSlot slot)
        : base(name, rarity)
    {
        Slot = slot;
    }

    public enum ArmorSlot
    {
        Head,
        Chest,
        Hands,
        Legs,
        Feet
    }
}
