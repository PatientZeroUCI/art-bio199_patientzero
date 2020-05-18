using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleHP : MonoBehaviour
{
    // not sure if needed
    private Rigidbody rb;
    //also not sure if needed
    public GameObject sample;
    //number of seconds we want to heat the sample/scooper up for
    private float maxHP;
    //might get rid of current HP but just helps keep track
    public float currentHP;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHP = 5;  //5 seconds
        currentHP = maxHP;
    }

}
