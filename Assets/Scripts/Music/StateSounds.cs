using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSounds : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;


    public void PlayStateSound()
    {
        if (GameObject.Find("SoundEffects") != null)
        {
            if (GameObject.Find("SoundEffects").TryGetComponent<AudioSource>(out source))
            { 
                source = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
                source.PlayOneShot(clip, 1f);
            }
        }
    }

}
