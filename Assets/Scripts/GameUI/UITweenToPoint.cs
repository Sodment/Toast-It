using UnityEngine;

public class UITweenToPoint : MonoBehaviour
{
    public RectTransform target;
    public GameObject gameObjectToTween;
    public float duration = 1f;
    [Space]
    public LeanTweenType easeType = LeanTweenType.easeInSine;


    private void Awake()
    {
        if(gameObjectToTween == null)
        {
            gameObjectToTween = gameObject;
        }
    }


    public void Tween()
    {
        LeanTween.move(gameObjectToTween, target, duration).setEase(easeType);
    }
}
