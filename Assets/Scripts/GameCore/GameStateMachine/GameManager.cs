using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Class contains an event system designed around the idea of
/// entering and quitting diffrent game states; Evey time you enter or quit a game state 
/// an eventy is is invoked making it simpler to perform a task on selected time
/// <example>
/// When you want a sound to be played when quitting UiMainView you could use the GameManager event system:
/// <code>
/// void Start()
/// {
///     GameManager.instance.QuittingUIMainView.AddListener(PlaySound());
///     
/// }
/// void PlayeSound()
/// {
///     sound.play();
/// }
/// </code>
/// The mmethod that you are adding to an event should be of void type and should not take any parameters
/// </example>
/// </summary>
[RequireComponent(typeof(GameStateMachine))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Universal Events
    public UnityEvent OnStateChange;


    //CustomEvents
    // Entering state events
    public UnityEvent SwitchingToUIMainView;
    public UnityEvent SwitchingToOrder;
    public UnityEvent SwitchingToShapeChoice;
    public UnityEvent SwitchingToToastFrying;
    public UnityEvent SwitchingToButterChoice;
    public UnityEvent SwitchingToStampleChoice;
    public UnityEvent SwitchingToToastBurned;
    public UnityEvent SwitchingToTapToEat;
    public UnityEvent SwitchingToSummary;
    public UnityEvent SwitchingToShop;
    public UnityEvent SwitchingToOptions;

    // Quitting State events
    public UnityEvent QuittingUIMainView;
    public UnityEvent QuittingOrder;
    public UnityEvent QuittingShapeChoice;
    public UnityEvent QuittingToastFrying;
    public UnityEvent QuittingButterChoice;
    public UnityEvent QuittingStampleChoice;
    public UnityEvent QuittingToastBurned;
    public UnityEvent QuittingTapToEat;
    public UnityEvent QuittingSummary;
    public UnityEvent QuittingShop;
    public UnityEvent QuittingOptions;

    // GameStateMachine 
    GameStateMachine gameStateMachine;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        gameStateMachine = gameObject.GetComponent<GameStateMachine>();
        
    }
    /// <summary>
    /// Method that switches to chosen GameState and invokes corresponding to state events
    /// </summary>
    /// <param name="state"> A GameState type (enum) that is a state that you want to switch to </param>
    public void SwitchGameState(GameStateMachine.GameState state)
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                SwitchingToUIMainView.Invoke();
                break;
            case GameStateMachine.GameState.Order:
                SwitchingToOrder.Invoke();
                break;
            case GameStateMachine.GameState.ShapeChoice:
                SwitchingToShapeChoice.Invoke();
                break;
            case GameStateMachine.GameState.ToastFrying:
                SwitchingToToastFrying.Invoke();
                break;
            case GameStateMachine.GameState.ButterChoice:
                SwitchingToButterChoice.Invoke();
                break;
            case GameStateMachine.GameState.StampleChoice:
                SwitchingToStampleChoice.Invoke();
                break;
            case GameStateMachine.GameState.ToastBurned:
                SwitchingToToastBurned.Invoke();
                break;
            case GameStateMachine.GameState.TapToEat:
                SwitchingToTapToEat.Invoke();
                break;
            case GameStateMachine.GameState.Summary:
                SwitchingToSummary.Invoke();
                break;
            case GameStateMachine.GameState.Shop:
                SwitchingToShop.Invoke();
                break;
            case GameStateMachine.GameState.Options:
                SwitchingToOptions.Invoke();
                break;
        }

        GameStateMachine.GameState lastState = gameStateMachine.currentState;
        gameStateMachine.SwitchToState(state);

        //switch (gameStateMachine.currentState)
        switch(lastState)
        {
            case GameStateMachine.GameState.UIMainView:
                QuittingUIMainView.Invoke();
                break;
            case GameStateMachine.GameState.Order:
                QuittingOrder.Invoke();
                break;
            case GameStateMachine.GameState.ShapeChoice:
                QuittingShapeChoice.Invoke();
                break;
            case GameStateMachine.GameState.ToastFrying:
                QuittingToastFrying.Invoke();
                break;
            case GameStateMachine.GameState.ButterChoice:
                QuittingButterChoice.Invoke();
                break;
            case GameStateMachine.GameState.StampleChoice:
                QuittingStampleChoice.Invoke();
                break;
            case GameStateMachine.GameState.ToastBurned:
                QuittingToastBurned.Invoke();
                break;
            case GameStateMachine.GameState.TapToEat:
                QuittingTapToEat.Invoke();
                break;
            case GameStateMachine.GameState.Summary:
                QuittingSummary.Invoke();
                break;
            case GameStateMachine.GameState.Shop:
                QuittingShop.Invoke();
                break;
            case GameStateMachine.GameState.Options:
                QuittingOptions.Invoke();
                break;
        }

        //gameStateMachine.SwitchToState(state);
        OnStateChange.Invoke();
    }
    /// <summary>
    /// Method switches to NEXT state of the game so a couple of utility states such as shop/options are lleft behind
    /// cuz they are not really part of the game loop
    /// </summary>
    public void SwitchToNextState()
    {
        switch(gameStateMachine.currentState)
        {
            case GameStateMachine.GameState.UIMainView:
                SwitchGameState(GameStateMachine.GameState.Order);
                break;
            case GameStateMachine.GameState.Order:
                SwitchGameState(GameStateMachine.GameState.ShapeChoice);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                SwitchGameState(GameStateMachine.GameState.ToastFrying);
                break;
            case GameStateMachine.GameState.ToastFrying:
                SwitchGameState(GameStateMachine.GameState.ButterChoice);
                break;
            case GameStateMachine.GameState.ButterChoice:
                SwitchGameState(GameStateMachine.GameState.StampleChoice);
                break;
            case GameStateMachine.GameState.StampleChoice:
                SwitchGameState(GameStateMachine.GameState.TapToEat);
                break;
            case GameStateMachine.GameState.TapToEat:
                SwitchGameState(GameStateMachine.GameState.Summary);
                break;
            case GameStateMachine.GameState.Summary:
                SwitchGameState(GameStateMachine.GameState.Order);
                break;
        }
    }

    /// <summary>
    /// Utility method to  get state from GameStateMachine
    /// </summary>
    /// <returns></returns>
    public GameStateMachine.GameState GetCurrentState()
    {
        return gameStateMachine.currentState;
    }
        
}
