namespace ConsoleApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            new Circle { Radius = 4 }.CalculateArea();
            new Reactangle1 { Length = 4, Breadth = 5 }.CalculateArea();
            new Square { side = 9 }.CalculateArea();
            new Cube { side = 5 }.CalculateVolume();
            // new Printers().print();
        }
        // private static void print(Circle circle) { Console.WriteLine(circle); }
        // private static void CalculateArea(Circle circle) { Console.WriteLine(3.14 * circle.Radius * circle.Radius); }
    }
}


// SOLID Principles
// :- Single Responsibility principle = A class should do one thing and therefore it should have only a single reason to change
// :- Open Close Principle = A class should be open for extension but closed to modification. That's why we have extension methods in c#
// :- Liskov Substitution principle = Derived or child classes must be substitutable for their base or parent class
// :- Interface Segregation Principle = Classes should not be forced to implement a function which they don't need
// :- Dependency Inversion Principle = Hight level classes should not depend on low level classes. Both should depend upon Abstractions