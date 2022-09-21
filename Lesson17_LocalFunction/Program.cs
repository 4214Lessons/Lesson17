namespace Lesson17_LocalFunction;


static class Test { }

class Program
{
    static void DoSomething(int value)
    {
        Console.WriteLine("DoSomething");

        int x = 10;

        static void Helper(int a, int b)
        {
            Console.WriteLine("DoSomething.Helper()");
            // Console.WriteLine(value);
            // Console.WriteLine(x);

            Console.WriteLine(a);
            Console.WriteLine(b);
        }

        Helper(value, x);
    }


    static void Main()
    {
        DoSomething(42);
    }
}