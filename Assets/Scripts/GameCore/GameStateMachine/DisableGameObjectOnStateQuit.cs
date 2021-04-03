using UnityEngine;
/// <summary>
/// Class handling disabling GameObject when Quitting a picked state
/// </summary>
public class DisableGameObjectOnStateQuit : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToDisable;


    private void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.QuittingUIMainView.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.QuittingOrder.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.QuittingShapeChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.QuittingToastFrying.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.QuittingButterChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.QuittingStampleChoice.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.QuittingToastBurned.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.QuittingTapToEat.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.QuittingSummary.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.QuittingShop.AddListener(DisableGameObject);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.QuittingOptions.AddListener(DisableGameObject);
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
