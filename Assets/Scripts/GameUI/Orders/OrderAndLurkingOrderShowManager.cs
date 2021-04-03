using UnityEngine;

public class OrderAndLurkingOrderShowManager : MonoBehaviour
{
    public Animator orderAnimator;
    public Animator orderLurkingAnimator;

    public GameObject orderCanvas;
    public GameObject orderLurkingCanvas;

    private void Start()
    {
        GameManager.instance.SwitchingToOrder.AddListener(ShowOrder);
        GameManager.instance.QuittingOrder.AddListener(HideOrder);
        GameManager.instance.QuittingOrder.AddListener(ResetTriggers);
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            ShowOrder();
            HideLurkingOrder();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ShowLurkingOrder();
            HideOrder();
        }
    }*/

   /* public void ShowLurkingOrder()
    {
        orderLurkingCanvas.SetActive(true);
        orderCanvas.SetActive(true);

        orderLurkingAnimator.SetTrigger("show");
    }

    public void HideLurkingOrder()
    {
        orderLurkingCanvas.SetActive(true);
        orderCanvas.SetActive(true);

        orderLurkingAnimator.SetTrigger("hide");
    }*/

    public void ShowOrder()
    {
        orderLurkingCanvas.SetActive(true);
        orderCanvas.SetActive(true);
        //Debug.Log("Show");
        orderAnimator.SetTrigger("show");
    }

    public void HideOrder()
    {
        orderLurkingCanvas.SetActive(true);
        orderCanvas.SetActive(true);
       // Debug.Log("HIde");
        orderAnimator.SetTrigger("hide");
    }

    private void ResetTriggers() //Prowizorka dopuki UI nie zostanie ogarnięte dobrze
    {
        orderAnimator.ResetTrigger("show");
        orderAnimator.ResetTrigger("hide");
    }
}
