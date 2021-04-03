using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnTap : MonoBehaviour
{
    private AudioSource source;

    public AudioClip goodTap;
    public AudioClip badTap;

    public void PlayGoodTap()
    {
        if (GameObject.Find("SoundEffects") != null)
        {
            if (GameObject.Find("SoundEffects").TryGetComponent<AudioSource>(out source))
            {
                source = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
                source.PlayOneShot(goodTap, 1f);
            }
        }
    }

    public void PlayBadTap()
    {
        if (GameObject.Find("SoundEffects") != null)
        {
            if (GameObject.Find("SoundEffects").TryGetComponent<AudioSource>(out source))
            {
                source = GameObject.Find("SoundEffects").GetComponent<AudioSource>();
                source.PlayOneShot(badTap, 1f);
            }
        }
    }
}
