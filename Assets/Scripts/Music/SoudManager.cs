using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudManager : MonoBehaviour
{
    public GameObject sound;
    public GameObject music;

    void Start()
    {
        if (GamerData.instance.soundtrack)
        {
            sound.SetActive(true);
        }
        else
        {
            sound.SetActive(false);
        }
        if (GamerData.instance.music)
        {
            music.SetActive(true);
        }
        else
        {
            music.SetActive(false);
        }
    }
}
