using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public static List<GameObject> objects = new List<GameObject>();
    public static List<Vector3> vSpawns = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objects)
        {
            vSpawns.Add(obj.transform.position);
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tool" || collision.gameObject.tag == "PetriDish")
        {
            //collision.gameObject.transform.position = spawns[objects.IndexOf(collision.gameObject)].position;
            collision.gameObject.transform.position = vSpawns[objects.IndexOf(collision.gameObject)];
        }

    }

    public void setSpawn(GameObject obj)
    {
        objects.Add(obj);
        vSpawns.Add(obj.transform.position);
    }

    public void removeSpawn(GameObject obj)
    {
        objects.Remove(obj);
        vSpawns.Remove(obj.transform.position);
    }
}
