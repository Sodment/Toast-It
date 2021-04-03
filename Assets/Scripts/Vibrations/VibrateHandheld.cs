using UnityEngine;

public class VibrateHandheld : MonoBehaviour
{
    public bool vibateOn = true;
    private void Start()
    {
        vibateOn = GamerData.instance.vibrations;
        GameManager.instance.QuittingTapToEat.AddListener(VibrateHandheldOnEat);
    }

    public void VibrateHandheldOnEat()
    {
        if (vibateOn)
        {
            Handheld.Vibrate();
          //  Debug.Log("Phone is shaking!");
        }
    }
}
