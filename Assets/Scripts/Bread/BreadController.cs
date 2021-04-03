using UnityEngine;
/// <summary>
/// This class contorls the animator of bread
/// </summary>
public class BreadController : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// Makes bread darker after call
    /// </summary>
    public void MakeItDark()
    {
        anim.SetInteger("State", 3);
    }

    /// <summary>
    /// Resets bread state to default color and mesh
    /// </summary>
    public void FirstPrepare()
    {
        anim.SetInteger("State", 0);
        anim.SetFloat("Fill", 0.0f);
    }

    /// <summary>
    /// Puts butter on bread
    /// </summary>
    public void FinalPrepare()
    {
        anim.SetInteger("State", 1);
    }

    /// <summary>
    /// Destroys bread
    /// </summary>
    public void FinalDestroy()
    {
        anim.SetInteger("State", 2);
    }

}
