using UnityEngine;

public class CameraShakerOnStamp : MonoBehaviour
{
    public Cinemachine.CinemachineImpulseSource source;
    private void OnEnable()
    {
        source.GenerateImpulse();
    }
}
