using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayerSnapTurnScript : MonoBehaviour
{
    private VRTK_ControllerEvents controllerEvents;
    private Camera playerCam;

    private void OnEnable() {
        controllerEvents = GetComponent<VRTK_ControllerEvents>();
        playerCam = Camera.main;

        controllerEvents.TouchpadPressed -= DoSnapTurn;
    }

    private void DoSnapTurn(object sender, ControllerInteractionEventArgs e) {
        Debug.Log("Touchpad Axis: (x: " + e.touchpadAxis.x + ", y: " + e.touchpadAxis.y + ")");
        if(playerCam != null) {
            if (e.touchpadAxis.x == 1) {
                playerCam.transform.rotation *= Quaternion.Euler(0, 45, 0);
            }
            else if (e.touchpadAxis.x == -1) {
                playerCam.transform.rotation *= Quaternion.Euler(0, -45, 0);
            }
        } else {
            playerCam = Camera.main;
        }

    }
}
