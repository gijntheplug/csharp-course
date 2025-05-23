using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(Somma(4, 5));
        Console.WriteLine(Somma(3.6, 2.4));
        Console.WriteLine(Somma(1, 2, 5));
    }

    public static int Somma(int a, int b)
    {
        return a + b;
    }

    public static double Somma(double a, double b)
    {
        return a + b;
    }

    public static int Somma(int a, int b, int c)
    {
        return a + b + c;
    }
}