public class Settimana{
  public enum GiornoSettimana {Lunedì, Martedì, Mercoledì, Giovedì, Venerdì, Sabato, Domenica}
  private GiornoSettimana giorno;
  private void Start(){
    switch(giorno){
        case: giorno.Lunedì:
          Debug.Log("Il giorno è Lunedì.");
          break;
        case: giorno.Martedì:
          Debug.Log("Il giorno è Martedì.");
          break;
        case: giorno.Mercoledì:
          Debug.Log("Il giorno è Mercoledì.");
          break;
        case: giorno.Giovedì:
          Debug.Log("Il giorno è Giovedì.");
          break;
        case: giorno.Venerdì:
          Debug.Log("Il giorno è Venerdì.");
          break;
        case: giorno.Sabato:
          Debug.Log("Il giorno è Sabato.");
          break;
        case: giorno.Domenica:
          Debug.Log("Il giorno è Domenica.");
          break;
    }
  }
}
