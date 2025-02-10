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
        /// Проводит добавление животного (после проверки ветеринаром).
        /// </summary>
        bool AddAnimal(Animal animal);

        /// <summary>
        /// Возвращает общее количество еды, потребляемой животными.
        /// </summary>
        int GetTotalFoodConsumption();

        /// <summary>
        /// Возвращает список животных, подходящих для контактного зоопарка.
        /// (травоядные с уровнем доброты выше 5)
        /// </summary>
        IEnumerable<Animal> GetContactZooAnimals();

        /// <summary>
        /// Возвращает все объекты, находящиеся на балансе (животные и вещи).
        /// </summary>
        IEnumerable<IInventory> GetInventoryItems();

        /// <summary>
        /// Возвращает список добавленных животных.
        /// </summary>
        IEnumerable<Animal> GetAnimals();

        /// <summary>
        /// Добавляет новую инвентарную вещь.
        /// </summary>
        void AddInventoryItem(IInventory item);
        
    }
}