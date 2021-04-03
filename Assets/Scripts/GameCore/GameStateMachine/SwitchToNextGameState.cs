using UnityEngine;
/// <summary>
/// Class for switching to next game state
/// </summary>
public class SwitchToNextGameState : MonoBehaviour
{
    /// <summary>
    /// Method for switching to next state when called
    /// </summary>
    public void Switch()
    {
        GameManager.instance.SwitchToNextState();
    }
}
