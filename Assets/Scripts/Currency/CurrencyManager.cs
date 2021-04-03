using UnityEngine;
/// <summary>
/// Abstract class that contains methods for currency managment
/// </summary>
public class CurrencyManager : MonoBehaviour
{
    //Termometer termometer;
    public static CurrencyManager instance;
    public ulong buttersToAdd;
    private void Awake()
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
    /// Method that tells how much currency player earned for completing level
    /// </summary>
    /// <param name="value"> A 64bit-signed-int for keeping currency value </param>
    public void GetCurrency(ulong value)
    {
        buttersToAdd = value;
    }
    /// <summary>
    /// Method resets player points gained through playing
    /// </summary>
    public void ResetPoints()
    {
        PointsHolder.instance.points = 0;
    }
}
