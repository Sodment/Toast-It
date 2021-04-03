using UnityEngine;

public class FloatingTextsManager : MonoBehaviour
{
    public GameObject bonusPrefab;


    public void InstantateBonus()
    {
        Instantiate(bonusPrefab, transform);
    }
}
