public interface IFigure
{
    string Name { get; }
    double CalculatePerimeter();
    double CalculateArea();
    void DisplayInfo();
}

// Абстрактный базовый класс
public abstract class Figure : IFigure
{
    public abstract string Name { get; }

    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"=== {Name} ===");
        Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
        Console.WriteLine($"Площадь: {CalculateArea():F2}");
    }
}