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
}