using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSscooperHP : MonoBehaviour
{
    // Is the sample loaded?
    public bool sampleLoaded = false;
    // Is the sample gram positive?
    public bool positive = false;


    private float scoopMaxHP;

    public float scoopCurrentHP;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoopMaxHP = 3;
        scoopCurrentHP = scoopMaxHP;

    }

    private void OnCollisionEnter(Collision collision) {
        PetriDish petriDish = collision.gameObject.GetComponent<PetriDish>();
        if (petriDish != null && petriDish.swabComplete && scoopCurrentHP == 0) {
            sampleLoaded = true;
            positive = true; // placeholder
        }
    }
}
