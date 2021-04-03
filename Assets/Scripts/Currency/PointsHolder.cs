using UnityEngine;
/// <summary>
/// Class contains amount of point that the player has
/// and a method for resseting them at the end of the level
/// </summary>
public class PointsHolder : MonoBehaviour
{
    public static PointsHolder instance;
    public ulong points = 0;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        GameManager.instance.QuittingSummary.AddListener(ResetPoints);
    }
    /// <summary>
    /// Method resets player points
    /// </summary>
    public void ResetPoints()
    {
        points = 0;
    }
}
