using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightTest : MonoBehaviour
{
    public GameObject myObject;

    public OVRCameraRig camRig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myObject != null)
        {
            Debug.Log(myObject.transform.position.y);
        }
        

        if (camRig != null)
        {
            Debug.Log(camRig.rightEyeCamera.transform.position.y + " " + camRig.rightEyeAnchor.transform.position.y);
            //Debug.Log(camRig.centerEyeAnchor.transform.position.y);
            //Debug.Log(camRig.rightEyeAnchor.transform.position.y);
            //Debug.Log(camRig.trackingSpace.transform.position.y);

        }
    }
}
