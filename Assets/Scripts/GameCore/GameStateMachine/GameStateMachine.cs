using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
   public enum GameState
   {
        UIMainView, // Starting view with "tap to play" screen
        Order, // OrderScreen
        ShapeChoice, // Choosing bread shape
        ToastFrying, // Toast is frying and you have to play a minigame
        ButterChoice, // Choosing type of topping (butter)
        StampleChoice, // Choosing stample
        ToastBurned, // BackupState from previous version that we left for future if needed
        TapToEat, // Eating the toast (three taps)
        Summary, // Level Summary
        Shop, //Shopping state
        Options, //Options state
    }

   [SerializeField]
   public GameState currentState;
    /// <summary>
    /// Method switches state to a new one that is desired
    /// </summary>
    /// <param name="state"> A GameState type parameter that takes a state that you wish to switch to </param>
   public void SwitchToState(GameState state)
   {
     // Debug.Log("Poprzedni stan:" + currentState);
        currentState = state;
     // Debug.Log("Obecny stan:" + currentState);
   }
}
