using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvents : MonoBehaviour
{
    public static TestEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action onEnableBox;
    public void enableBox()
    {
        if (onEnableBox != null)
        {
            onEnableBox();
        }
    }
}
