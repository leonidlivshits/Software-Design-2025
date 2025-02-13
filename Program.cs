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
    /// DI контеней и декомпозированные функции.
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
        /// Главное меню приложения.
        /// </summary>
        private static void DisplayMainMenu()
        {
            Console.WriteLine("\n--- Московский зоопарк ERP ---");
            Console.WriteLine("1. Добавить животное");
            Console.WriteLine("2. Вывести отчет");
            Console.WriteLine("3. Добавить инвентарь");
            Console.WriteLine("4. Выход");
            Console.Write("Выберите опцию: ");
        }

        /// <summary>
        /// Проверка добавления животного: получаем сервис, создаем объект животного,
        /// передаем его в сервис и выводим результат.
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
        /// Проверка добавления животного: получаем сервис, создаем объект вещи,
        /// передаем его в сервис и выводим результат.
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
        /// Отчёт: отображает животных, потребление еды, список животных для
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
        /// Создает объект Animal на основе данных с консоли.
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
                    uint kindnessRabbit = ReadIUintOption("Введите уровень доброты (0-10): ", 0, 10);
                    animal = new Rabbit(name, food, number, kindnessRabbit);
                    break;
                case 2: // Monkey
                    uint kindnessMonkey = ReadIUintOption("Введите уровень доброты (0-10): ", 0, 10);
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
        /// Создает объект IInventory на основе данныхс консоли.
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
        /// Выводит список инвентаря.
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
        /// Читает с консоли положительное число, с проверкой корректности ввода.
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
    }
}
