using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PositionResetter : MonoBehaviour
{
    public static List<GameObject> objects = new List<GameObject>();
    public static List<Vector3> vSpawns = new List<Vector3>();
    public static List<Vector3> rotations = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objects)
        {
            vSpawns.Add(new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));
            rotations.Add(new Vector3(obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z));
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //
    //}

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("to delete");
        if (collision.gameObject.tag == "Tool" || collision.gameObject.tag == "PetriDish")
        {
            int index = objects.IndexOf(collision.gameObject);

            collision.gameObject.transform.position = vSpawns[index];
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.eulerAngles = rotations[index];
            

        }

    }

    public void setSpawn(GameObject obj)
    {
        objects.Add(obj);
        vSpawns.Add(new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z));
        rotations.Add(new Vector3(obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z));
    }

    public void removeSpawn(GameObject obj)
    {
        int index = objects.IndexOf(obj);
        objects.Remove(obj);
        
        vSpawns.RemoveAt(index);
        rotations.RemoveAt(index);
    }
}
