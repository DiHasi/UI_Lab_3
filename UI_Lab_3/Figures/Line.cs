namespace UI_Lab_3.Figures;

public class Line : Figure
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public override string ToString()
    {
        return $"Line (Start: {Start}; End: {End})";
    }
}