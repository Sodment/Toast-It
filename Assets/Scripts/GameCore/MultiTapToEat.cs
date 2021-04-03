using UnityEngine;
/// <summary>
/// Class for handling state: TapToEat;
/// keep track ofr number of taps and how to react to them;
/// </summary>
public class MultiTapToEat : MonoBehaviour
{
    public GameObject bread1;
    public GameObject bread2;
    public Texture eatTexture;
    public Texture destroyTexture;
    int counter = 0;
    float percentEaten = 0.0f;

    private void OnEnable()
    {
        Start();
        ResetCounterAndPercent();
    }

    void Start()
    {
        //GameManager.instance.SwitchingToSwipeToButter.AddListener(ResetCounterAndPercent);
        //GameManager.instance.SwitchingToSwipeToButter.AddListener(ChangeTextureForEating);
        GameManager.instance.SwitchingToTapToEat.AddListener(ChangeTextureForEating);
        GameManager.instance.QuittingTapToEat.AddListener(ChangeTextureAfterEating);
    }
    /// <summary>
    /// Method resets number of taps and percentege of bread eataen
    /// </summary>
    public void ResetCounterAndPercent()
    {
        counter = 0;
        percentEaten = 0.0f;
        ChangeTextureForEating(); //Dla pewności
    }
    /// <summary>
    /// Method counts every input tap that player makes
    /// </summary>
    public void AddToCounter()
    {
        counter += 1;
        QuitTapToEat();
    }

    /// <summary>
    /// Method sets Texture for the purpose of eating
    /// </summary>
    public void ChangeTextureForEating()
    {
        bread1.GetComponent<Renderer>().material.SetTexture("_DestroyTex", eatTexture);
        bread2.GetComponent<Renderer>().material.SetTexture("_DestroyTex", eatTexture);
        bread1.GetComponent<Renderer>().materials[1].SetTexture("_DestroyTex", eatTexture);
        bread2.GetComponent<Renderer>().materials[1].SetTexture("_DestroyTex", eatTexture);
    }
    /// <summary>
    /// Method is responsible for the eating(every bite is a 0.33 of full bread)
    /// </summary>
    public void DestroyToast()
    {
        percentEaten += 0.33f;
        bread1.GetComponent<Animator>().SetFloat("Fill", percentEaten);
        bread2.GetComponent<Animator>().SetFloat("Fill", percentEaten);
    }
    /// <summary>
    /// Method that check for numbers of taps and if requirements are met it  quits state TapToEat
    /// </summary>
    void QuitTapToEat()
    {
        if(counter >= 3)
        {
            bread1.GetComponent<Animator>().SetInteger("State", 2);
            bread2.GetComponent<Animator>().SetInteger("State", 2);
            //GetComponent<GameStateSwitcher>().SwitchState();
            GetComponent<SwitchToNextGameState>().Switch();
        }
    }
    /// <summary>
    /// Method sets textures back to their orginial ones
    /// </summary>
    void ChangeTextureAfterEating()
    {
        bread1.GetComponent<Renderer>().material.SetTexture("_DestroyTex", destroyTexture);
        bread2.GetComponent<Renderer>().material.SetTexture("_DestroyTex", destroyTexture);
        bread1.GetComponent<Renderer>().materials[1].SetTexture("_DestroyTex", destroyTexture);
        bread2.GetComponent<Renderer>().materials[1].SetTexture("_DestroyTex", destroyTexture);
    }
}
