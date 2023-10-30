using AreaСalculator.Interfaces;

namespace AreaСalculator.Implementation;

public class Сircle : IShape
{
    private readonly double _radius;

    public Сircle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус круга должен быть больше нуля!");
        
        _radius = radius;   
    }
    
    public double GetArea() => Math.PI * Math.Pow(_radius, 2);
    
}