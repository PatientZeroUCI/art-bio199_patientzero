using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightSetter : MonoBehaviour
{
    [SerializeField]
    private float defaultHeight;

    [SerializeField]
    private Camera[] cameras;

    [SerializeField]
    private GameObject[] outerTransform;

    // Start is called before the first frame update
    void Start()
    {
        ScaleHeight();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            ScaleHeight();
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
}
