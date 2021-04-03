using UnityEngine;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    public Sprite elementWhenNotBuyed;
    public Sprite elementWhenBuyed;
    public Image shopElementImage;
    public ulong price = 30;

    public Image buyImage;
    public Text text;

    bool isBuyed = false;
    bool selected = false;

    public ShopBuying shopBuying;
    public ShopUnlockedObjects shopUnlockedObjects;

    public ChangeToaster changeToaster;

    public bool isBuyedByDefault = false;

    private void Start()
    {
        SetLockedSprite();
        shopUnlockedObjects.UpdateView();
        //Debug.LogFormat("\n \n Text: {0} Dlugosc: {1} \n Text: {2} Dlugosc: {3}", gameObject.name, gameObject.name.Length, GamerData.instance.selectedToaster, GamerData.instance.selectedToaster.Length); ;
        
    }

    public void TryToBuy()
    {
        if(isBuyedByDefault)
        {
            changeToaster.ChangeToasterByName(gameObject.name, this);
            buyImage.enabled = true;
            return;
        }
        if(isBuyed)
        {
            changeToaster.ChangeToasterByName(gameObject.name, this);
            buyImage.enabled = true;
        }
        else
        {
            shopBuying.BuyToaster(gameObject.name, price);
            shopUnlockedObjects.UpdateView();
        }
        
    }

    public void UncheckToaster()
    {
        buyImage.enabled = false;
        text.text = "";
    }

    public void CheckToaster()
    {
        changeToaster.ChangeToasterByName(gameObject.name, this);
        buyImage.enabled = true;
        isBuyed = true;
        text.text = "";
    }

    public void SetUnlockedSprite()
    {
        isBuyed = true;
        buyImage.enabled = false;
        text.text = "";
        shopElementImage.sprite = elementWhenBuyed;

        if (GamerData.instance.selectedToaster.Equals(gameObject.name, System.StringComparison.InvariantCultureIgnoreCase))
        {
            //Debug.Log("JEST");
            this.CheckToaster();
            isBuyed = true;
        }
    }

    public void SetLockedSprite()
    {
        if (!isBuyedByDefault)
        {
            isBuyed = false;
            buyImage.enabled = true;
            buyImage.color = Color.white;
            text.text = price + "";
            shopElementImage.sprite = elementWhenNotBuyed;
        }
        else
        {
            SetUnlockedSprite();
        }

        if (GamerData.instance.selectedToaster.Equals(gameObject.name, System.StringComparison.InvariantCultureIgnoreCase))
        {
            ///Debug.Log("JEST");
            this.CheckToaster();
            isBuyed = true;
        }

    }
}
