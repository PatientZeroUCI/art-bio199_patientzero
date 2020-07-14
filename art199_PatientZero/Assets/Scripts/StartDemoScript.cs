using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;
using VRTK.UnityEventHelper;

public class StartDemoScript : MonoBehaviour {
    private VRTK_InteractableObject_UnityEvents events;

    private void Awake() {
        events = GetComponent<VRTK_InteractableObject_UnityEvents>();
        events.OnGrab.AddListener(Grab);
    }

    private void Grab(object obj, InteractableObjectEventArgs args) {
        //Destroy(gameObject);
        SceneManager.LoadScene("Wrap Up");
    }
}
