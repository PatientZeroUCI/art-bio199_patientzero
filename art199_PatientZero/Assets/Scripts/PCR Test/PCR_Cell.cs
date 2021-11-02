using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCR_Cell : MonoBehaviour
{
    // Whether the path extends in a direction
    public bool upOpen = false;
    public bool downOpen = false;
    public bool leftOpen = false;
    public bool rightOpen = false;

    // The actual path gameobjects on the hexagon
    public GameObject upPath;
    public GameObject downPath;
    public GameObject leftPath;
    public GameObject rightPath;

    // Coordinates on the PCR grid it is bottome left
    public int row = 0;
    public int column = 0;

    public VRTK.VRTK_InteractableObject linkedObject;



    // Start is called before the first frame update
    void Start()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        }

        UpdatePaths();
    }

    // Rotates 90 degrees clockwise
    public void Rotate()
    {
        bool temp = upOpen;
        upOpen = leftOpen;
        leftOpen = downOpen;
        downOpen = rightOpen;
        rightOpen = temp;

        UpdatePaths();
    }

    // Makes the physical paths appear or dissapear whether they are on or not
    public void UpdatePaths()
    {
        upPath.SetActive(upOpen);
        downPath.SetActive(downOpen);
        leftPath.SetActive(leftOpen);
        rightPath.SetActive(rightOpen);
    }

    private void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    Rotate();
        //}
    }

    protected virtual void InteractableObjectUsed(object sender, VRTK.InteractableObjectEventArgs e)
    {
        Debug.Log("used");
        Rotate();
    }
}
