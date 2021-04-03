using UnityEngine;

public class ParticleInstance : MonoBehaviour
{
    [SerializeField]
    GameObject particle=null;
    void Start()
    {
        TapToaster.instance.tapEvent.AddListener(SetParticle);
    }


    void SetParticle()
    {
        GameObject GO = (GameObject)Instantiate(particle, TapToaster.instance.transform.position, Quaternion.Euler(0,0,0));
        foreach (Renderer k in GO.GetComponentsInChildren<Renderer>())
        {
            if (TapToaster.instance.correct)
            { 
                k.material.color = TapToaster.instance.GetPlayerCurrentInBakeStage(); 
            }
            else 
            {
                Color tmp = TapToaster.instance.GetPlayerCurrentInBakeStage() * 0.25f;
                tmp.a = 1.0f;
                k.material.color = tmp;
                //k.gameObject.GetComponent<ParticleSystem>().
                ParticleSystem temp=k.gameObject.GetComponent<ParticleSystem>();
                //temp.gravityModifier = 0.5f;
                ParticleSystem.MainModule main = temp.main;
                main.gravityModifier = 0.3f;
            }
        }
        Destroy(GO, 2.0f);
    }
}
