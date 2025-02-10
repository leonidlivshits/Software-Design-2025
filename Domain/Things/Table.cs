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
        public Table(string name, int number)
            : base(name, number)
        {
        }

        public override string ToString() =>
            $"Стол: {Name}, Номер: {Number}";
    }
}

