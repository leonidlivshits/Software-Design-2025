using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using ZooManagement.Domain.Things;

public class ThingTests
{
    [Fact]
    public void Things_With_Same_Name_And_Number_Should_Be_Equal()
    {
        var table1 = new Thing("Table", 201);
        var table2 = new Thing("Table", 201);

        table1.Should().Be(table2);
    }

    [Fact]
    public void Things_With_Different_Identifiers_Should_Not_Be_Equal()
    {
        var table1 = new Thing("Table", 201);
        var table2 = new Thing("Table", 202); // Разный номер

        table1.Should().NotBe(table2);
    }

    [Fact]
    public void GetHashCode_Should_Be_Same_For_Equal_Things()
    {
        var table1 = new Thing("Table", 201);
        var table2 = new Thing("Table", 201);

        table1.GetHashCode().Should().Be(table2.GetHashCode());
    }
}
