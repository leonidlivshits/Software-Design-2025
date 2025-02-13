using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;
using ZooManagement.Domain.Herbos;
using ZooManagement.Domain.Predators;
using ZooManagement.Domain.Things;

namespace ZooManagement.Services
{
    public class ZooService : IZooService
    {
        private readonly IVeterinaryClinic _veterinaryClinic;
        private readonly HashSet<Animal> _animals;
        private readonly HashSet<Thing> _inventoryItems;

        public ZooService(IVeterinaryClinic veterinaryClinic)
        {
            _veterinaryClinic = veterinaryClinic;
            _animals = new HashSet<Animal>();
            _inventoryItems = new HashSet<Thing>();
        }

        /// <summary>
        /// Добавление животного (после проверки ветеринаром).
        /// </summary>
        public bool AddAnimal(Animal animal)
        {
            if (_veterinaryClinic.Examine(animal))
            {
                if (_animals.Add(animal))
                {
                    return true;
                }
                Console.WriteLine("Животное с таким именем и номером уже есть!");
            }
            return false;
        }

        /// <summary>
        /// Возвращает общее количество еды от животных.
        /// </summary>
        public long GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.Food);
        }

        /// <summary>
        /// Возвращает список животных, подходящих для контактного зоопарка.
        /// (травоядные с уровнем доброты выше 5)
        /// </summary>
        public IEnumerable<Animal> GetContactZooAnimals()
        {
            return _animals.OfType<Herbo>().Where(h => h.Kindness > 5);
        }

        /// <summary>
        /// Возвращает все объекты.
        /// </summary>
        public IEnumerable<IInventory> GetInventoryItems()
        {
            return _inventoryItems;
        }

        /// <summary>
        /// Возвращает список добавленных животных.
        /// </summary>
        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }

        /// <summary>
        /// Добавляет новую инвентарь.
        /// </summary>
        public void AddInventoryItem(IInventory item)
        {
            if (item is Thing thing)
            {
                var existingThing = _inventoryItems.FirstOrDefault(t => t.Equals(thing)); // Проверяем, есть ли уже такая вещь
                if (existingThing != null)
                {
                    existingThing.IncreaseQuantity(thing.Quantity);
                }
                else
                {
                    _inventoryItems.Add(thing);
                }
            }
        }
    }


}