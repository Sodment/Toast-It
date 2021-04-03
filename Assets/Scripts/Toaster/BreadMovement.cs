using UnityEngine;

public class BreadMovement : MonoBehaviour
{
    public Transform bakeSlot;
    public Transform hoverSlot;
    public Transform eatSlot;

    private void Start()
    {
        GameManager.instance.SwitchingToOrder.AddListener(MoveToHoverSlot);
        GameManager.instance.SwitchingToToastFrying.AddListener(MoveToBakeSlot);
        GameManager.instance.SwitchingToButterChoice.AddListener(MoveToEatSlot);
        GameManager.instance.SwitchingToToastBurned.AddListener(MoveToEatSlot);
    }
    public void MoveToBakeSlot()
    {
        LeanTween.cancel(gameObject);
        LeanTween.move(gameObject, bakeSlot.position, 1.2f).setEase(LeanTweenType.easeOutElastic);
    }

    public void MoveToHoverSlot()
    {
        LeanTween.cancel(gameObject);
        LeanTween.move(gameObject, hoverSlot.position, 1.2f).setEase(LeanTweenType.easeOutElastic);
    }

    public void MoveToEatSlot()
    {
        LeanTween.cancel(gameObject);
        LeanTween.move(gameObject, eatSlot.position, 1.2f).setEase(LeanTweenType.easeOutElastic);
    }
}
