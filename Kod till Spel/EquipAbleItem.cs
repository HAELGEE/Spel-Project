using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kod_till_Spel;
public class EquipAbleItem
{    
    public class EquipableItem
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
            int numberOfAttributes = 0;
            if (ItemRarity.ToString() == "Common")
                numberOfAttributes = random.Next(1, 2); // Exempelvis slumpas 1-3 attributer
            else if (ItemRarity.ToString() == "Uncommon")
                numberOfAttributes = random.Next(1, 3);
            else if (ItemRarity.ToString() == "Rare")
                numberOfAttributes = random.Next(1, 4);

            for (int i = 0; i < numberOfAttributes; i++)
            {
                //Här ska jag fixa så att det ökas med mer attribut vid högre Dungeon
                string attribute = possibleAttributes[random.Next(0, possibleAttributes.Length)];
                int value = 0;

                // Värdet slumpas, 1-10.
                if (ItemRarity.ToString() == "Common")
                    value = random.Next(1, 6); 
                else if (ItemRarity.ToString() == "Uncommon")
                    value = random.Next(2, 8);
                else if (ItemRarity.ToString() == "Rare")
                    value = random.Next(4, 10);

                if (!Attributes.ContainsKey(attribute))
                {
                    Attributes.Add(attribute, value);
                }
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
