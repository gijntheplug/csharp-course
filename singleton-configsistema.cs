using System;
using System.Collections.Generic;

public sealed class ConfigurazioneSistema
{
    //Singleton
    private static ConfigurazioneSistema _instance;
    private Dictionary<string, string> config;

    public static ConfigurazioneSistema GetInstance()
    {
        if (_instance is null)
            _instance = new ConfigurazioneSistema();

        return _instance;
    }
    private ConfigurazioneSistema()
    {
        config = new Dictionary<string, string>();
    }
    public void Imposta(string chiave, string valore)
    {
        _instance = GetInstance();
        instance.config[chiave] = valore;
    }
    public string Leggi(string chiave)
    {
        if (chiave is not null)
        {
            return chiave;
        }
        else
        {
            return "Chiave non disponibile.";
        }
    }
    public void StampaTutte(string chiave, string valore)
    {
        foreach (Configurazione config in _instance.config)
        {
            Console.WriteLine($"{config.chiave}: {config.valore}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Usa GetInstance();
        _instance = ConfigurazioneSistema.GetInstance();

        // Usa Imposta();
        ConfigurazioneSistema.Imposta("ChiaveA", "ValoreA");
        ConfigurazioneSistema.Imposta("ChiaveB", "ValoreB");

        // Usa Leggi();
        Console.WriteLine("Leggi ChiaveA: " + ConfigurazioneSistema.Leggi("ChiaveA"));
        Console.WriteLine("Leggi ChiaveB: " + ConfigurazioneSistema.Leggi("ChiaveB"));

        // Usa StampaTutte();
        Console.WriteLine("Tutte le configurazioni:");
        ConfigurazioneSistema.StampaTutte();

        // Verifica che GetInstance restituisce sempre la stessa istanza
        Console.WriteLine("Entrambi i moduli usano la stessa istanza? " +
            (ConfigurazioneSistema.GetInstance() == _instance));
    }
}