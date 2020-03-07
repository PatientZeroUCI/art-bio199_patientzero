using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the Inspectable script basically makes it so you are able to enlarge and shrink objects
// you will also be able to rotate them left, right, up, and down

// in order to use this script, you can just attach to it any game object...
// for additional features, it is recommended that you make a new class that inherits from this class

public class Inspectable : MonoBehaviour
{
    // these store the default values so that the reset function can use them
    protected Quaternion originalQuaternion;
    protected Vector3 originalScale;
    protected Vector3 originalPosition;

    // the enums facilitate readability in the code below
    public enum Direction
    {
        left,
        right,
        up,
        down,
        shrink,
        enlarge
    }

    // we initialize the default values so the reset function will be able to reset to them
    public void Start()
    {
        originalQuaternion = gameObject.transform.localRotation;
        originalScale = gameObject.transform.localScale;
        originalPosition = gameObject.transform.position;

        
    }


    // Update is called once per frame
    public void Update()
    {
        // this is primarily how the code should be used
        // feel free to experiment with bindings

        // we will have to change this because the movements will
        // primarily be activated by an in-game button
        // the in-game button would probably work best if its held...
        if (Input.GetKey("q"))
        {
            Rotate(Direction.left);
        }

        if (Input.GetKey("e"))
        {
            Rotate(Direction.right);
        }

        if (Input.GetKey("r"))
        {
            ResetObject();
        }

        
    }

    // this resets the object's transform to the default values
    public void ResetObject()
    {
        gameObject.transform.localRotation = originalQuaternion;
        gameObject.transform.localScale = originalScale;
        gameObject.transform.position = originalPosition;
    }

    // this either enlarges or shrinks the object
    public void Scale(Direction direction)
    {
        Vector3 currentScale = gameObject.transform.localScale;
        Vector3 newScale;
        switch (direction)
        {
            case Direction.enlarge:
                newScale = new Vector3(currentScale.x + 0.1f, currentScale.y + 0.1f, currentScale.z + 0.1f);
                gameObject.transform.localScale = newScale;
                break;
            case Direction.shrink:
                newScale = new Vector3(currentScale.x - 0.1f, currentScale.y - 0.1f, currentScale.z - 0.1f);
                gameObject.transform.localScale = newScale;
                break;
        }

    }

    // this allows us to rotate the object
    public void Rotate(Direction direction)
    {
        Quaternion currentRotation = gameObject.transform.localRotation;
        Quaternion newRotation;

        switch (direction)
        { 
            case Direction.left:
                newRotation = new Quaternion(currentRotation.x - 0.1f, currentRotation.y, currentRotation.z, currentRotation.w);
                gameObject.transform.localRotation = newRotation;
                break;
            case Direction.right:
                newRotation = new Quaternion(currentRotation.x + 0.1f, currentRotation.y , currentRotation.z, currentRotation.w);
                gameObject.transform.localRotation = newRotation;
                break;
            case Direction.up:
                newRotation = new Quaternion(currentRotation.x, currentRotation.y + 0.1f, currentRotation.z, currentRotation.w);
                gameObject.transform.localRotation = newRotation;
                break;
            case Direction.down:
                newRotation = new Quaternion(currentRotation.x, currentRotation.y - 0.1f, currentRotation.z, currentRotation.w);
                gameObject.transform.localRotation = newRotation;
                break;
        }
    }

    
    
}
