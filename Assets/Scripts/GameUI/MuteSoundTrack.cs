using UnityEngine;

public class MuteSoundTrack : MonoBehaviour
{
    // public AudioSource soundtrack;
    public GameObject sound;

    public void ChangeState(bool state)
    {
        if(state)
        {
            // soundtrack.volume = 1;
            sound.SetActive(true);
        }
        else
        {
            // soundtrack.volume = 0;
            sound.SetActive(false);
        }
    }
}
