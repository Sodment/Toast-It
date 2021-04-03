using UnityEngine;
/// <summary>
/// Class handling disabling GameObject when entering a picked state
/// </summary>
public class DisableOnGameState : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToDisable;


    private void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.SwitchingToOrder.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.SwitchingToShapeChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.SwitchingToToastFrying.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.SwitchingToButterChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.SwitchingToStampleChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.SwitchingToToastBurned.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.SwitchingToTapToEat.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.SwitchingToSummary.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.SwitchingToShop.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.SwitchingToOptions.AddListener(DisableGameObject);
                break;
        }
    }
    /// <summary>
    /// Method disables GameObject
    /// </summary>
    void DisableGameObject()
    {
        gameObjectToDisable.SetActive(false);
    }
}
