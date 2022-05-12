using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : MonoBehaviour
{
    public flashlightAudio audioScript;

    public GameObject light;
    public GameObject egg; //need to do collision detection in trigger to change material of egg. 

    public Material inFlashlight;
    public Material outFlashlight;

    public VRTK_InteractableObject linkedObject;
    public VRTK_InteractUse controllerUse;
    
    protected virtual void OnEnable()
    {
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        }
    }

    protected virtual void OnDisable()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        UseFlashlight();
    }

    public void UseFlashlight()
    {
        audioScript.flashlightToggleSFX();

    	if(light.activeSelf == false)
		{
			light.SetActive(true);
		}
		else if(light.activeSelf == true)
		{
			light.SetActive(false);
		}

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Egg>() != null)
        {
            egg.gameObject.GetComponent<Renderer>().material = inFlashlight;
        }
        if (other.gameObject.activeSelf == false)
        {
            egg.gameObject.GetComponent<Renderer>().material = outFlashlight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Egg>() != null)
        {
            egg.gameObject.GetComponent<Renderer>().material = outFlashlight;

        }
    }
}
