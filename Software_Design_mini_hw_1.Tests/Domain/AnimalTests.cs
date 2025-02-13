using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ZooManagement.Domain.Herbos;

public class AnimalTests
{
    [Fact]
    public void Animals_With_Same_Name_And_Number_Should_Be_Equal()
    {
        var rabbit1 = new Rabbit("ДжоДжо", 5, 101, 8);
        var rabbit2 = new Rabbit("ДжоДжо", 5, 101, 9); // Разная доброта, но ключи одинаковыею

        rabbit1.Should().Be(rabbit2);
    }

    [Fact]
    public void Animals_With_Different_Identifiers_Should_Not_Be_Equal()
    {
        var rabbit1 = new Rabbit("ДжоДжо", 5, 101, 8);
        var rabbit2 = new Rabbit("ДжоДжо", 5, 102, 9); // Разные номера

        rabbit1.Should().NotBe(rabbit2);
    }

    [Fact]
    public void GetHashCode_Should_Be_Same_For_Equal_Animals()
    {
        var rabbit1 = new Rabbit("ДжоДжо", 5, 101, 8);
        var rabbit2 = new Rabbit("ДжоДжо", 5, 101, 9);

        rabbit1.GetHashCode().Should().Be(rabbit2.GetHashCode());
    }
}

