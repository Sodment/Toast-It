using UnityEngine;
/// <summary>
/// Class handling enabling GameObject when entering a picked state
/// </summary>
public class EnableOnGameState : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToEnable;


    private void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.SwitchingToOrder.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.SwitchingToShapeChoice.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.SwitchingToToastFrying.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.SwitchingToButterChoice.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.SwitchingToStampleChoice.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.SwitchingToToastBurned.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.SwitchingToTapToEat.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.SwitchingToSummary.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.SwitchingToShop.AddListener(EnableGameObject);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.SwitchingToOptions.AddListener(EnableGameObject);
                break;
        }
    }
    /// <summary>
    /// Method enables GameObject
    /// </summary>
    void EnableGameObject()
    {
        gameObjectToEnable.SetActive(true);
    }
}
