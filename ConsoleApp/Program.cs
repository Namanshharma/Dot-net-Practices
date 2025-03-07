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


// Rules of Liskov Substitution principle = If a derived class overrides a method of Parent class or base class then the method of derived class should provide same behavior
//    = Objects of a derived class should be substitutable for objects of the base class without affecting the correctness of the program.
//    = Ensures that inheritance relationships are used appropriately.

// ==> Rule 1 : With same input, it should provide same output ( return value ).
// ==> Rule 2 : Child class method should not throw any new exception than what were thrown in base class implementation.
// ==> Rule 3 : Child class method should not implement stricter rules for any argument than base class implementation.

// Benefits of Liskor Susbtitution principle :- Prevents code to break - if by mistake or wantedly, someone has replaced the derived class with its base class as it's behavior doesn't 
// change


// Single Responsibility Principle (SRP)
// ==>  A class should have only one reason to change.
// ==>  Promotes focused and maintainable classes.

// Open/Closed Principle (OCP)
// ==>  Software entities should be open for extension but closed for modification.
// ==>  Encourage adding new features without changing existing code.

// Liskov Substitution Principle (LSP)
// ==>  Objects of a derived class should be substitutable for objects of the base class without affecting the correctness of the program.
// ==>  Ensures that inheritance relationships are used appropriately.

// Interface Segregation Principle (ISP)
// ==>  Clients should not be forced to depend on interfaces they do not use.
// ==>  Promotes smaller, more focused interfaces.

// Dependency Inversion Principle (DIP)
// ==>  High-level modules should not depend on low-level modules. Both should depend on abstractions.
// ==>  Abstractions should not depend on details. Details should depend on abstractions.
// ==>  Encourages loose coupling and flexibility.