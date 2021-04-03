using UnityEngine;
/// <summary>
/// Class handling enabling GameObject on entering picked state with delay measured in seconds
/// </summary>
public class EnableOnGameStateWithDelay : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToEnable;


    public float delay;

    public void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.SwitchingToOrder.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.SwitchingToShapeChoice.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.SwitchingToToastFrying.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.SwitchingToButterChoice.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.SwitchingToStampleChoice.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.SwitchingToToastBurned.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.SwitchingToTapToEat.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.SwitchingToSummary.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.SwitchingToShop.AddListener(InvokeEnable);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.SwitchingToOptions.AddListener(InvokeEnable);
                break;
        }
    }
    /// <summary>
    /// Method calls a function with set delay in seconds
    /// </summary>
    void InvokeEnable()
    {
        Invoke("EnableGameObject", delay);
    }
    /// <summary>
    /// Method enables GameObject
    /// </summary>
    void EnableGameObject()
    {
        gameObjectToEnable.SetActive(true);
    }

}
