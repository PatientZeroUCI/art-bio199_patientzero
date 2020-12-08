using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerSnapTurn : MonoBehaviour
{
    private VRTK_ControllerEvents controllerEvents;

    //private bool wasClickedThisTouch;

    private void OnEnable()
    {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        
        // remove duplicate subscription if already there?
        controllerEvents.TouchpadPressed -= DoSnapTurn;
        controllerEvents.TouchpadPressed += DoSnapTurn;

        //controllerEvents.TouchpadTouchEnd += CheckSnap;
        //controllerEvents.TouchpadPressed += DisallowSnap;
    }

    //private void DisallowSnap(object sender, ControllerInteractionEventArgs e)
    //{
    //    wasClickedThisTouch = true;
    //}

    //private void CheckSnap(object sender, ControllerInteractionEventArgs e)
    //{
    //    if (!wasClickedThisTouch)
    //    {
    //        DoSnapTurn(sender, e);
    //    }
    //    wasClickedThisTouch = false;
    //}

    private void DoSnapTurn(object sender, ControllerInteractionEventArgs e)
    {
        VRTK_SDKSetup setup = VRTK_SDKManager.GetLoadedSDKSetup();
        GameObject setupObject = setup.gameObject;
        GameObject headsetObject = setup.actualHeadset;
        
        //Debug.Log(setupObject.name);
        //Debug.Log(headsetObject.name);
        //Debug.Log("Touchpad Axis: " + e.touchpadAngle);

        // Rotate the setup, then move the whole setup so the head stays in the same place.
        Vector3 offset = headsetObject.transform.position;

        setupObject.transform.rotation *= Quaternion.Euler(0, 30 * (e.touchpadAxis.x < 0 ? -1 : 1), 0);

        offset -= headsetObject.transform.position;
        setup.transform.position += offset;
    }
}