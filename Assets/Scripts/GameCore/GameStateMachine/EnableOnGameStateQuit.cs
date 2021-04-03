using UnityEngine;
/// <summary>
/// Class handling enabling GameObject when quitting a picked state
/// </summary>
public class EnableOnGameStateQuit : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public GameObject gameObjectToEnable;

    void Start()
    {
            switch (state)
            {
                case GameStateMachine.GameState.UIMainView:
                    GameManager.instance.QuittingUIMainView.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.Order:
                    GameManager.instance.QuittingOrder.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.ShapeChoice:
                    GameManager.instance.QuittingShapeChoice.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.ToastFrying:
                    GameManager.instance.QuittingToastFrying.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.ButterChoice:
                    GameManager.instance.QuittingButterChoice.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.StampleChoice:
                    GameManager.instance.QuittingStampleChoice.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.ToastBurned:
                    GameManager.instance.QuittingToastBurned.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.TapToEat:
                    GameManager.instance.QuittingTapToEat.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.Summary:
                    GameManager.instance.QuittingSummary.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.Shop:
                    GameManager.instance.QuittingShop.AddListener(EnableGameObject);
                    break;
                case GameStateMachine.GameState.Options:
                    GameManager.instance.QuittingOptions.AddListener(EnableGameObject);
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
