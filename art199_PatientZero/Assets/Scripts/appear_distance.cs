using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear_distance : MonoBehaviour
{
    public MeshRenderer text;
    public double render_distance;
    //Vector3 player_pos;

    //public Transform headset = VRTK_DeviceFinder.HeadsetTransform();
    // Start is called before the first frame update

    private void Reset()
    {
        render_distance = 1.0;
    }
    void Start()
    {
        Vector3 player_pos;

        GameObject go = GameObject.Find("Neck");
        if (go == null) {
            player_pos = Vector3.zero;
        }
        else
        {
            player_pos = go.transform.position;
        }

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
        Vector3 player_pos;

        GameObject go = GameObject.Find("Neck");
        if (go == null)
        {
            player_pos = Vector3.zero;
        }
        else
        {
            player_pos = go.transform.position;
        }
        Vector3 object_pos = gameObject.transform.position;

        //Debug.Log(player_pos);
        //Debug.Log(object_pos);
        //Debug.Log(Vector3.Distance(player_pos, object_pos));
        if(Vector3.Distance(player_pos, object_pos) > render_distance)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
    }
}
