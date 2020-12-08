using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSlide : MonoBehaviour
{
    public bool virusOn = false;

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collider triggered.");
        Swab swabScript = col.GetComponent<Swab>();
        if (swabScript != null && swabScript.virus.activeSelf)
        {
            virusOn = true;
            Debug.Log("Virus has been placed on the slide");
        }
    }
}
