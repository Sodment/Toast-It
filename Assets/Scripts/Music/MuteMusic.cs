using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteMusic : MonoBehaviour
{
    public GameObject music;
    void Start()
    {
        GetComponent<Toggle>().isOn = GamerData.instance.music;
        ToggleMusic();
    }
    public void ToggleMusic()
    {
        if (GamerData.instance.music)
        {
            music.SetActive(true);
        }
        else
        {
            music.SetActive(false);
        }
    }

    public void ChangeStateOfMusic()
    {
        GamerData.instance.music = GetComponent<Toggle>().isOn;
    }

}
