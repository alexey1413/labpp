public class Parallelogram : Figure
{
    public override string Name => "Параллелограмм";

    public double Base { get; }
    public double Side { get; }
    public double Height { get; }
    public double Angle { get; } // в градусах

    public Parallelogram(double baseLength, double side, double height, double angle)
    {
        if (baseLength <= 0 || side <= 0 || height <= 0 || angle <= 0 || angle >= 180)
            throw new ArgumentException("Некорректные параметры параллелограмма");

        Base = baseLength;
        Side = side;
        Height = height;
        Angle = angle;
    }

    public override double CalculatePerimeter()
    {
        return 2 * (Base + Side);
    }

    public override double CalculateArea()
    {
        return Base * Height;
    }

    // Диагонали параллелограмма
    public double[] CalculateDiagonals()
    {
        double angleRad = Angle * Math.PI / 180;
        double d1 = Math.Sqrt(Base * Base + Side * Side + 2 * Base * Side * Math.Cos(angleRad));
        double d2 = Math.Sqrt(Base * Base + Side * Side - 2 * Base * Side * Math.Cos(angleRad));

        return new double[] { d1, d2 };
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        var diagonals = CalculateDiagonals();
        Console.WriteLine($"Диагонали: d1={diagonals[0]:F2}, d2={diagonals[1]:F2}");
        Console.WriteLine($"Угол: {Angle:F2}°");
    }
}