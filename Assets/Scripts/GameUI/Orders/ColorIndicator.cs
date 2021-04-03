using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorIndicator : MonoBehaviour
{
    [SerializeField]
    GameObject ColorField=null;
    [SerializeField]
    Sprite normalColorField = null;
    [SerializeField]
    Sprite normalColorFieldFrame = null;
    [SerializeField]
    Sprite currentColorField = null;
    [SerializeField]
    Sprite currentColorFieldFrame = null;

    TapToaster lastInstance;

    List<Color> colors = new List<Color>();
    int current = 0;
    void Start()
    {
        GameManager.instance.SwitchingToToastFrying.AddListener(LoadData);
        GameManager.instance.QuittingShop.AddListener(SetTapToaster);
        TapToaster.instance.tapEvent.AddListener(SwitchToNextColor);
        lastInstance = TapToaster.instance;
        LoadData();
    }

    void SetTapToaster()
    {
        if (lastInstance != TapToaster.instance)
        { 
            TapToaster.instance.tapEvent.AddListener(SwitchToNextColor);
            lastInstance = TapToaster.instance;
        }
    }
    void LoadData()
    {
        colors.Clear();
        int count = LevelManager.instance.currentLevel.indexOfColorInOrder.Length;
        for(int i = transform.childCount-1; i>=0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < count; i++)
        {
            colors.Add(LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[i]]);
            GameObject GO = (GameObject)Instantiate(ColorField, transform);
            //GO.transform.SetParent(transform);
            //GO.transform.parent = transform;
            GO.GetComponent<Image>().color = colors[i];
            transform.GetChild(current+i).GetComponent<RectTransform>().sizeDelta -= new Vector2(200/count, 0);
        }
        transform.GetChild(current).GetComponent<RectTransform>().sizeDelta += new Vector2(200, 0);
        transform.GetChild(current).GetComponent<Image>().sprite = currentColorField;
        transform.GetChild(current).GetChild(0).GetComponent<Image>().sprite = currentColorFieldFrame;
        transform.GetChild(current).GetChild(0).GetComponent<Image>().color = Color.yellow;
        current = 0;
    }

    void SwitchToNextColor()
    {
        //Jeszcze tylko ogarnąć zgodność z zamówieniem
        if(TapToaster.instance.GetPlayerCurrentInBakeStage()==colors[current])
        {
            transform.GetChild(current).GetChild(0).GetComponent<Image>().color = Color.green;
            transform.GetChild(current).GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(current).GetChild(0).GetComponent<Image>().color = Color.red;
            transform.GetChild(current).GetChild(2).gameObject.SetActive(true);
        }
        transform.GetChild(current).GetComponent<Image>().sprite = normalColorField;
        transform.GetChild(current).GetChild(0).GetComponent<Image>().sprite = normalColorFieldFrame;
        transform.GetChild(current).GetComponent<RectTransform>().sizeDelta -= new Vector2(200, 0);


        current++;
        if (current >= transform.childCount) { return; }

        transform.GetChild(current).GetComponent<RectTransform>().sizeDelta += new Vector2(200, 0);
        transform.GetChild(current).GetComponent<Image>().sprite = currentColorField;
        transform.GetChild(current).GetChild(0).GetComponent<Image>().sprite = currentColorFieldFrame;
        transform.GetChild(current).GetChild(0).GetComponent<Image>().color = Color.yellow;
    }
}
