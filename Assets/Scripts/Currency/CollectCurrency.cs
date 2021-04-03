using UnityEngine;
/// <summary>
/// Class used for button after game that adds currency to player for completing level
/// </summary>
public class CollectCurrency : MonoBehaviour
{
    /// <summary>
    /// Method adds butte earned through playing to GamerData and saves game
    /// </summary>
    public void CollectButters()
    {
        GamerData.instance.butters += CurrencyManager.instance.buttersToAdd;
        SaveGameMenager.instance.SaveGame();
    }
}
