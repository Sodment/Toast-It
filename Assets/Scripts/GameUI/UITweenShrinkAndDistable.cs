using UnityEngine;

public class UITweenShrinkAndDistable : MonoBehaviour
{
    public RectTransform rectTransformToTween;
    public float duration = 1f;
    [Space]
    public LeanTweenType easeType = LeanTweenType.easeInSine;

    Vector3 defaultScale = Vector3.one;

    private void Start()
    {
        defaultScale = rectTransformToTween.localScale;
    }

    public void Tween()
    {
        LeanTween.scale(rectTransformToTween, Vector3.zero, duration).setEase(easeType).setOnComplete(DistableGameObject);
    }

    public void DistableGameObject()
    {
        gameObject.SetActive(false);
    }

    public void ActivateGameObject()
    {
        gameObject.SetActive(true);
    }

    public void ReverseTween()
    {
        LeanTween.scale(rectTransformToTween, defaultScale, duration).setEase(easeType).setOnComplete(ActivateGameObject);
    }
}
