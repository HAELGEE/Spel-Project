using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class EquipAbleItem
{
    public class EquipableItem : Item
    {
        public string Name { get; set; }
        public Rarity ItemRarity { get; set; }
        public Dictionary<string, int> Attributes { get; set; } = new Dictionary<string, int>();

        public EquipableItem(string name, Rarity rarity)
        {
            Name = name;
            ItemRarity = rarity;
            GenerateRandomAttributes();
        }

        private void GenerateRandomAttributes()
        {
            Random random = new Random();
            string[] possibleAttributes = { "Strength", "Agility", "HPBoost", "Lifesteal", "Intelligence", "Mana" };
            int numberOfAttributes = random.Next(1, 4); // Exempelvis slumpas 1-3 attributer

            for (int i = 0; i < numberOfAttributes; i++)
            {
                string attribute = possibleAttributes[random.Next(0, possibleAttributes.Length)];
                int value = random.Next(1, 101); // Värdet slumpas, 1-100.
                Attributes[attribute] = value;
            }
        }
    }
    public enum Rarity
    {        
        Common,
        Uncommon,
        Rare,
        VeryRare,
        Epic,
        Legendary,
        Mythic
    }
}
