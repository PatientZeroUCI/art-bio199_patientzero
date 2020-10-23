using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIndicatorFixScript : MonoBehaviour
{
    private float scaleSize = 0.025f;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x != scaleSize) {
            transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
        }
    }
}
