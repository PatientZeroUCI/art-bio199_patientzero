using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Events : MonoBehaviour
{
    public static Level1Events current;

    void Awake()
    {
        current = this;
    }


    //  When AI voice finishes reading intro lines
    public event Action onIntroDone;
    public void IntroDone()
    {
        if (onIntroDone != null)
        {
            onIntroDone();
        }
    }
}
