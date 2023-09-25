using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using UI_Lab_3.Figures;

namespace UI_Lab_3;

public class FigureParser
{
    public static List<Figure> ParseFiguresFromFile(string filePath)
    {
        List<Figure> figures = new List<Figure>();
        string[] lines = Array.Empty<string>();

        try
        {
            lines = File.ReadAllLines(filePath);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        foreach (var strLine in lines)
        {
            if (TryParsePoint(strLine, out var point))
            {
                figures.Add(point);
            }
            else if (TryParseLine(strLine, out var line))
            {
                figures.Add(line);
            }
            else if (TryParseCircle(strLine, out var circle))
            {
                figures.Add(circle);
            }
            //else
            //{
            //    Console.WriteLine($"Ошибка в строке: {line}");
            //}
        }

        return figures;
    }

    private static bool TryParsePoint(string line, out Point point)
    {
        point = null;
        Match match = Regex.Match(line, @"^Point\((-?\d+(\.\d+)?), (-?\d+(\.\d+)?)\)");

        if (match.Success)
        {
            double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            double y = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            point = new Point(x, y);
            return true;
        }

        return false;
    }

    private static bool TryParseLine(string line, out Line lineObj)
    {
        lineObj = null;
        Match match = Regex.Match(line, @"^Line\(Point\((-?\d+(\.\d+)?), (-?\d+(\.\d+)?)\), Point\((-?\d+(\.\d+)?), (-?\d+(\.\d+)?)\)\)");

        if (match.Success)
        {
            double startX = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            double startY = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            double endX = double.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);
            double endY = double.Parse(match.Groups[7].Value, CultureInfo.InvariantCulture);

            Point start = new Point(startX, startY);
            Point end = new Point(endX, endY);

            lineObj = new Line(start, end);
            return true;
        }

        return false;
    }

    private static bool TryParseCircle(string line, out Circle circle)
    {
        circle = null;
        Match match = Regex.Match(line, @"^Circle\(Point\((-?\d+(\.\d+)?), (-?\d+(\.\d+)?)\), (\d+(\.\d+)?)\)");

        if (match.Success)
        {
            double centerX = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
            double centerY = double.Parse(match.Groups[3].Value, CultureInfo.InvariantCulture);
            double radius = double.Parse(match.Groups[5].Value, CultureInfo.InvariantCulture);

            Point center = new Point(centerX, centerY);

            circle = new Circle(center, radius);
            return true;
        }

        return false;
    }
}