namespace ConsoleApp;
public interface IPrinters
{
    void print(IShape shape);
}
public class Printers : IPrinters
{
    public void print(IShape shape) { Console.WriteLine(shape); }
}
