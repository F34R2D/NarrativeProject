using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject
{
    internal class Weapon
    {
        class Item
        {
            public string Name { get; protected set; }

            public Item(string name)
            {
                Name = name;
            }
        }

        
        class Saber : Item
        {
            public Saber() : base("Saber")
            {
            }
        }

        
        class Grenade : Item
        {
            public Grenade() : base("Grenade")
            {
            }
        }

        
        class Flamethrower : Item
        {
            public Flamethrower() : base("Flamethrower")
            {
            }
        }

        class Player
        {
            private Item[] inventory;

            public Player()
            {
                inventory = new Item[3];
            }

            public void AddToInventory(Item item, int index)
            {
                inventory[index] = item;
            }

            public void OpenInventory()
            {
                Console.WriteLine("Player's Inventory:");
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] != null)
                    {
                        Console.WriteLine($"{i + 1}. {inventory[i].Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}. Empty");
                    }
                }
            }
        }
    }
}

        