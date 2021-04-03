using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
[Serializable]
public class Level : ScriptableObject
{
    public float arrowSpeed;
    public GameObject map;
    public Color[] paletteOfColours;
    public int section;
    public int[] indexOfColorInOrder;

    public string[] banedJams;
    public string[] banedShapes;
    public string[] banedStamps;

    public string[] availableJams;
    public string[] availableShapes;
    public string[] availableStamps;

    public bool bonus;
    [Range(2,10)]
    public int bonusSpeedMiltipler;
    [Range(0.0f,60.0f)]
    public float bonusRange;
    [Range(0.0f, 0.5f)]
    public float difficulty;
}
