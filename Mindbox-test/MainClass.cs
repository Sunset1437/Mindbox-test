using System;
using AreaCalculateLib;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mindbox_test
{
    public class MainClass
    {
    static void Main()
        {
            try
            {
                // Круг
                Console.Write("Введите радиус круга: ");
                double radius = double.Parse(Console.ReadLine());
                Shape circle = GeometricShape.CreateCircle(radius);
                Console.WriteLine($"Площадь круга: {circle.CalculateArea():F2}");

                Console.WriteLine();

                // Треугольник
                Console.WriteLine("Введите стороны треугольника:");
                Console.Write("a = ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b = ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c = ");
                double c = double.Parse(Console.ReadLine());

                bool isNinetyDegree;
                Shape triangle = GeometricShape.CreateTriangle(a, b, c, out isNinetyDegree);
                Console.WriteLine($"Площадь треугольника: {triangle.CalculateArea():F2}");
                Console.WriteLine($"Треугольник {(isNinetyDegree ? "является" : "не является")} прямоугольным");

                Console.WriteLine();

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка ввода данных: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено некорректное числовое значение.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
        }
    }
}
