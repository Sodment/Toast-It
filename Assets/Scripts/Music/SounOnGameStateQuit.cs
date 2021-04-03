using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounOnGameStateQuit : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public AudioClip clip;
    public AudioSource source;
    void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.QuittingUIMainView.AddListener(Play);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.QuittingOrder.AddListener(Play);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.QuittingShapeChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.QuittingToastFrying.AddListener(Play);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.QuittingButterChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.QuittingStampleChoice.AddListener(Play);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.QuittingToastBurned.AddListener(Play);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.QuittingTapToEat.AddListener(Play);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.QuittingSummary.AddListener(Play);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.QuittingShop.AddListener(Play);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.QuittingOptions.AddListener(Play);
                break;
        }
    }

    void Play()
    {
        if (source.gameObject.activeSelf)
        { source.PlayOneShot(clip); }
    }
}
