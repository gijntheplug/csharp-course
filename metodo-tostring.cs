public class Persona
{
    public string? Nome;
    public int Eta;

    public override string ToString()
    {
        return $"Nome: {Nome}, Età: {Eta}";
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Persona p = new Persona { Nome = "Mario", Eta = 30 };
            Console.WriteLine(p);
        }
    }
}