public class Utente : MonoBehaviour{
  public enum LivelloAccesso {Guest, User, Admin}
  [SerializedField]
  private LivelloAccesso liv;

  private void Start(){
    switch(liv){
        case: LivelloAccesso.Guest:
          Debug.Log("Sei un Ospite.");
          break;
        case: LivelloAccesso.User:
          Debug.Log("Sei un Utente Registrato.");
          break;
        case: LivelloAccesso.Admin:
          Debug.Log("Sei un Amministratore.");
          break;
    }
  }
}
  
