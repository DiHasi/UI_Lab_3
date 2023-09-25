namespace UI_Lab_3.Figures;

public class Point : Figure
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"Point ({X}; {Y})";
    }
}