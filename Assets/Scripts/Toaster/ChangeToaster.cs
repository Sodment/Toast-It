using UnityEngine;

public class ChangeToaster : MonoBehaviour
{
    [SerializeField]
    GameObject currentToaster;
    ShopElement currentToasterShopElement;


    void Start()
    {
        ChangeToasterByName(GamerData.instance.selectedToaster, null);
    }

    public void ChangeToasterByName(string newOne, ShopElement newToaster)
    {
        if(currentToasterShopElement != null)
        {
            currentToasterShopElement.UncheckToaster();
        }
        currentToasterShopElement = newToaster;

        GameObject tmp =(GameObject)Instantiate(Resources.Load("Toasters/" + newOne, typeof(GameObject)));
        tmp.transform.parent = currentToaster.transform.parent.transform;
        tmp.transform.position = currentToaster.transform.position;
        tmp.transform.rotation = currentToaster.transform.rotation;
        tmp.transform.localScale = currentToaster.transform.localScale;
        Destroy(currentToaster);
        currentToaster = tmp;
        currentToaster.GetComponent<Toaster>().ForceActivePrepare();
        GamerData.instance.selectedToaster = newOne;
    }
}
