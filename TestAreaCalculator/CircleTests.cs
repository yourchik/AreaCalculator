using System.Reflection;
using AreaСalculator.Implementation;
using FluentAssertions;

namespace TestAreaCalculator;

public class CircleTests : TestCollection
{
    [Fact]
    public void Circle_Ctor_WhenRadiusIsLessThanZero_ThrowsArgumentException()
    {
        // Arrange
        var radius = -1;
        
        // Act
        var sut = () => new Сircle(radius);
        
        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("Радиус круга должен быть больше нуля!");
    }

    [Fact]
    public void Circle_Ctor_WhenRadiusIsMoreThanZero_ShouldBeEqual()
    {
        // Arrange
        var radius = 5;
        var fieldInfo = typeof(Сircle).GetField("_radius", BindingFlags.NonPublic | BindingFlags.Instance);
        
        // Act
        var sut = new Сircle(radius);
        var actualRadius = (double)fieldInfo.GetValue(sut);
        
        // Assert
        actualRadius.Should().Be(radius);
    }
    
    [Fact]
    public void Circle_GetArea_ShouldBeEqual()
    {
        // Arrange
        var radius = 5;
        
        // Act
        var sut = new Сircle(radius);
        var result = sut.GetArea();
        var expected = Math.PI * Math.Pow(radius, 2);
        
        // Assert
        Assert.Equal(expected, result);
    }
}