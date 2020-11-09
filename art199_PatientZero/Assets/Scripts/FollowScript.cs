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
        //transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //position_offset = transform.position - target_object.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target_object.transform.position;
        transform.rotation = target_object.transform.rotation;

        transform.rotation = Quaternion.Euler(transform.rotation.x, 180f + target_object.transform.rotation.y, transform.rotation.z);
    }
}
