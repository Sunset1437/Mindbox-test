using NUnit.Framework.Legacy;

namespace AreaCalculateLib.Tests
{
    [TestFixture]
    public class GeometricShapeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CircleArea_ValidRadius_ReturnsCorrectArea() // Правильно ли вычисляется площадь круга
        {
            // Arrange
            double radius = 5;
            double expectedArea = Math.PI * radius * radius;

            // Act
            Shape circle = GeometricShape.CreateCircle(radius);
            double actualArea = circle.CalculateArea();

            // Assert
            Assert.That(expectedArea, Is.EqualTo(actualArea));
        }
        [Test]
        public void TriangleArea_ValidSides_ReturnsCorrectArea() // Правильно ли вычисляется площадь треугольника
        {
            // Arrange
            double a = 3, b = 4, c = 5;
            double expectedArea = 6;

            // Act
            Shape triangle = GeometricShape.CreateTriangle(a, b, c, out _);
            double actualArea = triangle.CalculateArea();

            // Assert
            Assert.That(expectedArea, Is.EqualTo(actualArea));
        }
        [Test]
        public void Triangle_90Degrees_ReturnsFalse() // Правильно ли вычисляется не прямоугольный треугольник
        {
            // Arrange
            double a = 3, b = 4, c = 6;

            // Act
            GeometricShape.CreateTriangle(a, b, c, out bool isNinetyDegrees);

            // Assert
            Assert.That(isNinetyDegrees, Is.False);
        }

        [Test]
        public void Triangle_90Degrees_ReturnsTrue() // Правильно ли вычисляется прямоугольный треугольник
        {
            {
                // Arrange
                double a = 3, b = 4, c = 5;

                // Act
                GeometricShape.CreateTriangle(a, b, c, out bool isNinetyDegrees);

                // Assert
                Assert.That(isNinetyDegrees, Is.True);
            }
        }
        [Test]
        public void CircleArea_NegativeRadius_ThrowsException() // Выбрасывается ли исключение при попытке создать круг с отрицательным радиусом
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateCircle(-5));
        }
        [Test]
        public void CircleArea_ZeroRadius_ThrowsException() // Выбрасывается ли исключение при попытке создать круг с 0 радиусом
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateCircle(0));
        }
        [Test]
        public void TriangleArea_InvalidSides_ThrowsException() // Выбрасывается ли исключение при попытке создать несуществующий
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateTriangle(1,1,3, out _));
        }
    }
}