using System;
using static System.Console;

namespace StaticCompositionDecoratorPattern
{
    class Program
    {
        public abstract class Shape
        {
            public abstract string AsString();
        }

        public class Circle : Shape
        {
            private float radius;

            public Circle() : this(0)
            {

            }

            public Circle(float radius)
            {
                this.radius = radius;
            }

            public void Resize(float factor)
            {
                radius *= factor;
            }
            public override string AsString() => $"A circle with radius {radius}";
        }


        public class Square : Shape
        {
            private float side;

            public Square()
            {

            }

            public Square(float side)
            {
                this.side = side;
            }
            public override string AsString() => $"A square with side {side}";
        }

        public class ColoredShape : Shape
        {
            private Shape shape;
            private string color;

            public ColoredShape(Shape shape, string color)
            {
                this.shape = shape;
                this.color = color;
            }

            public override string AsString() => $"{shape.AsString()} has the color {color}";
        }

        public class TransparentShape : Shape
        {
            private Shape shape;
            private float transparency;

            public TransparentShape(Shape shape, float transparency)
            {
                this.shape = shape;
                this.transparency = transparency;
            }

            public override string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";
        }

        public class ColoredShape<T> : Shape where T : Shape, new()
        {
            private string color;
            private T shape = new T();

            public ColoredShape() : this("black")
            {

            }

            public ColoredShape(string color)
            {
                this.color = color;
            }

            public override string AsString() => $"{shape.AsString()} has color {color}";

        }

        public class TransparentShape<T> : Shape where T : Shape, new()
        {
            private float transparency;
            private T shape = new T();

            public TransparentShape() : this(0)
            {

            }

            public TransparentShape(float transparency)
            {
                this.transparency = transparency;
            }

            public override string AsString() => $"{shape.AsString()} has {transparency * 100.0}% transparency";

        }

        static void Main(string[] args)
        {

            var redSquare = new ColoredShape<Square>("red");
            WriteLine(redSquare.AsString());

            var circle = new TransparentShape<ColoredShape<Circle>>(0.4f);
            WriteLine(circle.AsString());
        }
    }
}
