using UnityEngine;
/// <summary>
/// Class loads bread data from player choices
/// </summary>
public class LoadBreadDataFromPlayerChoices : MonoBehaviour
{
    public static LoadBreadDataFromPlayerChoices instance;
    public GameObject bread1;
    public GameObject bread2;
    public ParticleSystem bread1Particle;
    public ParticleSystem bread2Particle;

    private void Start()
    {
        if (instance != null) { Destroy(instance.gameObject); }
        instance = this;
    }
    /// <summary>
    /// Method loads bread mesh from resources folder
    /// </summary>
    /// <param name="name"> String name of object in resources that we took mesh from </param>
    public void LoadBreadShape(string name, bool first=false)
    {
        Mesh data = Resources.Load("BreadShapes/" + name, typeof(Mesh)) as Mesh;
        bread1.GetComponent<MeshFilter>().mesh = data;
        bread2.GetComponent<MeshFilter>().mesh = data;
        if (!first)
        {
            bread1Particle.Play();
            bread2Particle.Play();
        }
    }
    /// <summary>
    /// Method loads bread top texture(butter) from resources folder
    /// </summary>
    /// <param name="name"> String name of object in resources that we took butter from </param>
    public void LoadTopTexture(string name)
    {
        Texture2D tex = Resources.Load("BreadTopTextures/" + name, typeof(Texture2D)) as Texture2D;
        bread1.GetComponent<Renderer>().material.SetTexture("_ButterTex", tex);
        bread2.GetComponent<Renderer>().material.SetTexture("_ButterTex", tex);
    }

    /// <summary>
    /// Method loads normal map(stample) from resources folder
    /// </summary>
    /// <param name="name"> String name of object in resources that we took normal map(stample) from </param>
    public void LoadStampleNormal(string name)
    {
        Texture2D tex = Resources.Load("BreadStampleTextures/" + name, typeof(Texture2D)) as Texture2D;
        bread1.GetComponent<Renderer>().material.SetTexture("_BumpMap", tex);
        bread2.GetComponent<Renderer>().material.SetTexture("_BumpMap", tex);
    }
}
