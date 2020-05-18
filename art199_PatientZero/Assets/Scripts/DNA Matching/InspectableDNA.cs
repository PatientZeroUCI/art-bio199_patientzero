using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a derived class of the Inspectable class
// the reason that you can't simply use the Inspectable class on the DNA is
// because this derived class allows the player to "combine" or "separate"
// the strands...

// in order to use this class...
// put it on an DNA GameObject
// there should be two child objects: Left Strand and Right Strand
// Move them apart from one another...
// They should be at the same level 
// Center the parent game object on these two...

public class InspectableDNA : Inspectable
{
    private GameObject leftStrand;
    private GameObject rightStrand;

    // we save the original positions so the strands can be moved back there later
    private Vector3 leftStrandOriginalPosition;
    private Vector3 rightStrandOriginalPosition;

    // Start is called before the first frame update
    private new void Start()
    {
        base.Start();

        leftStrand = gameObject.transform.Find("Left Strand").gameObject;
        rightStrand = gameObject.transform.Find("Right Strand").gameObject;

        leftStrandOriginalPosition = leftStrand.transform.position;
        rightStrandOriginalPosition = rightStrand.transform.position;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();

        // the intended way of using the class should be something similar to this
        // code down here.
        if (Input.GetKey("a"))
        {
            separateDNA();
        }

        if (Input.GetKey("d"))
        {
            combineDNA();
        }
    }

    // this moves the DNA strands toward the "center" of their parent object
    public void combineDNA()
    { 
        if (leftStrand && rightStrand)
        {
            Vector3 newLeftStrandPos = new Vector3(originalPosition.x + (leftStrand.transform.localScale.x / 2), originalPosition.y , originalPosition.z);
            Vector3 newRightStrandPos = new Vector3(originalPosition.x - (rightStrand.transform.localScale.x / 2), originalPosition.y, originalPosition.z);

            Vector3 leftStrandNewPosition = Vector3.MoveTowards(leftStrand.transform.position, newLeftStrandPos, 0.01f);
            Vector3 rightStrandNewPosition = Vector3.MoveTowards(rightStrand.transform.position, newRightStrandPos, 0.01f);

            leftStrand.transform.position = leftStrandNewPosition;
           rightStrand.transform.position = rightStrandNewPosition;
        }
    }

    // this moves the DNA strands back toward their "original" position
    public void separateDNA()
    {
        if (leftStrand && rightStrand)
        {
            Vector3 newLeftStrandPos = new Vector3(leftStrandOriginalPosition.x, leftStrandOriginalPosition.y, leftStrandOriginalPosition.z);
            Vector3 newRightStrandPos = new Vector3(rightStrandOriginalPosition.x, rightStrandOriginalPosition.y, rightStrandOriginalPosition.z);

            Vector3 leftStrandNewPosition = Vector3.MoveTowards(leftStrand.transform.position, newLeftStrandPos, 0.01f);
            Vector3 rightStrandNewPosition = Vector3.MoveTowards(rightStrand.transform.position, newRightStrandPos, 0.01f);

            leftStrand.transform.position = leftStrandNewPosition;
            rightStrand.transform.position = rightStrandNewPosition;
        }
    }


}
