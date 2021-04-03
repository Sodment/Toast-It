using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTopTexture : MonoBehaviour
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
        GameManager.instance.QuittingToastFrying.AddListener(LoadLevelData);
        gameObject.SetActive(false);
    }

    void LoadLevelData()
    {
        index = 0;
        images.Clear();
        for (int i = 0; i < LevelManager.instance.currentLevel.availableJams.Length; i++)
        {
            images.Add(Resources.Load("UI_BreadJams/" + LevelManager.instance.currentLevel.availableJams[i], typeof(Sprite)) as Sprite);
        }
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];

        //order
        for (int i = order.childCount - 1; i >= 0; i--)
        {
            Destroy(order.GetChild(i).gameObject);
        }
        for (int i = 0; i < LevelManager.instance.currentLevel.banedJams.Length; i++)
        {
            GameObject GO = (GameObject)Instantiate(imagePref, order);
            GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadJams/" + LevelManager.instance.currentLevel.banedJams[i], typeof(Sprite)) as Sprite;
            //GO.transform.SetParent(order);
        }

        //Automatyczne przejśćie gdy nie ma wyboru
        if (LevelManager.instance.currentLevel.availableJams.Length == 1)
        {
            index = 0;
            Choose();
            foreach(BreadController k in GameObject.FindObjectsOfType<BreadController>())
            {
                k.FinalPrepare();
            }
            GameManager.instance.SwitchToNextState();
        }
    }

    public void Next()
    {
        index = (index + 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
        LoadBreadDataFromPlayerChoices.instance.LoadTopTexture(images[index].name);
    }


    public void Preview()
    {
        index = (images.Count + index - 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
        LoadBreadDataFromPlayerChoices.instance.LoadTopTexture(images[index].name);
    }

    public void Choose()
    {
        string[] ans = new string[1];
        ans[0] = images[index].name;
        Summary.instance.playerAnswer.banedJams = ans;
        LoadBreadDataFromPlayerChoices.instance.LoadTopTexture(images[index].name);
    }
}
