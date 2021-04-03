using UnityEngine;
/// <summary>
/// Class for changing state to  a desired one
/// </summary>
public class GameStateSwitcher : MonoBehaviour
{
    public GameStateMachine.GameState stateToSwitch;
    /// <summary>
    /// Changes state to desired one that is set in Inspector
    /// </summary>
    public void SwitchState()
    {
        GameManager.instance.SwitchGameState(stateToSwitch);
    }
}
