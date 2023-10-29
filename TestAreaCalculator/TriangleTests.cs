using System.Reflection;
using AreaСalculator.Implementation;
using FluentAssertions;

namespace TestAreaCalculator;

public class TriangleTests : TestCollection
{
    [Theory]
    [InlineData(-1, 2, 3)]
    [InlineData(1, 0, 1)]
    [InlineData(1, 3, -5)]
    public void Triangle_Ctor_WhenWrongSides_ShouldThrowsArgumentException(double a, double b, double c)
    {
        // Arrange

        // Act
        var sut = () => new Triangle(a, b, c);
        
        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("Стороны треугольника должны быть больше нуля!");
    }

    [Fact]
    public void Triangle_Ctor_ShouldBeEqual()
    {
        // Arrange
        var a = 2;
        var b = 3;
        var c = 4;
        var fieldAInfo = typeof(Triangle).GetField("_a", BindingFlags.NonPublic | BindingFlags.Instance);
        var fieldBInfo = typeof(Triangle).GetField("_b", BindingFlags.NonPublic | BindingFlags.Instance);
        var fieldCInfo = typeof(Triangle).GetField("_c", BindingFlags.NonPublic | BindingFlags.Instance);
       
        // Act
        var sut = new Triangle(a, b, c);
        var actualA = (double)fieldAInfo.GetValue(sut);
        var actualB = (double)fieldBInfo.GetValue(sut);
        var actualC = (double)fieldCInfo.GetValue(sut);
        
        // Assert
        actualA.Should().Be(a);
        actualB.Should().Be(b);
        actualC.Should().Be(c);
    }
    
    [Fact]
    public void Triangle_GetArea_ShouldBeEqual()
    {
        // Arrange
        double a = 2;
        double b = 3;
        double c = 4;
        
        // Act
        var sut = new Triangle(a, b, c);
        var result = sut.GetArea();
        var p = (a + b + c) / 2;
        var expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        // Assert   
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Triangle_IsTriangleRight_ShouldBeEqual()
    {
        // Arrange
        double a = 3;
        double b = 4;
        double c = 5;
        
        // Act
        var sut = new Triangle(a, b, c);
        var result = sut.IsTriangleRight();

        // Assert
        Assert.True(result);
    }
}