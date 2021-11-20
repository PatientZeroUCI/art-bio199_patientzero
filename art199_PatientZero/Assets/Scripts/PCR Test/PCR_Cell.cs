using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCR_Cell : MonoBehaviour
{
    // Whether the path extends in a direction
    [HideInInspector]
    public bool upOpen = false;
    [HideInInspector]
    public bool downOpen = false;
    [HideInInspector]
    public bool leftOpen = false;
    [HideInInspector]
    public bool rightOpen = false;

    // The actual path gameobjects on the hexagon
    public GameObject upPath;
    public GameObject downPath;
    public GameObject leftPath;
    public GameObject rightPath;

    private Quaternion newRotation;  //Rotation to rotate towards
    [SerializeField]
    private float rotationSpeed;

    // Coordinates on the PCR grid, [0,0] is the bottom left
    public int x = 0;
    public int y = 0;

    public VRTK.VRTK_InteractableObject linkedObject;



    // Start is called before the first frame update
    void Start()
    {
        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        }

        upOpen = upPath.activeSelf;
        downOpen = downPath.activeSelf;
        leftOpen = leftPath.activeSelf;
        rightOpen = rightPath.activeSelf;
        //UpdatePaths();
    }



    private void FixedUpdate()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed);
    }



    // Rotates 90 degrees clockwise
    public void Rotate()
    {
        bool temp = upOpen;
        upOpen = leftOpen;
        leftOpen = downOpen;
        downOpen = rightOpen;
        rightOpen = temp;

        //UpdatePaths();

        newRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);

        // Check to see if the path is correct
        transform.parent.GetComponent<PCR_Grid>().CheckSequence();
    }

    // Makes the physical paths appear or dissapear whether they are on or not, not needed niow since the cell just rotates
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
        Rotate();
    }
}


