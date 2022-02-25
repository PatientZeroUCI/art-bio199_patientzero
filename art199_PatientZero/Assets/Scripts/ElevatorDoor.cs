using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public bool isLeftDoor;
    private void OnTriggerEnter(Collider other)
    {
        if (isLeftDoor)
        {
            transform.position = transform.position - new Vector3(0.6f, 0, 0);
        }
        else
        {
            transform.position = transform.position + new Vector3(0.6f, 0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLeftDoor)
        {
            transform.position = transform.position + new Vector3(0.6f, 0, 0);
        }
        else
        {
            transform.position = transform.position - new Vector3(0.6f, 0, 0);
        }
    }
}
