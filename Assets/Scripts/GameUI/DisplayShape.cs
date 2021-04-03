using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayShape : MonoBehaviour
{
    public Image img;
    public Image leftImg;
    public Image rightImg;
    List<Sprite> images = new List<Sprite>();
    int index = 0;

    //order
    public Transform order;
    public GameObject imagePref;

    public Animator animator;
    void Start()
    {
        GameManager.instance.QuittingOrder.AddListener(LoadLevelData);
        gameObject.SetActive(false);
    }

    void LoadLevelData()
    {
        index = 0;
        images.Clear();

        for (int i = 0; i < LevelManager.instance.currentLevel.availableShapes.Length; i++)
        {
            images.Add(Resources.Load("UI_BreadShapes/" + LevelManager.instance.currentLevel.availableShapes[i], typeof(Sprite)) as Sprite);
        }
        img.sprite = images[index]; 
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
        LoadBreadDataFromPlayerChoices.instance.LoadBreadShape(images[0].name,true);

        //order
        for(int i=order.childCount-1; i>=0; i--)
        {
            Destroy(order.GetChild(i).gameObject);
        }
        for (int i = 0; i < LevelManager.instance.currentLevel.banedShapes.Length; i++)
        {
            GameObject GO = (GameObject)Instantiate(imagePref, order);
            GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadShapes/" + LevelManager.instance.currentLevel.banedShapes[i], typeof(Sprite)) as Sprite;
            //GO.transform.SetParent(order);
        }

        //Automatyczne przejśćie gdy nie ma wyboru
        if (LevelManager.instance.currentLevel.availableShapes.Length == 1)
        {
            index = 0;
            Choose();
            GameManager.instance.SwitchToNextState();
        }
        animator.SetTrigger("show");
    }

    public void Next()
    {
        index = (index + 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
        LoadBreadDataFromPlayerChoices.instance.LoadBreadShape(images[index].name);
    }


    public void Preview()
    {
        index = (images.Count + index - 1) % images.Count;
        img.sprite = images[index];
        leftImg.sprite = images[(images.Count + index - 1) % images.Count];
        rightImg.sprite = images[(index + 1) % images.Count];
        LoadBreadDataFromPlayerChoices.instance.LoadBreadShape(images[index].name);
    }

    public void Choose()
    {
        string[] ans = new string[1];
        ans[0] = images[index].name;
        Summary.instance.playerAnswer.banedShapes = ans;
        //Debug.Log(images[index].name);
    }
}
