using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;


public class RotateLeft : MonoBehaviour
{
    public VRTK_PhysicsPusher attached_button;
    //public GameObject target_object;
    public Transform rotation_anchor;
    public Transform target_transform;

    // Start is called before the first frame update
    void Start()
    {
        //target_transform = target_object.transform
    }

    // Update is called once per frame
    void Update()
    {
        if (attached_button.GetValue() <= -0.025)// & pressed == false)
        {
            target_transform.RotateAround(rotation_anchor.position, Vector3.up, 1);
        }
    }
}
