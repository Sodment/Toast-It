using System;
using System.Collections.Generic;
using UnityEngine;
public class GamerData : MonoBehaviour
{
    [NonSerialized]
    public static GamerData instance;
    public ulong currentlvl = 0;
    public ulong butters;
    public bool music;
    public bool soundtrack;
    public bool vibrations;
    public String selectedToaster = "BasicToaster";
    public List<String> unlockedToasters;
    public int selectedLanguage;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }
}