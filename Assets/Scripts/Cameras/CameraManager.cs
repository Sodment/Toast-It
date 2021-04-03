using UnityEngine;
/// <summary>
/// Class for controlling cameras in-game
/// </summary>
public class CameraManager : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera[] cameras;
    void Start()
    {
        ResetCameraPriority();
        SwitchToCamera1();
        GameManager.instance.SwitchingToUIMainView.AddListener(SwitchToCamera1);
        GameManager.instance.SwitchingToShapeChoice.AddListener(SwitchToCamera2);
        GameManager.instance.SwitchingToToastFrying.AddListener(SwitchToCamera3);
        GameManager.instance.SwitchingToButterChoice.AddListener(SwitchToCamera4);
        GameManager.instance.SwitchingToStampleChoice.AddListener(SwitchToCamera5);
        GameManager.instance.SwitchingToTapToEat.AddListener(SwitchToCamera6);
        GameManager.instance.QuittingSummary.AddListener(SwitchToCamera1);
    }
    /// <summary>
    /// Every method here picks a camera from the list and sets its priority to 5 to make change active camera in-game
    /// </summary>


    //Camera - UIMainView
    public void SwitchToCamera1()
    {
        ResetCameraPriority();
        cameras[0].Priority = 5;
        //Debug.Log("Active camera" + cameras[0].name);
    }

    //Camera - ShapeChoice
    public void SwitchToCamera2()
    {
        ResetCameraPriority();
        cameras[1].Priority = 5;
        //Debug.Log("Active camera" + cameras[1].name);
    }

    //Camera - ToastFrying
    public void SwitchToCamera3()
    {
        ResetCameraPriority();
        cameras[2].Priority = 5;
        //Debug.Log("Active camera" + cameras[2].name);
    }

    //Camera - ButterChoice
    public void SwitchToCamera4()
    {
        ResetCameraPriority();
        cameras[3].Priority = 5;
        //Debug.Log("Active camera" + cameras[3].name);
    }

    //Camera - StampleChoice
    public void SwitchToCamera5()
    {
        ResetCameraPriority();
        cameras[4].Priority = 5;
        //Debug.Log("Active camera" + cameras[4].name);
    }

    //Camera - BackupCamera1
    public void SwitchToCamera6()
    {
        ResetCameraPriority();
        cameras[5].Priority = 5;
        //Debug.Log("Active camera" + cameras[5].name);
    }

    //Camera - BackupCamera2
    public void SwitchToCamera7()
    {
        ResetCameraPriority();
        cameras[6].Priority = 5;
        //Debug.Log("Active camera" + cameras[6].name);
    }
    /// <summary>
    /// Method resets every camera priority to 1
    /// </summary>
    public void ResetCameraPriority()
    {
        foreach (Cinemachine.CinemachineVirtualCamera x in cameras)
        {
            x.Priority = 1;
        }
    }


}
