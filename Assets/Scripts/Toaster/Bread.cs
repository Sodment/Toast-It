using UnityEngine;

public class Bread : MonoBehaviour
{
    [SerializeField] MeshFilter mesh=null;

    private void Start()
    {
        TapToaster.instance.tapEvent.AddListener(Bake);
        GameManager.instance.QuittingSummary.AddListener(Reset);
        GameManager.instance.SwitchingToOrder.AddListener(Reset);
        GameManager.instance.SwitchingToToastFrying.AddListener(Reset);
    }
    public void Reset()
    {
        TapToaster.instance.tapEvent.AddListener(Bake);
        mesh.gameObject.GetComponent<Renderer>().material.SetFloat("_Fill", 0);
        mesh.gameObject.GetComponent<Renderer>().material.SetFloat("_Progress", 0);
        mesh.gameObject.GetComponent<Renderer>().material.SetTexture("_BumpMap", null);
    }

    public void Bake()
    {
        //Debug.Log("DARKER!");
        mesh.gameObject.GetComponent<Renderer>().material.SetFloat("_Progress", TapToaster.instance.GetBakeValue());
    }
}
