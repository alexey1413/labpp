public class Trapezoid : Figure
{
    public override string Name => "Трапеция";

    public double Base1 { get; }
    public double Base2 { get; }
    public double Leg1 { get; }
    public double Leg2 { get; }
    public double Height { get; }

    public Trapezoid(double base1, double base2, double leg1, double leg2, double height)
    {
        if (base1 <= 0 || base2 <= 0 || leg1 <= 0 || leg2 <= 0 || height <= 0)
            throw new ArgumentException("Все параметры должны быть положительными");

        Base1 = base1;
        Base2 = base2;
        Leg1 = leg1;
        Leg2 = leg2;
        Height = height;
    }

    public override double CalculatePerimeter()
    {
        return Base1 + Base2 + Leg1 + Leg2;
    }

    public override double CalculateArea()
    {
        return (Base1 + Base2) * Height / 2;
    }

    // Средняя линия трапеции
    public double CalculateMidline()
    {
        return (Base1 + Base2) / 2;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Средняя линия: {CalculateMidline():F2}");
    }
}