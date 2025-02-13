using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagement.Domain;

namespace ZooManagement.Services
{
    /// <summary>
    /// Реализую интерфейс клиники.
    /// </summary>
    public class VeterinaryClinic : IVeterinaryClinic
    {
        public bool Examine(Animal animal)
        {
            Console.WriteLine($"\nПроводится медосмотр животного: {animal.Name}");
            Console.Write("Животное здорово? Если здорово, введите (да): ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            bool isHealthy = input == "да";
            if (isHealthy)
                Console.WriteLine("Животное прошло медосмотр.");
            else
                Console.WriteLine("Животное больно.");
            return isHealthy;
        }
    }
}