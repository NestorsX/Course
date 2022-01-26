using System;
using System.Globalization;

namespace CoordinatesFormatter
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentLine;
            while ((currentLine = Console.ReadLine()) != null)
            {
                try
                {
                    string[] stringCoordinates = currentLine.Split(",");
                    if (stringCoordinates.Length != 2)
                    {
                        throw new ArgumentException("Неверный набор входных данных");
                    }

                    var coordinates = new double[2];
                    for (var i = 0; i < 2; i++)
                    {
                        if (!double.TryParse(stringCoordinates[i], NumberStyles.Any, CultureInfo.InvariantCulture, out coordinates[i]))
                        {
                            throw new ArgumentException($"'{stringCoordinates[i]}' не является числом");
                        }
                    }

                    Console.WriteLine($"X: {coordinates[0]} Y: {coordinates[1]}");
                }
                catch (ArgumentException argumentExeption)
                {
                    Console.WriteLine(argumentExeption.Message);
                }
            }
        }
    }
}
