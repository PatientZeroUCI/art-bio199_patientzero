using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCRTestSlide : MonoBehaviour
{
    public GameObject swab;

    [HideInInspector]
    public bool virusLoaded = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!virusLoaded && swab != null)
        {
            // Placed an 'or' statement here checking for object name just in case the exact swab object we check can't be directly referenced
            GameObject collider = collision.gameObject;
            if ((collider == swab || collider.name == swab.gameObject.name) && collider.GetComponent<Swab>().virus.activeSelf)
            {
                Debug.Log("Virus loaded from Swab to Slide");
                virusLoaded = true;
            }
        }
    }
}
