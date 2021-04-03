using UnityEngine;
using UnityEngine.UI;

public class LoadOrderData : MonoBehaviour
{
    [SerializeField]
    Text orderNumber=null;
    [SerializeField]
    Transform orderContent=null;

    //For instance
    [SerializeField]
    GameObject taskBlock=null;
    [SerializeField]
    GameObject colorBlockPrefab=null;
    [SerializeField]
    GameObject standardImg=null;

    void Start()
    {
        GameManager.instance.SwitchingToOrder.AddListener(LoadData);
        LoadData();
    }

    void LoadData()
    {
        ClearOrder();
        orderNumber.text = "^order";
        orderNumber.gameObject.AddComponent<Honeti.I18NText>();
        orderNumber.text += "#"+(GamerData.instance.currentlvl + 1).ToString();
        
        //Shapes
        if (LevelManager.instance.currentLevel.availableShapes.Length > 1)
        {
            GameObject block = (GameObject)Instantiate(taskBlock, orderContent);
            Transform banedShapesField = block.transform.GetChild(1);
            block.transform.GetChild(0).GetComponent<Text>().text = "^shapes"; 
            block.transform.GetChild(0).gameObject.AddComponent<Honeti.I18NText>();
            foreach (string k in LevelManager.instance.currentLevel.banedShapes)
            {
                GameObject GO = (GameObject)Instantiate(standardImg, banedShapesField);
                GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadShapes/" + k, typeof(Sprite)) as Sprite;
            }
        }

        //Color order
        GameObject tmp = (GameObject)Instantiate(taskBlock, orderContent);
        Transform colorOrder = tmp.transform.GetChild(1);
        tmp.transform.GetChild(0).GetComponent<Text>().text = "^colors";
        tmp.transform.GetChild(0).gameObject.AddComponent<Honeti.I18NText>();
        for (int i = 0; i < LevelManager.instance.currentLevel.indexOfColorInOrder.Length; i++)
        {
            GameObject GO = (GameObject)Instantiate(colorBlockPrefab, colorOrder);
            GO.GetComponent<Image>().color = LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[i]];
        }

        //Jams
        if (LevelManager.instance.currentLevel.availableJams.Length > 1)
        {
            GameObject block = (GameObject)Instantiate(taskBlock, orderContent);
            Transform banedJamsField = block.transform.GetChild(1);
            block.transform.GetChild(0).GetComponent<Text>().text = "^jams";
            block.transform.GetChild(0).gameObject.AddComponent<Honeti.I18NText>();
            foreach (string k in LevelManager.instance.currentLevel.banedJams)
            {
                GameObject GO = (GameObject)Instantiate(standardImg, banedJamsField);
                GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadJams/" + k, typeof(Sprite)) as Sprite;
            }
        }

        //Stamps
        if (LevelManager.instance.currentLevel.availableStamps.Length > 1)
        {
            GameObject block = (GameObject)Instantiate(taskBlock, orderContent);
            Transform banedStampsField = block.transform.GetChild(1);
            block.transform.GetChild(0).GetComponent<Text>().text = "^stamps";
            block.transform.GetChild(0).gameObject.AddComponent<Honeti.I18NText>();
            foreach (string k in LevelManager.instance.currentLevel.banedStamps)
            {
                GameObject GO = (GameObject)Instantiate(standardImg, banedStampsField);
                GO.GetComponent<Image>().sprite = Resources.Load("UI_BreadStamp/" + k, typeof(Sprite)) as Sprite;
            }
        }
    }
    void ClearOrder()
    {
        for(int i=orderContent.childCount-1; i>=0; i--)
        {
            Destroy(orderContent.GetChild(i).gameObject);
        }
        Destroy(orderNumber.GetComponent<Honeti.I18NText>());
    }
}
