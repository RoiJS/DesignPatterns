using System;
using static System.Console;

namespace DynamicDecoratorPattern
{
    class Program
    {
        public interface IShape
        {
            string AsString();
        }

        public class Circle : IShape
        {
            private float radius;

            public Circle(float radius)
            {
                this.radius = radius;
            }

            public void Resize(float factor)
            {
                radius *= factor;
            }
            public string AsString() => $"A circle with radius {radius}";

        }


        public class Square : IShape
        {
            private float side;

            public Square(float side)
            {
                this.side = side;
            }
            public string AsString() => $"A square with side {side}";
        }

        public class ColoredShape : IShape
        {
            private IShape shape;
            private string color;

            public ColoredShape(IShape shape, string color)
            {
                this.shape = shape;
                this.color = color;
            }

            public string AsString() => $"{shape.AsString()} has the color {color}";
        }

        public class TransparentShape : IShape
        {
            private IShape shape;
            private float transparency;

            public TransparentShape(IShape shape, float transparency)
            {
                this.shape = shape;
                this.transparency = transparency;
            }

            public string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";
        }
        static void Main(string[] args)
        {
            var square = new Square(1.23f);
            WriteLine(square.AsString());

            var redSquare = new ColoredShape(square, "red");
            WriteLine(redSquare.AsString());

            var redHalfTransparentSquare = new TransparentShape(redSquare, 0.5f);
            WriteLine(redHalfTransparentSquare.AsString());
        }
    }
}
