using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideElevator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other) {
        Debug.Log("hello");
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("goodbye");
    }
}
