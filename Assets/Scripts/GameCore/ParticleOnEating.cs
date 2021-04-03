using UnityEngine;
/// <summary>
/// Class for handling particles used in state TapToEat
/// </summary>
public class ParticleOnEating : MonoBehaviour
{
    public ParticleSystem eatingParticle;
    private void Start()
    {
        GameManager.instance.QuittingTapToEat.AddListener(ParticleExplode);
    }
    /// <summary>
    /// Method to play the particles
    /// </summary>
    public void ParticleExplode()
    {
        eatingParticle.Play();
    }
}
