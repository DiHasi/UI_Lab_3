namespace UI_Lab_3.Figures;

public class Circle : Figure
{
    public Point Center { get; set; }
    public double Radius { get; set; }

    public Circle(Point center, double radius)
    {
        Center = center;
        Radius = radius;
    }

    public override string ToString()
    {
        return $"Circle (Center: {Center}; Radius: {Radius})";
    }
}