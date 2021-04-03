using UnityEngine;

public class UITweenPulsation : MonoBehaviour
{
    public bool playOnAwake = false;
    [Space]
    public Vector3 targetScale = Vector3.one;
    public float duration = 1f;
    [Space]
    public LeanTweenType easeType = LeanTweenType.easeInSine;

    private bool play = false;
    

    
    private void Awake()
    {
        if(playOnAwake)
        {
            play = true;
            Tween();
        }
    }

    public void Tween()
    {
        play = true;
        LeanTween.scale(gameObject, targetScale, duration).setLoopPingPong().setEase(easeType);
    }
}
