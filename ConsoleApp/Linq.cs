namespace ConsoleApp;
public class Linq
{
    List<string> list = new List<string> { "John", "Mike", "Emma", "Robert" };

    public List<string> findString()
    {
        List<string> x = list.Where(x => x.StartsWith("j")).ToList();
        return x;
    }
}
