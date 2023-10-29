using AreaСalculator.Interfaces;

namespace AreaСalculator.Implementation;

public class Triangle : IShape
{
    private readonly double _a;
    private readonly double _b;
    private readonly double _c;

    public Triangle(double a, double b, double c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            throw new ArgumentException("Стороны треугольника должны быть больше нуля!");
        
        _a = a;
        _b = b;
        _c = c;
    }
    
    /// <summary>
    /// Вычисление площади треугольника по трем сторонам.
    /// </summary>
    /// <returns>Площадь треугольника.</returns>
    public double GetArea()
    {
        var p = (_a + _b + _c) / 2;
        return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
    }
    
    // TODO не понял где использовать данную проверку.
    /// <summary>
    /// Проверка, является ли треугольник прямоугольным.
    /// </summary>
    /// <returns>Является ли треугольник прямоугольным</returns>
    public bool IsTriangleRight() => Math.Abs(Math.Pow(_a, 2) + Math.Pow(_b, 2) - Math.Pow(_c, 2)) < 0.0001
                                   || Math.Abs(Math.Pow(_a, 2) + Math.Pow(_c, 2) - Math.Pow(_b, 2)) < 0.0001 
                                   || Math.Abs(Math.Pow(_b, 2) + Math.Pow(_c, 2) - Math.Pow(_a, 2)) < 0.0001;
}