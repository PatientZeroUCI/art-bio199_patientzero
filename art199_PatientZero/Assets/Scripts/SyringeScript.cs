using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.GrabAttachMechanics;

public class SyringeScript : MonoBehaviour {
    public GameObject filler;

    private bool isGrabbed = false;
    private bool containsVirus = false;

    private void OnTriggerStay(Collider other) {
        if (Input.GetKeyDown("e") && isGrabbed && other.name == filler.name) {
            containsVirus = true;
        }
    }

    public void toggleGrabbed(bool toggle) {
        isGrabbed = toggle;
    }
}