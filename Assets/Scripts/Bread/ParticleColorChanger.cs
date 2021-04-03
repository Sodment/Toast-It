using UnityEngine;

public class ParticleColorChanger : MonoBehaviour
{
    [SerializeField] GameObject particle=null;
    void OnEnable()
    {
        GameObject GO = (GameObject)Instantiate(particle);
        GO.transform.position = transform.position - Vector3.left * -0.3f;
        Texture2D tex = GameObject.FindObjectOfType<BreadController>().gameObject.GetComponent<Renderer>().material.GetTexture("_ButterTex") as Texture2D;
        if (tex == null) { return; }
        GO.GetComponent<Renderer>().material.SetTexture("_MainTex", tex);
        Destroy(GO, 1.0f);
    }
}
