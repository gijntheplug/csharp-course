public interface IShape
{
    void Draw(); // Metodo per disegnare la forma
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno un Cerchio");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("Disegno un Quadrato");
    }
}

// Classe astratta che definisce il Factory Method
public abstract class ShapeCreator
{
    public abstract IShape CreateShape(string type); // Factory Method astratto
}

// Implementazione concreta del Factory Method
public class ConcreteShapeCreator : ShapeCreator
{
    public override IShape CreateShape(string type)
    {
        if (type.ToLower() == "cerchio")
        {
            return new Circle();
        }
        else if (type.ToLower() == "quadrato")
        {
            return new Square();
        }

        // Gestione di input non valido
        Console.WriteLine("Errore! Tipo di forma inserita non valido.");
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Richiesta all'utente della forma da disegnare
        Console.Write("\nQuale forma vuoi disegnare? (scrivi 'Cerchio' o 'Quadrato'): ");
        string forma = Console.ReadLine();

        ShapeCreator creator = new ConcreteShapeCreator();
        IShape shape = creator.CreateShape(forma);

        shape.Draw(); // Chiamata al metodo Draw della forma creata
    }
}