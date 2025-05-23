using System;
using System.Security.Cryptography.X509Certificates;
//classe padre (superclasse)
public class Animale
{
    public virtual void Verso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

//classe figlio di animale (sottoclasse)
public class Cane : Animale
{
    //metodo specifico della classe figlio (sottoclasse)
    public void Scodinzola()
    {
        Console.WriteLine("Il cane scodinzola.");
    }

    public override void Verso()//override del metodo VIRTUAL della superclasse
    {
        Console.WriteLine("Bau!");//si può cambiare il verso dell'animale in base a qual è
    }
}

//programma principale
public class Program
{
    public static void Main()
    {
        Cane mioCane = new Cane();//creazione di un oggetto della sottoclasse
        mioCane.Verso();//metodo ereditato da //*SUPERCLASSE
        mioCane.Scodinzola();//metodo definito da //!SOTTOCLASSE
    }
}
