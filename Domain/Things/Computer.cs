using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Things
{
    /// <summary>
    /// Компьютер.
    /// </summary>
    public class Computer : Thing
    {
        public Computer(string name, uint number, uint quantity = 1)
            : base(name, number, quantity)
        {
        }
        public override string ToString() =>
            $"Компьютер: {Name}, Номер: {Number}, Количество: {Quantity}";
    }
}

