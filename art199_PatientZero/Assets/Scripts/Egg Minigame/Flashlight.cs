using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Flashlight : MonoBehaviour
{
    public GameObject light;

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
    	if(light.activeSelf == false)
		{
			light.SetActive(true);
		}
		else if(light.activeSelf == true)
		{
			light.SetActive(false);
		}

    }
}
