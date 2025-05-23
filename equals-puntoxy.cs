using System;
//* METODO EQUALS -- Confronta due oggetti obj
public class Punto
{
    public int x;
    public int y;

    //sovrascrive Equals per confrontare coordinate
    public override bool Equals(object obj)
    {
        if (obj is Punto altro)//se l'oggetto è un punto
        {
            return this.x == altro.x && this.y == altro.y;
        }
        return false;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Punto a = new Punto() { x = 1, y = 2 };
        Punto b = new Punto() { x = 1, y = 2 };

        Console.WriteLine(a.Equals(b)); //true, sono due oggetti diversi ma che hanno le stesse coordinate
    }
}