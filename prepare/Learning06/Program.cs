using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square mySquare = new Square("Red", 3);
        shapes.Add(mySquare);
        Rectangle myRectangle = new Rectangle("Blue",4,5);
        shapes.Add(myRectangle);
        Circle myCircle = new Circle("Green", 6);
        shapes.Add(myCircle);
        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");  // Fixed closing parenthesis
        }
        
    }
}
