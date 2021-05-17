using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawnPoint : MonoBehaviour
{
    public GameObject obj; //object to respawn
    public string resetInput = "right";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(resetInput))
        {
            Respawn();
        }
    }

    // Moves the obj to the Spawn points position and rotation which are the same as the originals of the obj
    public void Respawn()
    {
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;
    }
}
