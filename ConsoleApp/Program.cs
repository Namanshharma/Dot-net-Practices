using System.Drawing;

namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            circle.CalculateArea();
            Reactangle1 reactangle = new Reactangle1(5, 5);
            reactangle.CalculateArea();
            new Printers().print(circle);
        }
        // private static void print(Circle circle) { Console.WriteLine(circle); }
        // private static void CalculateArea(Circle circle) { Console.WriteLine(3.14 * circle.Radius * circle.Radius); }
    }
}

// SOLID Principles

// :- Single Responsibility principle = A class should do one thing and therefore it should have only a single reason to change
// :- Open Close Principle = A class should be opne for extension but closed to modification