using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundInStage : MonoBehaviour
{
    public GameStateMachine.GameState state;
    public AudioSource source;
    public float delay = 1f;
    private void Start()
    {
        switch (state)
        {
            case GameStateMachine.GameState.UIMainView:
                GameManager.instance.SwitchingToUIMainView.AddListener(PlaySound);
                GameManager.instance.QuittingUIMainView.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.Order:
                GameManager.instance.SwitchingToOrder.AddListener(PlaySound);
                GameManager.instance.QuittingOrder.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.ShapeChoice:
                GameManager.instance.SwitchingToShapeChoice.AddListener(PlaySound);
                GameManager.instance.QuittingShapeChoice.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.ToastFrying:
                GameManager.instance.SwitchingToToastFrying.AddListener(PlaySound);
                GameManager.instance.QuittingToastFrying.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.ButterChoice:
                GameManager.instance.SwitchingToButterChoice.AddListener(PlaySound);
                GameManager.instance.QuittingButterChoice.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.StampleChoice:
                GameManager.instance.SwitchingToStampleChoice.AddListener(PlaySound);
                GameManager.instance.QuittingStampleChoice.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.ToastBurned:
                GameManager.instance.SwitchingToToastBurned.AddListener(PlaySound);
                GameManager.instance.QuittingToastBurned.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.TapToEat:
                GameManager.instance.SwitchingToTapToEat.AddListener(PlaySound);
                GameManager.instance.QuittingTapToEat.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.Summary:
                GameManager.instance.SwitchingToSummary.AddListener(PlaySound);
                GameManager.instance.QuittingSummary.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.Shop:
                GameManager.instance.SwitchingToShop.AddListener(PlaySound);
                GameManager.instance.QuittingShop.AddListener(StopSound);
                break;
            case GameStateMachine.GameState.Options:
                GameManager.instance.SwitchingToOptions.AddListener(PlaySound);
                GameManager.instance.QuittingOptions.AddListener(StopSound);
                break;
        }
    }

    void PlaySound()
    {
        if (source.gameObject.activeSelf)
        { source.PlayDelayed(delay); }
    }

    void StopSound()
    {
        if (source.gameObject.activeSelf)
        { source.Stop(); }
    }   
}
