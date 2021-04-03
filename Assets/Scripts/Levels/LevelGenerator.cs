using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    public Level levelX;
    private string[] shapeModels = new string[4] {"Chlebek_1", "Chlebek_2", "Chlebek_3", "Chlebek_4"};
    private string[] jamsTexture = new string[6] { "butter_flare_FlipX", "peanut_butter", "apple_jam", "honey", "apricot_jam", "strawberry_jam"} ;
    private string[] stampNormalMaps = new string[4] { "stepel_love", "stepel_mis", "stepel_serce", "stepel_slime" };
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }

    public GameObject MapGenerator()
    {
        Object[] mapPool = Resources.LoadAll("Maps");
        GameObject randomMap = (GameObject)mapPool[Random.Range(0, mapPool.Length)];
        return randomMap;
    }

    public int[] ColorOrderGenerator()
    {
        int[] tmp = new int[5];
        for (int i = 0; i < 5; i++)
        {
            tmp[i] = Random.Range(0, 4);
            while (i >= 1 && tmp[i - 1] == tmp[i])
            {
                tmp[i] = Random.Range(0, 4);
            }
        }
        Debug.Log(tmp);
        return tmp;
    }

    public string[] BannedShapeSetter()
    {
        string bannedShape = shapeModels[Random.Range(0, shapeModels.Length)];
        string[] returnShape = new string[1] { bannedShape };
        return returnShape;
    }

    public string[] BannedJamSetter()
    {
        string bannedJam = jamsTexture[Random.Range(0, jamsTexture.Length)];
        string[] returnJam = new string[1] { bannedJam };
        return returnJam;
    }

    public string[] BannedStampSetter()
    {
        string bannedStamp = stampNormalMaps[Random.Range(0, stampNormalMaps.Length)];
        string[] returnStamp = new string[1] { bannedStamp };
        return returnStamp;
    }

    public void GenerateLevel()
    {
        levelX.arrowSpeed = 80;
        levelX.map = MapGenerator();
        levelX.paletteOfColours = LevelManager.instance.levels[14].paletteOfColours;
        levelX.section = (int)Random.Range(3, 6);
        levelX.indexOfColorInOrder = ColorOrderGenerator();
        levelX.banedJams = BannedJamSetter();
        levelX.banedShapes = BannedShapeSetter();
        levelX.banedStamps = BannedStampSetter();
        levelX.availableJams = jamsTexture;
        levelX.availableShapes = shapeModels;
        levelX.availableStamps = stampNormalMaps;
        levelX.bonus = true;
        levelX.bonusSpeedMiltipler = 2;
        levelX.bonusRange = Random.Range(20, 25);
        levelX.difficulty = Random.Range(0, 0.25f);
    }
}
