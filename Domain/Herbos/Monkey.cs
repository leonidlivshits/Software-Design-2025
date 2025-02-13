using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain.Herbos;

namespace ZooManagement.Domain.Herbos
{
    /// <summary>
    /// Класс обезьяны, наследую абстрактный класс травоядных.
    /// </summary>
    public class Monkey : Herbo
    {
        public Monkey(string name, uint food, uint number, uint kindness)
            : base(name, food, number, kindness)
        {
        }

        public override string ToString() =>
            $"Обезьяна: {Name}, Номер: {Number}, Еда: {Food} кг, Доброта: {Kindness}";
    }
}

