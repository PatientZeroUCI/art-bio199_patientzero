using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightAdjuster : MonoBehaviour
{
    public GameObject obj;  //Object to adjust
    public GameObject displayObj;  // Object to display the height
    public Text screen; // text to change to display height

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            obj.transform.Translate(.25f * Vector3.up * Time.deltaTime);
        }

        else if (Input.GetKey("down"))
        {
            obj.transform.Translate(-.25f * Vector3.up * Time.deltaTime);
        }

        screen.text = displayObj.transform.position.y.ToString();
    }
}
