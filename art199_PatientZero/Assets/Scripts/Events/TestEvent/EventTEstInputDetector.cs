using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTEstInputDetector : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            TestEvents.current.enableBox();
        }
    }
}
