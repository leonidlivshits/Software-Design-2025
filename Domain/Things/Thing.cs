using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Things
{
    public class Thing : IInventory
    {
        public int Number { get; set; }
        public string Name { get; set; }

        public Thing(string name, int number)
        {
            Name = name;
            Number = number;
        }

        public override string ToString() =>
            $"Вещь: {Name}, Номер: {Number}";
    }
}

