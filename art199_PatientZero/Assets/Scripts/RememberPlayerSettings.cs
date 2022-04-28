using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberPlayerSettings : MonoBehaviour
{
    public static RememberPlayerSettings Instance;

    public float scale = -777;
    public float headHeight = -777f;
    public float leftHeight = -777f;
    public float rightHeight = -777f;


    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
