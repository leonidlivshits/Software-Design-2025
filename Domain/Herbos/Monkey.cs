using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain.Herbos;

namespace ZooManagement.Domain.Herbos
{
    public class Monkey : Herbo
    {
        public Monkey(string name, int food, int number, int kindness)
            : base(name, food, number, kindness)
        {
        }

        public override string ToString() =>
            $"Бибизяна: {Name}, Номер: {Number}, Еда: {Food} кг, Доброта: {Kindness}";
    }
}

