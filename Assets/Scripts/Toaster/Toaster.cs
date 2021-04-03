using UnityEngine;

public class Toaster : MonoBehaviour
{
    [SerializeField]
    GameObject[] Breads=new GameObject[2];

    [SerializeField]
    Transform[] hoverSlots = null;
    [SerializeField]
    Transform[] bakeSlots = null;
    [SerializeField]
    Transform[] eatSlots = null;


    private void Start()
    {
        GameManager.instance.QuittingUIMainView.AddListener(Prepare);
        Prepare();
    }

    public void ForceActivePrepare()
    {
        Prepare();
    }

    void Prepare()
    {
        Breads[0] = GameObject.Find("BasicBread_1");
        Breads[1] = GameObject.Find("BasicBread_2");
        for (int i = 0; i < 2; i++)
        {
            Breads[i].GetComponent<BreadMovement>().eatSlot = eatSlots[i];
            Breads[i].GetComponent<BreadMovement>().bakeSlot = bakeSlots[i];
            Breads[i].GetComponent<BreadMovement>().hoverSlot = hoverSlots[i];
        }
    }

}
