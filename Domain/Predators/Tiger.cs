using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Predators
{
    public class Tiger : Predator
    {
        public Tiger(string name, int food, int number)
            : base(name, food, number)
        {
        }

        public override string ToString() =>
            $"Тигр: {Name}, Номер: {Number}, Еда: {Food} кг";
    }
}

