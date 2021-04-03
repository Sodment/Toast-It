using UnityEngine;
using UnityEngine.UI;
public class ShopBuying : MonoBehaviour
{
    public GameObject shopObject;
    

    public void BuyToaster(string name, ulong price)
    {
        if(GamerData.instance.butters >= price)
        {
            GamerData.instance.butters -= price;
            GamerData.instance.unlockedToasters.Add(name);
            Text shopText = shopObject.GetComponent<Text>();
            shopText.text = GamerData.instance.butters.ToString();
            SaveGameMenager.instance.SaveGame();
        }
        
    }
}
