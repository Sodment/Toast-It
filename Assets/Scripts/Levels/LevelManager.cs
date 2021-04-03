using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Level[] levels;
    public Level currentLevel;

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

    void Start()
    {
        GameManager.instance.SwitchingToOrder.AddListener(LoadLevel);
        GameManager.instance.SwitchingToSummary.AddListener(LoadLevel);
        GameManager.instance.SwitchingToUIMainView.AddListener(LoadLevel);
        LoadLevel();
    }

    public void LoadLevel()
    {
        int level = (int)GamerData.instance.currentlvl % levels.Length;
        currentLevel = levels[level];
        if(GamerData.instance.currentlvl > 15)
        {
            LevelGenerator.instance.GenerateLevel();
            currentLevel = levels[15];
            Debug.Log("Level set to X");
        }
    }
}
