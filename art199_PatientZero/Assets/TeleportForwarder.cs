using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportForwarder : MonoBehaviour
{
    public GameObject targetPosition;

    public void DoTeleport()
    {
        Transform sdkTransform = VRTK.VRTK_SDKManager.GetLoadedSDKSetup().transform;

        //Debug.Log(targetPosition.transform.position + (this.transform.position - sdkTransform.position));

        //GetComponent<VRTK.VRTK_HeightAdjustTeleport>().Teleport(
        //    //targetPosition.transform,
        //    sdkTransform,
        //    targetPosition.transform.position
        //);

        GetComponent<VRTK.VRTK_BasicTeleport>().Teleport(
            sdkTransform,
            targetPosition.transform.position
        );

        // i'm just going to set the y coord manually.
        // yes this is bad
        sdkTransform.position -= sdkTransform.position.y * Vector3.up; // add new y component.
        sdkTransform.position += targetPosition.transform.position.y * Vector3.up; // add new y component.
        Debug.Log(targetPosition.transform.position.y);
    }
}
