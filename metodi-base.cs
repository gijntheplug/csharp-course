using System;

class Program
{
    static void Main(string[] args)
    {
        _StampaSaluto("Andrea");
        _VerificaPari(29);
        _CalcolaPotenza(5, 3);
    }

    private static void _StampaSaluto(string nome)
    {
        Console.WriteLine($"Ciao {nome}!");
    }

    private static int _VerificaPari(int num)
    {
        if (num % 2 == 0)
        {
            Console.Write($"{num} è pari.");
            return 0;
        }
        else
        {
            Console.Write($"{num} è dispari.");
            return 1;
        }
    }

    private static int _CalcolaPotenza(int baseNum, int esponente)
    {
        int risultato = 1;

        for (int i = 0; i < esponente; i++)
        {
            risultato *= esponente;
        }

        return risultato;
    }
}