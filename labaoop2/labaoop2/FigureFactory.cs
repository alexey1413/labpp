public static class FigureFactory
{
    public static IFigure CreateTriangle(double a, double b, double c)
    {
        return new Triangle(a, b, c);
    }

    public static IFigure CreateRectangle(double width, double height)
    {
        return new Rectangle(width, height);
    }

    public static IFigure CreateCircle(double radius)
    {
        return new Circle(radius);
    }

    public static IFigure CreateParallelogram(double baseLength, double side, double height, double angle)
    {
        return new Parallelogram(baseLength, side, height, angle);
    }

    public static IFigure CreateTrapezoid(double base1, double base2, double leg1, double leg2, double height)
    {
        return new Trapezoid(base1, base2, leg1, leg2, height);
    }
}