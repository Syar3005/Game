using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igra
{
    class Hero
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Hero(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }
    }
}
