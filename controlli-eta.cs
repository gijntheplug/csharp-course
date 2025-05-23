using System;

class Program
{
    static void Main(string[] args)
    {
        int age;
        const int minAge = 18;

        Console.WriteLine("Inserisci la tua età:");
        age = int.Parse(Console.ReadLine());
        if (age >= minAge)
        {
            Console.WriteLine("Sei Maggiorenne.");
        }
        else
        {
            Console.WriteLine("Sei minorenne.");
        }
    }
}