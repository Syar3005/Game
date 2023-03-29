using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igra
{
    class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public string Mod { get; set; }

        public Item(string name, int weight, string mod)
        {
            Name = name;
            Weight = weight;
            Mod = mod;
        }
    }
}
