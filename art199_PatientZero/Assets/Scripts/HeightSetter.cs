using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HeightSetter : MonoBehaviour
{
    [SerializeField]
    private float defaultHeight;

    [SerializeField]
    private Camera[] cameras;

    [SerializeField]
    private GameObject[] outerTransform;

    [SerializeField]
    private float rotateDegree = 15;


    [SerializeField]
    private VRTK_ControllerEvents controllerEventsRight;
    //public VRTK_ControllerEvents.ButtonAlias rightRotateButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;
    [SerializeField]
    private VRTK_ControllerEvents controllerEventsLeft;
    //public VRTK_ControllerEvents.ButtonAlias leftRotateButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;



    // Start is called before the first frame update
    void Start()
    {
        ScaleHeight();


        controllerEventsRight.TouchpadPressed += RotateRightVR;
        controllerEventsLeft.TouchpadPressed += RotateLeftVR;
    }

    private void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
        //    ChangeHeight(1.0f);
        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateLeft();
        }
    }

    void ScaleHeight()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            //float headHeight = cameras[i].transform.localPosition.y;
            //float newScale = defaultHeight / headHeight;
            //outerTransform[i].transform.localScale = Vector3.one * newScale;

            float headHeight = cameras[i].transform.position.y;
            float heightAdjustment = defaultHeight - headHeight;
            outerTransform[i].transform.position += new Vector3(0, heightAdjustment, 0);
        }
    }

    public void ChangeHeight(float height)
    {
        defaultHeight = height;
        ScaleHeight();
    }


    // These 2 are called from update
    public void RotateRight()
    {
        Debug.Log("test");
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, rotateDegree, 0);
        }
    }

    public void RotateLeft()
    {
        Debug.Log("test");
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, -rotateDegree, 0);
        }
    }


    // These 2 are called from the vrtk_crontroller_events component on the hands
    public void RotateRightVR(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("test");
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, rotateDegree, 0);
        }
    }

    public void RotateLeftVR(object sender, ControllerInteractionEventArgs e)
    {
        Debug.Log("test");
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, -rotateDegree, 0);
        }
    }
}
