using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ControllerRotation : MonoBehaviour
{

    public VRTK_ControllerEvents right_hand;
    public GameObject rotatableObject;

    private VRTK_InteractableObject grab_hand;
    private void Start()
    {
        grab_hand = this.gameObject.GetComponent<VRTK_InteractableObject>();
    }

    void Update()
    {
        if (grab_hand.IsGrabbed() && grab_hand.GetGrabbingObject() == rotatableObject)
        {
            //if(right_hand.)
        }
    }
}
