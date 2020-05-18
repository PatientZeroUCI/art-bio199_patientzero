using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSscooperHP : MonoBehaviour
{
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

}
