public class Rectangle : Figure
{
    public override string Name => "Прямоугольник";

    public double Width { get; }
    public double Height { get; }

    public Rectangle(double width, double height)
    {
        if (width <= 0 || height <= 0)
            throw new ArgumentException("Стороны должны быть положительными");

        Width = width;
        Height = height;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }

    public override double CalculateArea()
    {
        return Width * Height;
    }

    // Диагональ прямоугольника
    public double CalculateDiagonal()
    {
        return Math.Sqrt(Width * Width + Height * Height);
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Диагональ: {CalculateDiagonal():F2}");
    }
}