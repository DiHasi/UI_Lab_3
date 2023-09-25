using System.ComponentModel;
using CommandLine;
using UI_Lab_3.Figures;

namespace UI_Lab_3
{

    class Options
    {
        [Option('f', "file", Required = true, HelpText = "Путь к обрабатываемому файлу")]
        public string Path { get; set; }

        [Option('o', "oper", Required = true, HelpText = "Операция над списком фигур")]
        public string Operation { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //args = new[] { "-f", "input.txt", "-o", "print" };
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    List<Figure> figures = FigureParser.ParseFiguresFromFile(options.Path);

                    switch (options.Operation.ToLower())
                    {
                        case "print":
                            PrintFigures(figures);
                            break;
                        case "count":
                            CountFigures(figures);
                            break;
                        default:
                            Console.WriteLine("Incorrect operation");
                            break;
                    }
                });
        }

        
        public static void PrintFigures(List<Figure> figures)
        {
            Console.WriteLine("List of figures:");
            foreach (var figure in figures)
            {
                Console.WriteLine(figure);
            }
        }

        public static void CountFigures(List<Figure> figures)
        {
            Console.WriteLine($"Number of figures: {figures.Count}");
        }
    }
}