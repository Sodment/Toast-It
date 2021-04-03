using System.Collections.Generic;
using UnityEngine;

public class Summary : MonoBehaviour
{
    public Level playerAnswer;
    public static Summary instance;
    void Start()
    {
        if (instance != null) { Destroy(instance); }
        instance = this;
        GameManager.instance.SwitchingToSummary.AddListener(TotalSummary);
    }


    void TotalSummary()
    {
        int scoreFromShapeChoice = ScoreFromShapeChoice() * 200;
        int scoreFromBakeStage = Mathf.RoundToInt(ScoreFromBakeStage() * 400);
        int scoreFromTopping = ScoreFromTopping() * 200;
        int scoreFromStample = ScoreFromStample() * 200;

        int summary = scoreFromShapeChoice + scoreFromBakeStage + scoreFromTopping + scoreFromStample;
        Debug.Log("Shape: "+ scoreFromShapeChoice+" Colors: "+ scoreFromBakeStage+" Jam: "+ scoreFromTopping+" Stamp: "+ scoreFromStample);
        PointsHolder.instance.points += (ulong)summary;
        CurrencyManager.instance.GetCurrency((ulong)Mathf.CeilToInt(PointsHolder.instance.points * 0.02f));
        GamerData.instance.currentlvl++;
    }

    int ScoreFromShapeChoice()
    {
        List<string> temporaryBanedShapes = new List<string>();
        temporaryBanedShapes.AddRange(LevelManager.instance.currentLevel.banedShapes);
        if (temporaryBanedShapes.Contains(playerAnswer.banedShapes[0])) return 1;
        else return 0;
    }

    float ScoreFromBakeStage()
    {
        int temporaryScore = 0;
        playerAnswer.paletteOfColours = TapToaster.instance.GetPlayerResultInBakeStage();
        for(int i=0; i< LevelManager.instance.currentLevel.indexOfColorInOrder.Length; i++)
        {
            if (LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[i]] == playerAnswer.paletteOfColours[i])
            {
                temporaryScore++;
            }
        }
        return (float)temporaryScore / (float)LevelManager.instance.currentLevel.indexOfColorInOrder.Length;
    }

    int ScoreFromTopping()
    {
        List<string> temporaryBanedTopping = new List<string>();
        temporaryBanedTopping.AddRange(LevelManager.instance.currentLevel.banedJams);
        if (temporaryBanedTopping.Contains(playerAnswer.banedJams[0])) return 1;
        else return 0;
    }

    int ScoreFromStample()
    {
        List<string> temporaryBanedStample = new List<string>();
        temporaryBanedStample.AddRange(LevelManager.instance.currentLevel.banedStamps);
        if (temporaryBanedStample.Contains(playerAnswer.banedStamps[0])) return 1;
        else return 0;
    }
}
