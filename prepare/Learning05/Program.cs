
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("Blue", 4);
        Rectangle rectangle = new Rectangle("Red", 5, 3);
        Circle circle = new Circle("Green", 2);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"Color: {color}, Area: {area:F2}");
        }
    }
}
