using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour {
    public GameObject contents = null;

    // Spawns copies of the stored object
    public void DropLiquid() {
        if (contents != null) {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
        }
    }
}
