using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Predators
{
    public class Wolf : Predator
    {
        public Wolf(string name, uint food, uint number)
            : base(name, food, number)
        {
        }

        public override string ToString() =>
            $"Волк: {Name}, Номер: {Number}, Еда: {Food} кг";
    }
}

