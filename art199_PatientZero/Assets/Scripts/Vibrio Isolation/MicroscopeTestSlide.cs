using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class MicroscopeTestSlide : MonoBehaviour
{
    public VRTK_SnapDropZone snapZone;
    public TeleportForwarder teleportScript;

    public void sendToHologramRoom()
    {
        Debug.Log("Checking for virusOn");
        TestSlide testSlideScript = snapZone.GetCurrentSnappedObject().GetComponentInChildren<TestSlide>();
        Debug.Log("TestSlide found: " + (testSlideScript != null));
        if (testSlideScript != null && testSlideScript.virusOn)
        {
            Debug.Log("Send to Hologram Room");
            teleportScript.DoTeleport();
        }
    }
}