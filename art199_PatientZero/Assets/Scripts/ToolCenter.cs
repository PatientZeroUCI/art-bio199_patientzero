using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCenter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Tool"){
            Destroy(collision.gameObject);
        }
    }
}
