using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAPercentMatch : MonoBehaviour
{
    [SerializeField] int matchPercent = 99;

    private TextMesh text;

    private Collider otherRing;

    private void Awake() {
        text = GetComponentInChildren<TextMesh>();
        text.color = Color.clear;
    }

    private void Update() {
        if (otherRing != null) {
            //text.text = $"{matchPercent}%";
            text.color = Color.white;
        } else {
            text.color = Color.clear;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "DNA Ring") {
            otherRing = other;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == otherRing) {
            otherRing = null;
        }
    }
}
