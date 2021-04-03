using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Class for seting the text on summary screen that tells
/// how much currency the player earned 
/// and setting how much currency player has in shop screen
/// </summary>
public class CurrencySetText : MonoBehaviour
{
    public GameObject shopObject;
    public GameObject collectObject;
    void Start()
    {
        GameManager.instance.SwitchingToShop.AddListener(SetShopText);
        GameManager.instance.QuittingTapToEat.AddListener(SetCollectText);
    }
    /// <summary>
    /// Method sets Text in Shop screen
    /// </summary>
    public void SetShopText()
    {
        Text shopText = shopObject.GetComponent<Text>();
        shopText.text = GamerData.instance.butters.ToString();
        Debug.Log(shopText.text);
    }
    /// <summary>
    /// Method sets Text on button in Summary screen
    /// </summary>
    public void SetCollectText()
    {
       Text collectButtonText = collectObject.GetComponent<Text>();
       collectButtonText.text = "+" + CurrencyManager.instance.buttersToAdd.ToString() + "$";
    }
}
