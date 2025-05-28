//! INTERFACCIA PRODOTTO: definisce l'interfaccia del prodotto
public interface IProdotto//interfaccia IProdotto
{
    void Operation();
}

//! CONCRETE PRODUCT A: implementa IProdotto
public class ConcreteProductA : IProdotto
{
    public void Operation()
    {
        Console.WriteLine("Esecuzione di ConcreteProductA.Operation()");
    }
}

//! CONCRETE PRODUCT B: implementa IProdotto
public class ConcreteProductB : IProdotto
{
    public void Operation()
    {
        Console.WriteLine("Esecuzione di ConcreteProductB.Operation()");
    }
}

//! CREATOR: dichiara il Factory Method
public abstract class Creator
{
    //* Factory Method: restituisce IProdotto
    public abstract IProdotto FactoryMethod();

    //* Un metodo del creator che usa il prodotto
    public void AnOperation()
    {
        //Creazione del prodotto tramite FactoryMethod
        IProdotto prodotto = FactoryMethod();
        prodotto.Operation();
    }
}

//! CONCRETE CREATOR A: implementa FactoryMethod per CONCRETE PRODUCT A
public class ConcreteCreatorA : Creator
{
    public override IProdotto FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

//! CONCRETE CREATOR b: implementa FactoryMethod per CONCRETE PRODUCT B
public class ConcreteCreatorB : Creator
{
    public override IProdotto FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

//* MAIN
public class Program
{
    static void Main(string[] args)
    {
        Creator creatorA = new ConcreteCreatorA();
        creatorA.AnOperation(); //! USA CONCRETE PRODUCT A

        Creator creatorB = new ConcreteCreatorB();
        creatorB.AnOperation(); //! USA CONCRETE PRODUCT B
    }
}