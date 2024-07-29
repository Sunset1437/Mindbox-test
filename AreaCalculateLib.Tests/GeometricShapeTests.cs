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
        public void CircleArea_ValidRadius_ReturnsCorrectArea() // ��������� �� ����������� ������� �����
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
        public void TriangleArea_ValidSides_ReturnsCorrectArea() // ��������� �� ����������� ������� ������������
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
        public void Triangle_90Degrees_ReturnsFalse() // ��������� �� ����������� �� ������������� �����������
        {
            // Arrange
            double a = 3, b = 4, c = 6;

            // Act
            GeometricShape.CreateTriangle(a, b, c, out bool isNinetyDegrees);

            // Assert
            Assert.That(isNinetyDegrees, Is.False);
        }

        [Test]
        public void Triangle_90Degrees_ReturnsTrue() // ��������� �� ����������� ������������� �����������
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
        public void CircleArea_NegativeRadius_ThrowsException() // ������������� �� ���������� ��� ������� ������� ���� � ������������� ��������
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateCircle(-5));
        }
        [Test]
        public void CircleArea_ZeroRadius_ThrowsException() // ������������� �� ���������� ��� ������� ������� ���� � 0 ��������
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateCircle(0));
        }
        [Test]
        public void TriangleArea_InvalidSides_ThrowsException() // ������������� �� ���������� ��� ������� ������� ��������������
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => GeometricShape.CreateTriangle(1,1,3, out _));
        }
    }
}