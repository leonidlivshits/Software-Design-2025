using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Things
{
    public class Table : Thing
    {
        public Table(string name, uint number, uint quantity = 1)
            : base(name, number, quantity)
        {
        }

        public override string ToString() =>
            $"Стол: {Name}, Номер: {Number}, Количество: {Quantity}";
    }
}

