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
    //public class ZooService : IZooService
    //{
    //    private readonly IVeterinaryClinic _veterinaryClinic;
    //    private readonly List<Animal> _animals;
    //    private readonly List<IInventory> _inventoryItems;

    //    public ZooService(IVeterinaryClinic veterinaryClinic)
    //    {
    //        _veterinaryClinic = veterinaryClinic;
    //        _animals = new List<Animal>();
    //        _inventoryItems = new List<IInventory>();
    //    }

    //    public bool AddAnimal(Animal animal)
    //    {
    //        if (_veterinaryClinic.Examine(animal))
    //        {
    //            _animals.Add(animal);
    //            _inventoryItems.Add(animal);
    //            return true;
    //        }
    //        return false;
    //    }

    //    public long GetTotalFoodConsumption()
    //    {
    //        return _animals.Sum(a => a.Food);
    //    }

    //    public IEnumerable<Animal> GetContactZooAnimals()
    //    {
    //        return _animals.OfType<Herbo>().Where(h => h.Kindness > 5);
    //    }

    //    public IEnumerable<IInventory> GetInventoryItems()
    //    {
    //        return _inventoryItems;
    //    }

    //    public IEnumerable<Animal> GetAnimals()
    //    {
    //        return _animals;
    //    }

    //    public void AddInventoryItem(IInventory item)
    //    {
    //        _inventoryItems.Add(item);
    //    }
    //}


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

        public long GetTotalFoodConsumption()
        {
            return _animals.Sum(a => a.Food);
        }

        public IEnumerable<Animal> GetContactZooAnimals()
        {
            return _animals.OfType<Herbo>().Where(h => h.Kindness > 5);
        }

        public IEnumerable<IInventory> GetInventoryItems()
        {
            return _inventoryItems;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }

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