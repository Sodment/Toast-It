using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingSound : MonoBehaviour
{
    public AudioSource soundPlayer;
    public AudioClip audioClip;

    public void PlayEatingSound()
    {
        if (soundPlayer.gameObject.activeSelf)
        { soundPlayer.PlayOneShot(audioClip, 1); }
    }
}
