using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Incubator : MonoBehaviour {
    ProgressBar progressBar = null;
    float time = 0;
    GameObject obj = null;
    [SerializeField] Material glowingMaterial;

    void Start() {
        progressBar = GetComponentInChildren<ProgressBar>();
        progressBar.Visible = false;
    }

    private void Update() {
        if (obj != null) {
            if (time > 5) {
                obj.GetComponent<Renderer>().material = glowingMaterial;
                progressBar.Value = 1;
            } else {
                time += Time.deltaTime;
                progressBar.Value = time / 5f;
            }

            progressBar.Visible = true;
        } else {
            progressBar.Visible = false;
        }
    }

    public void ObjectInserted(object o, SnapDropZoneEventArgs e) {
        //if (e.snappedObject.tag == "PetriDish") {
            time = 0;
            obj = e.snappedObject;
        //}
    }

    public void ObjectRemoved(object o, SnapDropZoneEventArgs e) {
        obj = null;
        time = 0;
    }
}
