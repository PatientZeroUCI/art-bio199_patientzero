using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : MonoBehaviour
{
    public GameObject light;
    public double timeStamp;

    public VRTK_InteractableObject flashlight;
    public VRTK_InteractUse controllerUse;

    void Start() {
    	timeStamp = Time.time + 2.5;
        controllerUse = GameObject.Find("RightHand/Right").GetComponent<VRTK_InteractUse>();
    }

    void Update()
    {
    	if (timeStamp <= Time.time){
	        if (flashlight.IsGrabbed() && controllerUse.IsUseButtonPressed())
	        {
	            UseFlashlight();
	            timeStamp = Time.time + 1;
	        }
    	}
    }

    public void UseFlashlight()
    {
    	if(light.activeSelf == false)
		{
			light.SetActive(true);
		}
		else{
			light.SetActive(false);
		}
    }
}
