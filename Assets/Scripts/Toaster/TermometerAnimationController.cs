using UnityEngine;

public class TermometerAnimationController : MonoBehaviour
{
    public Transform target;
    public float moveTime = 0.5f;
    Vector3 startPos;
    Vector3 startRoot;
    Animator anim;
    void Start()
    {
        startPos = transform.position;
        startRoot = transform.rotation.eulerAngles;
        GameManager.instance.SwitchingToToastFrying.AddListener(StartAnimate);
        GameManager.instance.QuittingToastFrying.AddListener(StopAnimate);
        TapToaster.instance.tapEvent.AddListener(PlayAnimationOnTap);
        anim = GetComponent<Animator>();
    }

    void StartAnimate()
    {
        transform.LeanMove(target.position, moveTime).setEase(LeanTweenType.easeOutBounce);
        transform.LeanRotate(target.rotation.eulerAngles, moveTime);
    }

    void StopAnimate()
    {
        transform.LeanMove(startPos, moveTime);
        transform.LeanRotate(startRoot, moveTime);
    }

    void PlayAnimationOnTap()
    {
        anim.Play("TermometerAnimation");
    }
}
