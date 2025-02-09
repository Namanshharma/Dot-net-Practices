namespace ConsoleApp;
public interface IShape { }
public interface I2DShape : IShape { void CalculateArea(); }
public interface I3DShape : IShape { void CalculateVolume(); }
public class Circle : I2DShape
{
    public double Radius { get; set; }
    // public Circle(double radius) { Radius = radius; }
    public void CalculateArea() { Console.WriteLine(3.14 * Radius * Radius); }
}
public class Reactangle1 : I2DShape
{
    // public Reactangle1(double length, double breadth) { Length = length; Breadth = breadth; }
    public double Length { get; set; }
    public double Breadth { get; set; }
    public void CalculateArea() { Console.WriteLine(Length * Breadth); }
}
public class Square : I2DShape
{
    public double side { get; set; }
    public void CalculateArea() { Console.WriteLine(side * side); }
}
public class Cube : I3DShape
{
    public double side { get; set; }
    public void CalculateVolume() { Console.WriteLine(side * side * side); }
}