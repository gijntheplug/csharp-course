using System;
using System.Collections.Generic;

//* 1. interfaccia IObserver che definisce il metodo di notifica
public interface IObserver
{
    void Update(int nuovoStato);//aggiorna(int nuovoStato)
}

//* 2. interfaccia ISubject che aggiunge/rimuove observer e notifica
public interface ISubject
{
    void Attach(IObserver observer);//aggiunge observer
    void Detach(IObserver observer);//rimuove observer
    void Notify();//metodo per notificare
}

//* 3. classe ConcreteSubject che implementa ISubject 
public class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _osservatori = new List<IObserver>();//lista di _osservatori tipizzata a interfaccia IObserver
    private int _stato;
    public int Stato
    {
        get => _stato;
        set
        {
            _stato = value;
            Notify();
        }
    }
    public void Attach(IObserver observer)//metodo per aggiungere l'observer
    {
        _osservatori.Add(observer);
    }
    public void Detach(IObserver observer)//metodo per rimuovere l'observer
    {
        _osservatori.Remove(observer);
    }
    public void Notify()//metodo per aggiornare lo stato dell'observer
    {
        foreach (IObserver observer in _osservatori)//per ogni observer nella lista, aggiorna
        {
            observer.Update(_stato);
        }
    }
}

//* 4. classe ConcreteObserver che implementa IObserver
public class ConcreteObserver : IObserver
{
    private readonly string _nome;
    private int _observerState;
    public ConcreteObserver(string nome)
    {
        _nome = nome;
    }

    //viene chiamato dal Subject con il nuovo stato
    public void Update(int nuovoStato)
    {
        _observerState = nuovoStato;
        Console.WriteLine($"{_nome} ha ricevuto un aggiornamento, stato = {_observerState}");
    }
}

//* 5. il client crea il Subject e alcuni Observer, modella i cambi di stato
public class Program
{
    static void Main(string[] args)
    {
        var subject = new ConcreteSubject();

        var observerA = new ConcreteObserver("Observer A");
        var observerB = new ConcreteObserver("Observer B");

        //registrazione degli observer
        subject.Attach(observerA);
        subject.Attach(observerB);

        //cambia lostato dei subject, innescando Notify(); e richiamando Update(); su tutti gli observer
        subject.Stato = 5;
        subject.Stato = 10;

        //rimuove con Detach();
        subject.Detach(observerA);

        //cambia di nuovo stato, solo ObserverB viene modificato
        subject.Stato = 15;
    }
}