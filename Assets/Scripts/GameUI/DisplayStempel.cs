using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStempel : MonoBehaviour
{
    public Image img;
    public Image leftImg;
    public Image rightImg;
    List<Sprite> images = new List<Sprite>();
    int index = 0;

    //order
    public Transform order;
    public GameObject imagePref;
    void Start()
    {
        GameManager.instance.QuittingButterChoice.AddListener(LoadLevelData);
        if (GameManager.instance.GetCurrentState() != GameStateMachine.GameState.StampleChoice)
        {
            gameObject.SetActive(false);
        }
        LoadLevelData();
    }

    private void OnEnable()
    {
        if (GameManager.instance != null)
        {
            if (GameManager.instance.GetCurrentState() != GameStateMachine.GameState.StampleChoice)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void LoadLevelData()
    {
        index = 0;
        images.Clear();
        for(int i=0; i<LevelManager.instance.currentLevel.availableStamps.Length; i++)
        {
            images.Add(Resources.Load("UI_BreadStamp/" + LevelManager.instance.currentLevel.availableStamps[i], typeof(Sprite)) as Sprite);
        }
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];

        //order
        for (int i = order.childCount - 1; i >= 0; i--)
        {
            Destroy(order.GetChild(i).gameObject);
        }
        for (int i = 0; i < LevelManager.instance.currentLevel.banedStamps.Length; i++)
        {
            GameObject GO = (GameObject)Instantiate(imagePref, order);
            GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadStamp/" + LevelManager.instance.currentLevel.banedStamps[i], typeof(Sprite)) as Sprite;
            //GO.transform.SetParent(order);
        }

        //Automatyczne przejście
        if (LevelManager.instance.currentLevel.availableStamps.Length == 1 && Summary.instance != null)
        {
            index = 0;
            string[] ans = new string[1];
            ans[0] = images[index].name;
            Summary.instance.playerAnswer.banedStamps = ans;
            GameManager.instance.SwitchToNextState();
        }
    }

    public void Next()
    {
        index = (index + 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
    }


    public void Preview()
    {
        index = (images.Count+index - 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
    }

    public void Choose(float _delay)
    {
        Invoke("LoadNormalmap", _delay);
    }

    void LoadNormalmap()
    {
        string[] ans = new string[1];
        ans[0] = images[index].name;
        Summary.instance.playerAnswer.banedStamps = ans;
        LoadBreadDataFromPlayerChoices.instance.LoadStampleNormal(images[index].name);
    }
}
