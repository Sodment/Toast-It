using UnityEngine;

public class KnifeController : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Set()
    {
        anim.SetBool("Smaru", true);
    }

    public void reset()
    {
        anim.SetBool("Smaru", false);
    }
}
