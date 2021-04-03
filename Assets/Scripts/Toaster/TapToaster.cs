using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TapToaster : MonoBehaviour
{
    public static TapToaster instance;
    public UnityEvent tapEvent;

    public Transform arrow;
    public float arrowSpeed = 60;
    public float colorRange;
    public Color[] colorList;

    float currentAngle = -302.0f;
    float maxAngle = -302.0f;
    short dir = 1;

    List<Color> playerResultInBakeStage = new List<Color>();

    bool work = false;
    int stage = 0;

    public bool correct;

    private void Awake()
    {
        if (TapToaster.instance != null) { Destroy(TapToaster.instance.gameObject); }
        instance = this;
    }

    private void Start()
    {
        GameManager.instance.SwitchingToToastFrying.AddListener(StartHeating);
        GameManager.instance.QuittingToastFrying.AddListener(StopHeating);
    }

    void Update()
    {
        if (work)
        {
            currentAngle += dir * arrowSpeed * Time.deltaTime;
            if (currentAngle >= 0.0f) { currentAngle = 0.0f; dir = -1; }
            else if (currentAngle <= maxAngle) { currentAngle = maxAngle; dir = 1; }

            Color currentColor = colorList[Mathf.FloorToInt((-currentAngle + 13.54f) / colorRange)];

            arrow.localRotation = Quaternion.Euler(currentAngle, 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                stage++;
                playerResultInBakeStage.Add(currentColor);
                if (stage == LevelManager.instance.currentLevel.indexOfColorInOrder.Length)
                {
                    GetComponent<SwitchToNextGameState>().Switch();
                }
                if (currentColor == LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[stage - 1]])
                {
                    correct = true;
                }
                else 
                { 
                    correct = false;
                }
                tapEvent.Invoke(); 
                //particle 
                //animacja 
                //zmiana koloru chlebka
            }
        }
    }

    public Color[] GetPlayerResultInBakeStage()
    {
        return playerResultInBakeStage.ToArray();
    }

    public Color GetPlayerCurrentInBakeStage()
    {
        return playerResultInBakeStage[playerResultInBakeStage.Count - 1];
    }

    public float GetBakeValue()
    {
        return (float)stage / (float)LevelManager.instance.currentLevel.indexOfColorInOrder.Length;
    }

    public void StartHeating()
    {
        stage = 0;
        playerResultInBakeStage.Clear();
        arrowSpeed = LevelManager.instance.currentLevel.arrowSpeed;
        currentAngle = -302.0f;
        dir = 1;
        work = true;
    }

    public void StopHeating()
    {
        work = false;
    }


    public float GetCurrentAngle()
    {
        return currentAngle;
    }

    public float GetTrajectoryTime()
    {
        if (dir > 0) return (302.0f + currentAngle) / arrowSpeed; 
        else return (302.0f - currentAngle) / arrowSpeed;
    }

    public int GetStage()
    {
        return stage;
    }
}