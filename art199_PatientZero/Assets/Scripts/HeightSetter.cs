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


    public VRTK_ControllerEvents controllerEventsRight;
    public VRTK_ControllerEvents.ButtonAlias rightRotateButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;
    public VRTK_ControllerEvents controllerEventsLeft;
    public VRTK_ControllerEvents.ButtonAlias leftRotateButton = VRTK_ControllerEvents.ButtonAlias.ButtonTwoPress;



    // Start is called before the first frame update
    void Start()
    {
        ScaleHeight();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ChangeHeight(1.0f);
        }

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

    void RotateRight()
    {
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, rotateDegree, 0);
        }
    }

    void RotateLeft()
    {
        for (int i = 0; i < outerTransform.Length; i++)
        {
            outerTransform[i].transform.rotation *= Quaternion.Euler(0, -rotateDegree, 0);
        }
    }
}
