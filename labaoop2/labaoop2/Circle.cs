public class Circle : Figure
{
    public override string Name => "Окружность";

    public double Radius { get; }

    public Circle(double radius)
    {
        if (radius <= 0)
            throw new ArgumentException("Радиус должен быть положительным");

        Radius = radius;
    }

    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    // Диаметр окружности
    public double CalculateDiameter()
    {
        return 2 * Radius;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Диаметр: {CalculateDiameter():F2}");
        Console.WriteLine($"Радиус: {Radius:F2}");
    }
}