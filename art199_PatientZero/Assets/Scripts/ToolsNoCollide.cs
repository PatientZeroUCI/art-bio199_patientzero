using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ToolsNoCollide : MonoBehaviour
{
    [SerializeField]
    private bool collideWhileNotGrabbed = false;  // Should a tool be able to collide with other tools when not grabbed
    [SerializeField]
    private bool collideWhileGrabbed = false;  // Should a tool be able to interact with other tools when grabbed, should be true for tools like the qtip or egg
    [SerializeField]
    private VRTK_InteractableObject obj;  // the Object's VRTK_InteractableObject script

    // Uses layer 9, "ToolsNoCollide", which doesn't collide with other objects witht the tag

    // Start is called before the first frame update
    void Start()
    {
        if (!collideWhileNotGrabbed)
        {
            gameObject.layer = 8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.IsGrabbed())
        {
            if (!collideWhileGrabbed)
            {
                gameObject.layer = 8;
            }
            else
            {
                gameObject.layer = 0;
            }
        }

        else
        {
            if (!collideWhileNotGrabbed)
            {
                gameObject.layer = 8;
            }
            else
            {
                gameObject.layer = 0;
            }
        }
    }
}
