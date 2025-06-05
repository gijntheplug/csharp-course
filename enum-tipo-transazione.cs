public class Transaction : Monobehaviour{
  public enum TipoTransazione {Acquisto, Rimborso, Trasferimento}
  [SerializedField]
  private TipoTransazione tipo;

  private void Start(){
    switch(tipo){
        case: TipoTransazione.Acquisto:
          Debug.Log("Hai appena effettuato un Acquisto.");
          break;
        case: TipoTransazione.Rimborso:
          Debug.Log("Hai appena effettuato un Rimborso.");
          break;
        case: TipoTransazione.Trasferimento:
          Debug.Log("Hai appena effettuato un Trasferimento.");
          break;
    }
  }
}
