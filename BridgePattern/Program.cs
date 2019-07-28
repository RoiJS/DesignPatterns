using System;

namespace BridgePattern
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer: IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing a circle of radius {radius}");
        }

    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            Console.WriteLine($"Drawing pixels for a circle with raduis {radius}");
        }
    }

    public abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer ?? throw new ArgumentNullException(paramName: nameof(renderer));
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {     
        private float radius;
     
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
        this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius *= factor;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            //IRenderer renderer = new RasterRenderer();
            IRenderer renderer = new VectorRenderer();
            var circle = new Circle(renderer, 5);

            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }
    }
}
