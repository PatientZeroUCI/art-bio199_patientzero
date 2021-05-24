using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3[] teleportPoints;
    private int currPoint = 0;  //Which teleport point your currently at

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left") && (currPoint < teleportPoints.Length))
        {
            player.transform.position = teleportPoints[currPoint];

            currPoint += 1;
        }
    }
}
