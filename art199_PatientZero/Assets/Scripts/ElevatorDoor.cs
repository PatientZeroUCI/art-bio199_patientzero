using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    private bool DoorsOpen = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!DoorsOpen)
        {
            DoorsOpen = true;
            GameObject.FindGameObjectWithTag("LeftDoor").GetComponent<MeshRenderer>().enabled = false;
            GameObject.FindGameObjectWithTag("RightDoor").GetComponent<MeshRenderer>().enabled = false;
            //GameObject.FindGameObjectWithTag("LeftDoor").transform.position = GameObject.FindGameObjectWithTag("LeftDoor").transform.position - new Vector3(2, 0, 0);
            //GameObject.FindGameObjectWithTag("RightDoor").transform.position = GameObject.FindGameObjectWithTag("RightDoor").transform.position + new Vector3(2, 0, 0);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (DoorsOpen)
        {
            DoorsOpen = false;
            GameObject.FindGameObjectWithTag("LeftDoor").GetComponent<MeshRenderer>().enabled = true;
            GameObject.FindGameObjectWithTag("RightDoor").GetComponent<MeshRenderer>().enabled = true;
            //GameObject.FindGameObjectWithTag("LeftDoor").transform.position = GameObject.FindGameObjectWithTag("LeftDoor").transform.position + new Vector3(2, 0, 0);
            //GameObject.FindGameObjectWithTag("RightDoor").transform.position = GameObject.FindGameObjectWithTag("RightDoor").transform.position - new Vector3(2, 0, 0);
        }
    }
}
