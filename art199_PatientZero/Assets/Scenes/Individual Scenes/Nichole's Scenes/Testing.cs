using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(col.gameObject);
    }
}
