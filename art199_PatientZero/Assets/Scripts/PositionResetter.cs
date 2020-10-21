using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public List<GameObject> objects;
    public List<Transform> spawns;


    // Start is called before the first frame update
    void Start()
    {
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Entered");
        if (collision.gameObject.tag == "Tool" || collision.gameObject.tag == "PetriDish")
        {
            collision.gameObject.transform.position = spawns[objects.IndexOf(collision.gameObject)].transform.position;
        }

    }
}
