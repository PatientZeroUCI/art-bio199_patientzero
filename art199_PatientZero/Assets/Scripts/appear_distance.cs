using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear_distance : MonoBehaviour
{
    public MeshRenderer text;
    //public Transform headset = VRTK_DeviceFinder.HeadsetTransform();
    // Start is called before the first frame update
    void Start()
    {
        GameObject go = GameObject.Find("Body");
        Vector3 player_pos = go.transform.position;

        Vector3 object_pos = gameObject.transform.position;

        Debug.Log(player_pos);
        Debug.Log(object_pos);
        Debug.Log(Vector3.Distance(player_pos,object_pos));
        if (Vector3.Distance(player_pos, object_pos) > 1)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("Body");

        Vector3 player_pos = go.transform.position;
        Vector3 object_pos = gameObject.transform.position;

        //Debug.Log(player_pos);
        //Debug.Log(object_pos);
        //Debug.Log(Vector3.Distance(player_pos, object_pos));
        if(Vector3.Distance(player_pos, object_pos) > 1)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
    }
}
