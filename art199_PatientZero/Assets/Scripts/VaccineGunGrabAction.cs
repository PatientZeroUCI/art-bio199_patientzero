using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.SecondaryControllerGrabActions;

public class VaccineGunGrabAction : VRTK_BaseGrabAction
{
    public override void Initialise(VRTK_InteractableObject currentGrabbdObject, VRTK_InteractGrab a, VRTK_InteractGrab b, Transform c, Transform d)
    {
        currentGrabbdObject.GetComponent<VaccineGunShoot>().NextVaccine();
        base.Initialise(currentGrabbdObject, a, b, c, d);
    }

    public override void ProcessUpdate()
    {
        grabbedObject.ForceStopSecondaryGrabInteraction();
    }
}
