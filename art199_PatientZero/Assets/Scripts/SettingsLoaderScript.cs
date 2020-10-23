using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsLoaderScript : MonoBehaviour
{
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 1f);
    }
}
