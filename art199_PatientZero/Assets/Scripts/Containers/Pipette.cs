using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipette : MonoBehaviour {
    public GameObject contents = null;
    public Transform entryPoint = null;

    void Update() {
        /*if (Input.GetKeyDown(KeyCode.Z)) {
            DrawLiquid();
        } else if (Input.GetKey(KeyCode.X)) {
            DropLiquid();
        }

        transform.Translate(Input.GetAxis("Horizontal") * 0.1f, 0, 0, Space.World);*/
    }

    public void DrawLiquid() {
        foreach (Collider collider in Physics.OverlapSphere(entryPoint.position, 0.1f)) {
            LiquidContainer container;
            if ((container = collider.GetComponent<LiquidContainer>()) != null) {
                contents = container.contents;
                return;
            }
        }
    }

    public void DropLiquid() {
        if (contents != null) {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = entryPoint.position;
            liquid.SetActive(true);
        }
    }
}
