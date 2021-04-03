using UnityEngine;

public class Rozeta : MonoBehaviour
{
    //public List<Color> useableColors;
    //public int sections=1;
    Renderer rend;
    public TapToaster Meter;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.QuittingOrder.AddListener(LoadLevelData);
        rend = GetComponent<Renderer>();
    }

    void LoadLevelData()
    {
        Color[] useableColors = LevelManager.instance.currentLevel.paletteOfColours;
        int sections = LevelManager.instance.currentLevel.section;
        float angleRange = 330.0f;
        float sectionRange = angleRange / sections;
        float colorRange = sectionRange / useableColors.Length;
        Color[] colorOrders = new Color[100];

        for(int i=0; i<100; i++)
        {
            colorOrders[i]=useableColors[i % useableColors.Length];
        }
        Meter.colorList = colorOrders;
        Meter.colorRange = colorRange;
        rend.material.SetColorArray("_Colors", colorOrders);
        rend.material.SetFloat("_ColorRange", colorRange * Mathf.Deg2Rad);
    }
}
