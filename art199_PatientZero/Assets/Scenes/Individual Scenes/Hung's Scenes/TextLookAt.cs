using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform text;
    public Transform focus;
    void Start()
    {
        text = this.transform;
        focus = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * text.position - focus.position);
    }
}
