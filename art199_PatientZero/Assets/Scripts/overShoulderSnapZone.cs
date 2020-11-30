using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using VRTK;

public class overShoulderSnapZone : MonoBehaviour
{
    public Vector3 offset;
    public GameObject snappedObject;
    public VRTK_SnapDropZone snapZoneObject;

    // Start is called before the first frame update
    void Start()
    {
        snapZoneObject.ForceSnap(snappedObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = VRTK_DeviceFinder.HeadsetTransform().position + offset;
        if (snapZoneObject.GetCurrentSnappedObject() == snappedObject)
        {
            snappedObject.GetComponent<Renderer>().enabled = false;
            snappedObject.transform.position = transform.position; 
        }
        else 
        {
            snappedObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
