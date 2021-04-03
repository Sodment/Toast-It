using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGameMenager : MonoBehaviour
{
    public static SaveGameMenager instance;
    public GamerData gamerData;

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
        LoadGame();
    }

    void Start()
    {
        GameManager.instance.QuittingOptions.AddListener(SaveGame);
        GameManager.instance.QuittingToastBurned.AddListener(SaveGame);
       // GameManager.instance.QuittingTapToEat.AddListener(SaveGame);
       // GameManager.instance.QuittingToastFrying.AddListener(SaveGame);
        GameManager.instance.QuittingShop.AddListener(SaveGame);

        //Dodane
        GameManager.instance.QuittingSummary.AddListener(SaveGame);
    }

    public bool IsSaveFile()
    {
        return Directory.Exists(Application.persistentDataPath + "/save_game");
    }

    public void SaveGame()
    {
        if (!IsSaveFile())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save_game/gamerdata.json");
        string json = JsonUtility.ToJson(gamerData);
        //json = Encryption.Encrypt(json);
        binaryFormatter.Serialize(file, json);
        file.Close();
    }

    public void LoadGame()
    {
        if (Directory.Exists(Application.persistentDataPath + "/save_game"));
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/save_game");
        }
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/save_game/gamerdata.json"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/save_game/gamerdata.json", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)binaryFormatter.Deserialize(file), gamerData);
        }
    }
}
