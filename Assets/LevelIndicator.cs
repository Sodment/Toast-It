using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndicator : MonoBehaviour
{
    public static LevelIndicator instance;

    public List<Image> circles;
    public List<Animator> animators;


    public GameObject bigCircle;
    public GameObject stateCircle;
    public GameObject line;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void Reset()
    {
        foreach(Image circle in circles)
        {
            circle.color = Color.white;
        }
    }

    public void Init(int stagesAmout)
    {
        circles = new List<Image>();
        animators = new List<Animator>();
        for(int j = 0; j < transform.childCount; j++)
        {
            Destroy(transform.GetChild(j).gameObject);
        }

        GameObject bigCircleGO = Instantiate(bigCircle, transform);
        bigCircleGO.transform.GetChild(0).GetComponent<Text>().text = "1";
        Instantiate(line, transform);
        for (int i = 0; i < stagesAmout; i++)
        {
            GameObject ob = Instantiate(stateCircle, transform);
            circles.Add(ob.GetComponent<Image>());
            animators.Add(ob.transform.GetChild(0).GetComponent<Animator>());
            Instantiate(line, transform);
        }
        GameObject bigCircleGO2 = Instantiate(bigCircle, transform);
        bigCircleGO2.transform.GetChild(0).GetComponent<Text>().text = "2";
    }

    public void SetStageColor(int stage, Color color)
    {
        animators[stage].SetTrigger("bump");
        circles[stage].color = color;
    }



}
