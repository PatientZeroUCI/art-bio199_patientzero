using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirtBottle : MonoBehaviour {
    [SerializeField] GameObject contents = null;

    private void Update() {
        if (contents != null && Vector3.Angle(transform.rotation * Vector3.forward, Vector3.down) < 30) {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
        }
    }
}
