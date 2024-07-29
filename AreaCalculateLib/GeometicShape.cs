namespace AreaCalculateLib
{
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    public class Circle : Shape
    {
        private readonly double radius;

        public Circle(double rad)
        {
            if (rad <= 0)
            {
                throw new ArgumentException("Радиус должен быть положительным числом.", nameof(rad));
            }
            radius = rad;
        }

        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }

    public class Triangle : Shape
    {
        private readonly double x1;
        private readonly double x2;
        private readonly double x3;

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Все стороны треугольника должны быть положительными числами.");
            }
            if (a + b <= c || a + c <= b || b + c <= a) // Треугольник существует только тогда, когда сумма двух его сторон больше третьей
            {
                throw new ArgumentException("Указанные стороны не могут образовать треугольник.");
            }
            x1 = a;
            x2 = b;
            x3 = c;
        }
        public bool IsNinetyDegree()
        {
            double[] sides = new double[] { x1, x2, x3 };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-10;
        }

        public override double CalculateArea()
        {
            double p = (x1 + x2 + x3) / 2;
            return Math.Sqrt(p * (p - x1) * (p - x2) * (p - x3));
        }
    }

    public static class GeometricShape
    {
        public static Shape CreateCircle(double radius)
        {
            return new Circle(radius);
        }

        public static Shape CreateTriangle(double a, double b, double c, out bool isNinetyDegree)
        {
            Triangle triangle = new Triangle(a, b, c);
            isNinetyDegree = triangle.IsNinetyDegree();
            return triangle;
        }
    }
}
