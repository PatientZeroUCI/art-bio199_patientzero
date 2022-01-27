using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTestCube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestEvents.current.onEnableBox += SayBacon;
    }

    private void OnDestroy()
    {
        TestEvents.current.onEnableBox -= SayBacon;
    }

    private void SayBacon()
    {
        Debug.Log("Bacon");
    }
}
