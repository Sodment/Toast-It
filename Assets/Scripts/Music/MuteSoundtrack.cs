using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSoundtrack : MonoBehaviour
{
    public GameObject soundtrack;

    void Start()
    {
        GetComponent<Toggle>().isOn = GamerData.instance.soundtrack;
        ToggleSoundtrack();
    }
    public void ToggleSoundtrack()
    {
        if (GamerData.instance.soundtrack)
        {
            soundtrack.SetActive(true);
        }
        else
        {
            soundtrack.SetActive(false);
        }
    }

    public void ChangeStateOfSoundtrack()
    {
        GamerData.instance.soundtrack = GetComponent<Toggle>().isOn;
    }
}
