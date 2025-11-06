class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Калькулятор геометрических фигур ===\n");

        try
        {
            // Создаем коллекцию фигур
            List<IFigure> figures = new List<IFigure>
            {
                new Triangle(3, 4, 5),
                new Rectangle(5, 10),
                new Circle(7),
                new Parallelogram(6, 8, 5, 60),
                new Trapezoid(8, 12, 5, 5, 4)
            };

            // Выводим информацию о всех фигурах
            foreach (var figure in figures)
            {
                figure.DisplayInfo();
                Console.WriteLine(new string('-', 40));
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.ReadLine();
    }
}