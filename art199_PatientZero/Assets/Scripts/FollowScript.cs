using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject target_object;
    private Vector3 position_offset;
    // Start is called before the first frame update
    void Start()
    {
        //position_offset = transform.position - target_object.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target_object.transform.position;
        transform.rotation = target_object.transform.rotation;
    }
}
