using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igra
{
    class Backpack
    {
        public List<Item> Items { get; set; }
        public int MaxSlots { get; set; }
        public int MaxWeight { get; set; }
        public int RemainingWeight { get { return MaxWeight - Items.Sum(item => item.Weight); } }

        public Backpack(int maxSlots)
        {
            Items = new List<Item>();
            MaxSlots = maxSlots;
            MaxWeight = maxSlots * 10;
        }

        public void AddItem(Item item)
        {
            if (RemainingWeight >= item.Weight)
            {
                Items.Add(item);
                Console.WriteLine($"{item.Name} добавлен в рюкзак");
            }
            else
            {
                Console.WriteLine($"{item.Name} не поместится в рюкзак. Освободите место.");
            }
        }

        public void RemoveItem(Item item)
        {
            if (Items.Remove(item))
            {
                Console.WriteLine($"{item.Name} удален с рюкзака");
            }
            else
            {
                Console.WriteLine($"{item.Name} не найден в рюкзаке");
            }
        }

        public int GetFreeSlots()
        {
            return MaxSlots - Items.Count;
        }

        public int GetRemainingWeight()
        {
            return RemainingWeight;
        }
    }
}

