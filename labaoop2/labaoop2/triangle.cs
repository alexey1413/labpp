public class Triangle : Figure
{
    public override string Name => "Треугольник";

    public double SideA { get; }
    public double SideB { get; }
    public double SideC { get; }

    public Triangle(double a, double b, double c)
    {
        if (!IsValidTriangle(a, b, c))
            throw new ArgumentException("Треугольник с такими сторонами не существует");

        SideA = a;
        SideB = b;
        SideC = c;
    }

    private bool IsValidTriangle(double a, double b, double c)
    {
        return a + b > c && a + c > b && b + c > a && a > 0 && b > 0 && c > 0;
    }

    public override double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public override double CalculateArea()
    {
        double p = CalculatePerimeter() / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    // СПЕЦИАЛЬНЫЕ МЕТРИКИ ДЛЯ ТРЕУГОЛЬНИКА

    // Углы треугольника в градусах
    public double[] CalculateAngles()
    {
        double angleA = Math.Acos((SideB * SideB + SideC * SideC - SideA * SideA) / (2 * SideB * SideC));
        double angleB = Math.Acos((SideA * SideA + SideC * SideC - SideB * SideB) / (2 * SideA * SideC));
        double angleC = Math.PI - angleA - angleB;

        return new double[]
        {
            angleA * 180 / Math.PI,
            angleB * 180 / Math.PI,
            angleC * 180 / Math.PI
        };
    }

    // Высоты треугольника
    public double[] CalculateHeights()
    {
        double area = CalculateArea();
        double heightA = 2 * area / SideA;
        double heightB = 2 * area / SideB;
        double heightC = 2 * area / SideC;

        return new double[] { heightA, heightB, heightC };
    }

    // Медианы треугольника
    public double[] CalculateMedians()
    {
        double medianA = 0.5 * Math.Sqrt(2 * SideB * SideB + 2 * SideC * SideC - SideA * SideA);
        double medianB = 0.5 * Math.Sqrt(2 * SideA * SideA + 2 * SideC * SideC - SideB * SideB);
        double medianC = 0.5 * Math.Sqrt(2 * SideA * SideA + 2 * SideB * SideB - SideC * SideC);

        return new double[] { medianA, medianB, medianC };
    }

    // Биссектрисы треугольника
    public double[] CalculateBisectors()
    {
        double p = CalculatePerimeter() / 2;
        double bisectorA = (2 * Math.Sqrt(SideB * SideC * p * (p - SideA))) / (SideB + SideC);
        double bisectorB = (2 * Math.Sqrt(SideA * SideC * p * (p - SideB))) / (SideA + SideC);
        double bisectorC = (2 * Math.Sqrt(SideA * SideB * p * (p - SideC))) / (SideA + SideB);

        return new double[] { bisectorA, bisectorB, bisectorC };
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();

        var angles = CalculateAngles();
        var heights = CalculateHeights();
        var medians = CalculateMedians();
        var bisectors = CalculateBisectors();

        Console.WriteLine("\nСпециальные метрики:");
        Console.WriteLine($"Углы: A={angles[0]:F2}°, B={angles[1]:F2}°, C={angles[2]:F2}°");
        Console.WriteLine($"Высоты: ha={heights[0]:F2}, hb={heights[1]:F2}, hc={heights[2]:F2}");
        Console.WriteLine($"Медианы: ma={medians[0]:F2}, mb={medians[1]:F2}, mc={medians[2]:F2}");
        Console.WriteLine($"Биссектрисы: la={bisectors[0]:F2}, lb={bisectors[1]:F2}, lc={bisectors[2]:F2}");
    }
}