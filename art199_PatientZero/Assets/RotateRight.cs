using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;


public class RotateRight : MonoBehaviour
{
    public VRTK_PhysicsPusher attached_button;
    public Transform rotation_anchor;
    public Transform target_transform;

    

    // Update is called once per frame
    void Update()
    {
        if (attached_button.GetValue() <= -0.025)
        {
            target_transform.RotateAround(rotation_anchor.position, Vector3.up, -1);
        }
    }
}
