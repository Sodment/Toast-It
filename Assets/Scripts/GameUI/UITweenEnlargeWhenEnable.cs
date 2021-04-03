using UnityEngine;

public class UITweenEnlargeWhenEnable : MonoBehaviour
{
    public RectTransform rectTransform;
    public LeanTweenType easeType;
    public float time;

    public bool playClipOnStart;
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject Soundeffects;
    void OnEnable()
    {
        rectTransform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, time).setEase(easeType).setOnStart(OnStart);
    }

    void OnStart()
    {
        if(playClipOnStart && Soundeffects.activeSelf)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
