using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Domain.Things
{
    /// <summary>
    /// Класс вещи, реализует интерфейс IInventory
    /// </summary>
    public class Thing : IInventory
    {
        public uint Number { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Добавил количество, если у нас есть одинаковые объекты, то мы увеличиваем количество.
        /// У животных такого нет, потому что двух одинаковых животных в зооопарке в моем понимании быть не должно.
        /// </summary>
        public uint Quantity { get; private set; }

        public Thing(string name, uint number, uint quantity = 1)
        {
            Name = name;
            Number = number;
            Quantity = quantity;
        }

        public void IncreaseQuantity(uint amount)
        {
            if (amount > 0)
            {
                Quantity += amount;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is Thing other)
            {
                return Name == other.Name && Number == other.Number;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Number);
        }



        public override string ToString() =>
            $"Вещь: {Name}, Номер: {Number}, Количество: {Quantity}";
    }
}

