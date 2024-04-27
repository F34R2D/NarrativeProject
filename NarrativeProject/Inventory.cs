using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NarrativeProject
{
    public class Collectible
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Collectible(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    public class Inventory
    {
        private List<Collectible> items;

        public Inventory()
        {
            items = new List<Collectible>();
        }

        public void AddCollectible(string name, int quantity)
        {
            Collectible existingItem = items.Find(item => item.Name == name);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new Collectible(name, quantity));
            }


        }
        public void DisplayInventory()
        {
            Console.WriteLine("Inventory Contents:");
            foreach (Collectible item in items)
            {
                Console.WriteLine($"{item.Name}: {item.Quantity}");
            }
        }
    } 



}
