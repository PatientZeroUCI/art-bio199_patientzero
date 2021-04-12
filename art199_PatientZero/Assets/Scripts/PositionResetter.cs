﻿using System;
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
    public static List<String> tags = new List<String>();

    public float objRespawnHeightOffset = 0f;  //When a tool falls and respawns, will change the height by this amount, -.23 seems to work for the scaled lab


    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in objects)
        {
            vSpawns.Add(new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z));
            rotations.Add(new Vector3(obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z));
        }
        tags.Add("Tool");
        tags.Add("PetriDish");
        tags.Add("Phase1Doc");
        tags.Add("Book");
    }

    //// Update is called once per frame
    //void Update()
    //{
    //
    //}

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("to delete");
        if (tags.Contains(collision.gameObject.tag))
        {
            int index = objects.IndexOf(collision.gameObject);
            UnityEngine.Debug.Log(objects.Count);
            UnityEngine.Debug.Log(index);
            collision.gameObject.transform.position = vSpawns[index] + new Vector3(0, objRespawnHeightOffset, 0);
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.transform.eulerAngles = rotations[index];
            

        }

    }

    public void setSpawn(GameObject obj)
    {
        UnityEngine.Debug.Log("added");
        objects.Add(obj);
        rotations.Add(new Vector3(obj.transform.rotation.eulerAngles.x, obj.transform.rotation.eulerAngles.y, obj.transform.rotation.eulerAngles.z));
        vSpawns.Add(new Vector3(obj.transform.position.x, obj.transform.position.y + 0.586f, obj.transform.position.z));
        //vSpawns.Add(new Vector3(obj.transform.position.x, obj.transform.position.y + 0.15f, obj.transform.position.z));
        

    }

    public void removeSpawn(GameObject obj)
    {
        int index = objects.IndexOf(obj);
        objects.Remove(obj);
        
        vSpawns.RemoveAt(index);
        rotations.RemoveAt(index);
    }

    public Boolean checkTag(String tag)
    {
        if (tags.Contains(tag))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
