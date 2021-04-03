using UnityEngine;

public class ToasterPartMovment : MonoBehaviour
{
    public Transform readyPos;
    public Transform donePos;

    private void Start()
    {
        GameManager.instance.SwitchingToToastFrying.AddListener(MoveToReadyPos);
        GameManager.instance.QuittingToastFrying.AddListener(MoveToDonePos);
    }
    public void MoveToReadyPos()
    {
        LeanTween.cancel(gameObject);
        LeanTween.move(gameObject, readyPos.position, 0.5f).setEase(LeanTweenType.easeOutElastic);
    }

    public void MoveToDonePos()
    {
        LeanTween.cancel(gameObject);
        LeanTween.move(gameObject, donePos.position, 0.5f).setEase(LeanTweenType.easeOutElastic);
    }

}
