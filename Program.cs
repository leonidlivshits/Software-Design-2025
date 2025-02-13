/*using System;
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
        *//*private static Animal choiceOfAnimal()
        {

            Animal animal = null;
            return animal;
        }*//*
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
*/


using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Приложение декомпозировано на функции, каждая из которых отвечает за отдельную задачу:
    /// - Ввод данных и их валидация;
    /// - Создание объектов;
    /// - Вывод информации на консоль.
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
                DisplayMainMenu();
                string choice = Console.ReadLine()?.Trim();
                Console.Clear();
                switch (choice)
                {
                    case "1":
                        HandleAddAnimal(zooService);
                        break;
                    case "2":
                        HandleShowReport(zooService);
                        break;
                    case "3":
                        HandleAddInventoryItem(zooService);
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

        /// <summary>
        /// Отображает главное меню приложения.
        /// </summary>
        private static void DisplayMainMenu()
        {
            Console.WriteLine("\n--- Московский зоопарк ERP ---");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Вывести отчет");
            Console.WriteLine("3. Добавить инвентарную вещь");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите опцию: ");
        }

        /// <summary>
        /// Обрабатывает добавление животного: получает данные, создает объект животного,
        /// передает его в сервис и выводит результат.
        /// </summary>
        private static void HandleAddAnimal(IZooService zooService)
        {
            Animal animal = CreateAnimal();
            if (animal == null)
            {
                Console.WriteLine("Ошибка создания животного.");
                return;
            }

            if (zooService.AddAnimal(animal))
                Console.WriteLine("Животное успешно добавлено в зоопарк.");
            else
                Console.WriteLine("Животное не прошло медосмотр и не добавлено.");
        }

        /// <summary>
        /// Обрабатывает добавление инвентарной вещи: получает данные, создает объект вещи,
        /// передает его в сервис и выводит результат.
        /// </summary>
        private static void HandleAddInventoryItem(IZooService zooService)
        {
            IInventory item = CreateInventoryItem();
            if (item == null)
            {
                Console.WriteLine("Ошибка создания инвентарной вещи.");
                return;
            }

            zooService.AddInventoryItem(item);
            Console.WriteLine("Инвентарная вещь успешно добавлена.");
        }

        /// <summary>
        /// Обрабатывает вывод отчета: отображает животных, потребление еды, список животных для
        /// контактного зоопарка и список инвентарных вещей.
        /// </summary>
        private static void HandleShowReport(IZooService zooService)
        {
            Console.WriteLine("\n--- Отчет ---");

            DisplayAnimals(zooService.GetAnimals());
            Console.WriteLine($"Общее количество потребляемой еды: {zooService.GetTotalFoodConsumption()} кг/день");

            DisplayContactZooAnimals(zooService.GetContactZooAnimals());
            DisplayInventoryItems(zooService.GetInventoryItems());
        }

        /// <summary>
        /// Создает объект Animal на основе данных, введенных пользователем.
        /// </summary>
        private static Animal CreateAnimal()
        {
            Console.WriteLine("\nВыберите тип животного:");
            Console.WriteLine("1. Кролик (Rabbit)");
            Console.WriteLine("2. Обезьяна (Monkey)");
            Console.WriteLine("3. Тигр (Tiger)");
            Console.WriteLine("4. Волк (Wolf)");
            uint animalType = ReadIUintOption("Ваш выбор: ", 1, 4);

            string name = ReadNonEmptyString("Введите имя животного: ");
            uint food = ReadUint("Введите количество потребляемой еды (кг): ");
            uint number = ReadUint("Введите инвентаризационный номер: ");

            Animal animal = null;
            switch (animalType)
            {
                case 1: // Rabbit
                    uint kindnessRabbit = ReadUintInRange("Введите уровень доброты (0-10): ", 0, 10);
                    animal = new Rabbit(name, food, number, kindnessRabbit);
                    break;
                case 2: // Monkey
                    uint kindnessMonkey = ReadUintInRange("Введите уровень доброты (0-10): ", 0, 10);
                    animal = new Monkey(name, food, number, kindnessMonkey);
                    break;
                case 3: // Tiger
                    animal = new Tiger(name, food, number);
                    break;
                case 4: // Wolf
                    animal = new Wolf(name, food, number);
                    break;
            }
            return animal;
        }

        /// <summary>
        /// Создает объект IInventory на основе данных, введенных пользователем.
        /// </summary>
        private static IInventory CreateInventoryItem()
        {
            Console.WriteLine("\nВыберите тип инвентарной вещи:");
            Console.WriteLine("1. Предмет (Thing)");
            Console.WriteLine("2. Стол (Table)");
            Console.WriteLine("3. Компьютер (Computer)");
            uint itemType = ReadIUintOption("Ваш выбор: ", 1, 3);

            string name = ReadNonEmptyString("Введите наименование: ");
            uint number = ReadUint("Введите инвентаризационный номер: ");

            IInventory item = null;
            switch (itemType)
            {
                case 1:
                    item = new Thing(name, number);
                    break;
                case 2:
                    item = new Table(name, number);
                    break;
                case 3:
                    item = new Computer(name, number);
                    break;
            }
            return item;
        }

        /// <summary>
        /// Выводит список животных на консоль.
        /// </summary>
        private static void DisplayAnimals(IEnumerable<Animal> animals)
        {
            Console.WriteLine("\nЖивотные, находящиеся на балансе зоопарка:");
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
            Console.WriteLine($"\nОбщее количество животных: {animals.Count()}");
        }

        /// <summary>
        /// Выводит список животных, подходящих для контактного зоопарка.
        /// </summary>
        private static void DisplayContactZooAnimals(IEnumerable<Animal> contactAnimals)
        {
            Console.WriteLine("\nЖивотные, подходящие для контактного зоопарка (травоядные с добротой > 5):");
            foreach (var animal in contactAnimals)
            {
                Console.WriteLine(animal.ToString());
            }
        }

        /// <summary>
        /// Выводит список инвентарных вещей.
        /// </summary>
        private static void DisplayInventoryItems(IEnumerable<IInventory> items)
        {
            Console.WriteLine("\nИнвентарные вещи:");
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }


        /// <summary>
        /// Читает с консоли непустую строку.
        /// </summary>
        private static string ReadNonEmptyString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    return input;
                Console.WriteLine("Ввод не может быть пустым. Попробуйте снова.");
            }
        }

        /// <summary>
        /// Читает с консоли число, с проверкой корректности ввода.
        /// </summary>
        private static uint ReadUint(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (uint.TryParse(input, out uint value))
                    return value;
                Console.WriteLine("Неверный ввод. Пожалуйста, введите число.");
            }
        }

        /// <summary>
        /// Читает с консоли число и проверяет, что оно находится в указанном диапазоне.
        /// </summary>
        private static uint ReadIUintOption(string prompt, uint min, uint max)
        {
            while (true)
            {
                uint value = ReadUint(prompt);
                if (value >= min && value <= max)
                    return value;
                Console.WriteLine($"Пожалуйста, введите число от {min} до {max}.");
            }
        }

        /// <summary>
        /// Читает с консоли число и проверяет, что оно находится в указанном диапазоне.
        /// Функционально аналогична ReadIUintOption.
        /// </summary>
        private static uint ReadUintInRange(string prompt, uint min, uint max)
        {
            return ReadIUintOption(prompt, min, max);
        }
    }
}
