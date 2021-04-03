using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(AudioSource))]
public class SoundOnGameState : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public AudioClip clip;
    public AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(Play);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.SwitchingToOrder.AddListener(Play);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.SwitchingToShapeChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.SwitchingToToastFrying.AddListener(Play);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.QuittingButterChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.QuittingStampleChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.SwitchingToToastBurned.AddListener(Play);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.QuittingTapToEat.AddListener(Play);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.SwitchingToSummary.AddListener(Play);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.SwitchingToShop.AddListener(Play);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.SwitchingToOptions.AddListener(Play);
                break;
        }
    }

    void Play()
    {
        if (source.gameObject.activeSelf)
        { source.PlayOneShot(clip); }
    }
}
