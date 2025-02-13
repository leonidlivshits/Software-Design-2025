//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;
//using FluentAssertions;
//using ZooManagement.Services;
//using ZooManagement.Domain;
//using Moq;
//using ZooManagement.Domain.Herbos;
//public class VeterinaryClinicTests
//{
//    [Fact]
//    public void Examine_Should_Return_True_When_Input_Is_Yes()
//    {
//        using var sr = new StringReader("да");
//        Console.SetIn(sr);

//        var clinic = new VeterinaryClinic();
//        var animal = new Rabbit("Bugs Bunny", 5, 101, 8); // Сделал тестового кролика.

//        var result = clinic.Examine(animal);

//        result.Should().BeTrue(); // Симулирую ввод "да"
//    }
//}

