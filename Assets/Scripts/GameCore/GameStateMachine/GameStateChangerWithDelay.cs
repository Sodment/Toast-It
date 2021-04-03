using UnityEngine;
/// <summary>
/// Class for changing game state with delay measured with seconds
/// </summary>
public class GameStateChangerWithDelay : MonoBehaviour
{
    public float delay;
    public GameStateMachine.GameState stateToSwitch;
    public bool invokeOnce = true;
    //bool doIt = true;
    //bool invoked = false;
    public void Switch()
    {
        if(invokeOnce)
        {
          //  GameManager.instance.OnStateChange.AddListener(Interrupt);
            Invoke("SwitchState", delay);
           // invoked = true;
        }
        
    }
   /* void Interrupt()
    {
        doIt = false;
    }*/
}
