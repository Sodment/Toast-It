using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public Transform mapsContainer;

    void Start()
    {
        LoadMap();
        GameManager.instance.SwitchingToOrder.AddListener(LoadMap);
        GameManager.instance.SwitchingToUIMainView.AddListener(LoadMap);
        GameManager.instance.QuittingUIMainView.AddListener(LoadMap);
        GameManager.instance.QuittingSummary.AddListener(LoadMap);
    }

    public void LoadMap()
    {
        foreach (Transform child in mapsContainer)
        {
            child.gameObject.SetActive(false);
            if (child.gameObject.name == LevelManager.instance.currentLevel.map.name)
            {

                child.gameObject.SetActive(true);
            }
        }
    }

}
