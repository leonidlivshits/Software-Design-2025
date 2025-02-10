using System;
using Microsoft.Extensions.DependencyInjection;
using ZooManagement.Domain;
using ZooManagement.Domain.Herbos;
using ZooManagement.Domain.Predators;
using ZooManagement.Domain.Things;
using ZooManagement.Services;

namespace ZooManagement
{
    /// <summary>
    /// Точка входа приложения. Настраивает DI-контейнер и предоставляет консольное меню.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI-контейнера
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IVeterinaryClinic, VeterinaryClinic>()
                .AddSingleton<IZooService, ZooService>()
                .BuildServiceProvider();

            var zooService = serviceProvider.GetService<IZooService>();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Московский зоопарк ERP ---");
                Console.WriteLine("1. Добавить животное");
                Console.WriteLine("2. Вывести отчет");
                Console.WriteLine("3. Добавить инвентарную вещь");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите опцию: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAnimal(zooService);
                        break;
                    case "2":
                        ShowReport(zooService);
                        break;
                    case "3":
                        AddInventoryItem(zooService);
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void AddAnimal(IZooService zooService)
        {
            Console.WriteLine("\nВыберите тип животного:");
            Console.WriteLine("1. Кролик (Rabbit)");
            Console.WriteLine("2. Обезьяна (Monkey)");
            Console.WriteLine("3. Тигр (Tiger)");
            Console.WriteLine("4. Волк (Wolf)");
            Console.Write("Ваш выбор: ");
            var typeChoice = Console.ReadLine();

            Console.Write("Введите имя животного: ");
            string name = Console.ReadLine();

            Console.Write("Введите количество потребляемой еды (кг): ");
            int food = int.Parse(Console.ReadLine());

            Console.Write("Введите инвентаризационный номер: ");
            int number = int.Parse(Console.ReadLine());

            Animal animal = null;
            switch (typeChoice)
            {
                case "1": // Rabbit
                    Console.Write("Введите уровень доброты (0-10): ");
                    int kindnessRabbit = int.Parse(Console.ReadLine());
                    animal = new Rabbit(name, food, number, kindnessRabbit);
                    break;
                case "2": // Monkey
                    Console.Write("Введите уровень доброты (0-10): ");
                    int kindnessMonkey = int.Parse(Console.ReadLine());
                    animal = new Monkey(name, food, number, kindnessMonkey);
                    break;
                case "3": // Tiger
                    animal = new Tiger(name, food, number);
                    break;
                case "4": // Wolf
                    animal = new Wolf(name, food, number);
                    break;
                default:
                    Console.WriteLine("Неверный выбор типа животного.");
                    return;
            }

            if (zooService.AddAnimal(animal))
            {
                Console.WriteLine("Животное успешно добавлено в зоопарк.");
            }
            else
            {
                Console.WriteLine("Животное не прошло медосмотр и не добавлено.");
            }
        }

        private static void AddInventoryItem(IZooService zooService)
        {
            Console.WriteLine("\nВыберите тип инвентарной вещи:");
            Console.WriteLine("1. Предмет (Thing)");
            Console.WriteLine("2. Стол (Table)");
            Console.WriteLine("3. Компьютер (Computer)");
            Console.Write("Ваш выбор: ");
            var typeChoice = Console.ReadLine();

            Console.Write("Введите наименование: ");
            string name = Console.ReadLine();

            Console.Write("Введите инвентаризационный номер: ");
            int number = int.Parse(Console.ReadLine());

            IInventory item = null;
            switch (typeChoice)
            {
                case "1":
                    item = new Thing(name, number);
                    break;
                case "2":
                    item = new Table(name, number);
                    break;
                case "3":
                    item = new Computer(name, number);
                    break;
                default:
                    Console.WriteLine("Неверный выбор типа вещи.");
                    return;
            }

            zooService.AddInventoryItem(item);
            Console.WriteLine("Инвентарная вещь успешно добавлена.");
        }

        private static void ShowReport(IZooService zooService)
        {
            Console.WriteLine("\n--- Отчет ---");

            // Вывод списка животных
            var animals = zooService.GetAnimals();
            Console.WriteLine("\nЖивотные, находящиеся на балансе зоопарка:");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine($"\nОбщее количество животных: {animals.Count()}");
            Console.WriteLine($"Общее количество потребляемой еды: {zooService.GetTotalFoodConsumption()} кг/день");

            // Вывод списка животных для контактного зоопарка
            Console.WriteLine("\nЖивотные, подходящие для контактного зоопарка (травоядные с добротой > 5):");
            var contactAnimals = zooService.GetContactZooAnimals();
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine(animal.ToString());
            }

            // Вывод инвентарных вещей
            Console.WriteLine("\nИнвентарные вещи:");
            var items = zooService.GetInventoryItems();
            foreach (var item in items)
            {
                string itemName = "";
                if (item is Animal a)
                    itemName = a.Name;
                else if (item is Thing t)
                    itemName = t.Name;
                Console.WriteLine($"{item.GetType().Name}: {itemName}, Инв. номер: {item.Number}");
            }
        }
    }
}
