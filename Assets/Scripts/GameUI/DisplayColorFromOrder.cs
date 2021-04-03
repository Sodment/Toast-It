using UnityEngine;
using UnityEngine.UI;

public class DisplayColorFromOrder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject img;
    void Start()
    {
        GameManager.instance.SwitchingToShapeChoice.AddListener(LoadLevelData);
        GameManager.instance.SwitchingToUIMainView.AddListener(LoadLevelData);
    }

    void LoadLevelData()
    {
        for(int i=transform.childCount-1; i>0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        int temporaryStagesNumber = LevelManager.instance.currentLevel.indexOfColorInOrder.Length;
        int temporaryWidth = Mathf.RoundToInt(GetComponent<RectTransform>().rect.width / temporaryStagesNumber);
        for(int i=0; i<temporaryStagesNumber; i++)
        {
            GameObject GO = (GameObject)Instantiate(img);
            GO.transform.parent = transform;
            GO.transform.localPosition = new Vector3(((float)i + 0.5f) * temporaryWidth - (temporaryWidth * temporaryStagesNumber * 0.5f), 0, 0);
            GO.GetComponent<Image>().color = LevelManager.instance.currentLevel.paletteOfColours[LevelManager.instance.currentLevel.indexOfColorInOrder[i]];
            GO.GetComponent<RectTransform>().rect.Set(0.5f, 0.5f, temporaryWidth, Mathf.RoundToInt(GetComponent<RectTransform>().rect.height));
        }
    }
}
