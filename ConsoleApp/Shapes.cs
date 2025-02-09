namespace ConsoleApp;
public interface IShape
{
    void CalculateArea();
}
public class Circle : IShape
{
    public double Radius { get; set; }
    public Circle(double radius) { Radius = radius; }
    public void CalculateArea() { Console.WriteLine(3.14 * Radius * Radius); }
}
public class Reactangle1 : IShape
{
    public Reactangle1(double length, double breadth) { Length = length; Breadth = breadth; }
    public double Length { get; set; }
    public double Breadth { get; set; }
    public void CalculateArea() { Console.WriteLine(Length * Breadth); }
}