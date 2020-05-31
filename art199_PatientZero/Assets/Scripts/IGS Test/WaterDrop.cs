using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop : MonoBehaviour {
    float time = 5;

    void Update() {
        time -= Time.deltaTime;

        if (time < 0) {
            Destroy(gameObject);
        }
    }
}
