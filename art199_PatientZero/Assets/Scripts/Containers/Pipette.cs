using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour {
    public GameObject contents = null;

    //void Update() {
    //    if (Input.GetKeyDown(KeyCode.Z)) {
    //        DrawLiquid();
    //    } else if (Input.GetKey(KeyCode.X)) {
    //        DropLiquid();
    //    }

    //    transform.Translate(Input.GetAxis("Horizontal") * 0.1f, 0, 0, Space.World);
    //}

    // Draws liquid from containers that are overlapping
    public void DrawLiquid() {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, 0.1f)) {
            LiquidContainer container;
            if ((container = collider.GetComponent<LiquidContainer>()) != null) {
                contents = container.contents;
                return;
            }
        }
    }

    // Spawns copies of the stored object
    public void DropLiquid() {
        if (contents != null) {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
        }
    }
}
