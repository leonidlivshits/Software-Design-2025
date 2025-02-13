using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Herbos
{
    public abstract class Herbo : Animal
    {
        public uint Kindness { get; set; }

        protected Herbo(string name, uint food, uint number, uint kindness)
            : base(name, food, number)
        {
            Kindness = kindness;
        }
    }
}

