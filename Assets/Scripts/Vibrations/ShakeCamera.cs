using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public Cinemachine.CinemachineImpulseSource source;
    private void Start()
    {
        GameManager.instance.QuittingTapToEat.AddListener(VibrateCameraOnEat);
        GameManager.instance.QuittingToastBurned.AddListener(VibrateCameraOnEat);
    }

    public void VibrateCameraOnEat()
    {
        source.GenerateImpulse();
       // Debug.Log("Camera is shaking!");
    }
}
