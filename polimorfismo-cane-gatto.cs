// superclasse con metodo virtual
public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

// sottoclasse con override 
public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia.");
    }
}

// sottoclasse con override (II)
public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // lista di animali
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        // polimorfismo in azione: ogni oggetto chiama la sua versione di FaiVerso()
        foreach (Animale a in animali)
        {
            a.FaiVerso();// comportamento specifico di Cane o Gatto
        }

        Animale c = new Cane();// is Cane
        if (c is Cane)
        {
            ((Cane)c).FaiVerso();
        }

        Animale g = new Gatto();// is Gatto
        if (g is Gatto)
        {
            ((Gatto)g).FaiVerso();
        }
    }
}