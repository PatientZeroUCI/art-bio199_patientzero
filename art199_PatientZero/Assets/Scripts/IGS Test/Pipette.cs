using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour {
    public GameObject contents = null;
    public VRTK.VRTK_InteractUse controllerUse;
    public VRTK.VRTK_InteractableObject pipette;

    // Spawns copies of the stored object
    
    void Update()
    {
        if (pipette.IsGrabbed() && controllerUse.IsUseButtonPressed())
        {
            DropLiquid();
        }
    }

    public void DropLiquid() {
        if (contents != null) {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
        }
    }
}
