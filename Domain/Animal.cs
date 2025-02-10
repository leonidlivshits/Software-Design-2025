using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagement.Domain
{
    public abstract class Animal : IAlive, IInventory
    {
        public int Food { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }

        protected Animal(string name, int food, int number)
        {
            Name = name;
            Food = food;
            Number = number;
        }
    }
}
