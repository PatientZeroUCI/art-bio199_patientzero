using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualCell : MonoBehaviour
{
    public Transform resetPosition;
    private GameObject respawn;
    private void Start()
    {
        respawn = this.gameObject;

        resetPosition = this.transform;
        resetPosition.position = this.transform.position;
        resetPosition.rotation = this.transform.rotation;
    }

    public void ResetDisplay()
    {

        //Instantiate(respawn,resetPosition);
        this.transform.position = resetPosition.position;
        this.transform.rotation = resetPosition.rotation;
    }
}
