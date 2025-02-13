using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ZooManagement.Services;
using ZooManagement.Domain;
using ZooManagement.Domain.Herbos;
using ZooManagement.Domain.Things;
using System.Linq;

public class ZooServiceTests
{
    private readonly ZooService _zooService;

    public ZooServiceTests()
    {
        var fakeClinic = new MockVeterinaryClinic(true);
        _zooService = new ZooService(fakeClinic);
    }

    [Fact]
    public void AddAnimal_Should_AddAnimal_When_ExaminationPasses()
    {
        var rabbit = new Rabbit("Bunny", 5, 101, 8);

        var result = _zooService.AddAnimal(rabbit);

        result.Should().BeTrue();
        _zooService.GetAnimals().Should().Contain(rabbit);
    }

    [Fact]
    public void GetTotalFoodConsumption_Should_Return_CorrectSum()
    {
        _zooService.AddAnimal(new Rabbit("Bunny", 5, 101, 8));
        _zooService.AddAnimal(new Rabbit("Thumper", 7, 102, 9));

        _zooService.GetTotalFoodConsumption().Should().Be(12);
    }

    [Fact]
    public void AddInventoryItem_Should_AddUniqueItemOrIncreaseQuantity()
    {
        var table = new Thing("Table", 201);

        _zooService.AddInventoryItem(table);
        _zooService.AddInventoryItem(new Thing("Table", 201));

        _zooService.GetInventoryItems()
            .Where(x => x.Number == 201)
            .Should().HaveCount(1);
    }
}

