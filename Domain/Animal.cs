using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagement.Domain
{
    public abstract class Animal : IAlive, IInventory
    {
        public uint Food { get; set; }
        public uint Number { get; set; }
        public string Name { get; set; }

        protected Animal(string name, uint food, uint number)
        {
            Name = name;
            Food = food;
            Number = number;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Animal other)
            {
                return Name == other.Name && Number == other.Number;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Number);
        }

    }
}
