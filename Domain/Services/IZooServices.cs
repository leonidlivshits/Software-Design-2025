using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Services
{
    public interface IZooService
    {
        /// <summary>
        /// Добавление животного (после проверки ветеринаром).
        /// </summary>
        bool AddAnimal(Animal animal);

        /// <summary>
        /// Возвращает общее количество еды от животных.
        /// </summary>
        long GetTotalFoodConsumption();

        /// <summary>
        /// Возвращает список животных, подходящих для контактного зоопарка.
        /// (травоядные с уровнем доброты выше 5)
        /// </summary>
        IEnumerable<Animal> GetContactZooAnimals();

        /// <summary>
        /// Возвращает все объекты.
        /// </summary>
        IEnumerable<IInventory> GetInventoryItems();

        /// <summary>
        /// Возвращает добавленных животных.
        /// </summary>
        IEnumerable<Animal> GetAnimals();

        /// <summary>
        /// Добавляет новую инвентарь.
        /// </summary>
        void AddInventoryItem(IInventory item);
    }
}