using System.Collections.Generic;
using UnityEngine;
public class ShopUnlockedObjects : MonoBehaviour
{
    public List<ShopElement> AllToastersInShop;
    void Start()
    {
        GameManager.instance.SwitchingToShop.AddListener(GetAllOwnedToastersInShop);
    }

    public void GetAllOwnedToastersInShop()
    {
        foreach (ShopElement toaster in AllToastersInShop)
        {
            if (GamerData.instance.unlockedToasters.Contains(toaster.gameObject.name))
            {
                toaster.SetUnlockedSprite();
            }
            else
            {
                toaster.SetLockedSprite();
            }
        }
    }

    public void UpdateView()
    {
        foreach (ShopElement toaster in AllToastersInShop)
        {
            if (GamerData.instance.unlockedToasters.Contains(toaster.gameObject.name))
            {
                toaster.SetUnlockedSprite();
            }
            else
            {
                toaster.SetLockedSprite();
            }
        }
    }

}