using UnityEngine;
using UnityEngine.UI;

public class DistableVibrations : MonoBehaviour
{
    void Start()
    {
        GetComponent<Toggle>().isOn = GamerData.instance.vibrations;
    }
    public void SwitchVibrations()
    {

        GamerData.instance.vibrations = GetComponent<Toggle>().isOn;
    }
}
