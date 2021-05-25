using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepthAdjuster : MonoBehaviour
{
    public GameObject obj;  //Object to adjust
    public GameObject displayObj;  // Object to display the height
    public GameObject table;  // Table to use to calculate obj distance from edge of table

    public Text rightScreen; // text to change to display height
    public Text leftScreen; // text to change to display height

    public GameObject rightObj;  // Obj that moves right
    public GameObject leftObj;  // Obj that moves left

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves Objs forward and back
        if (Input.GetKey("up"))
        {
            obj.transform.Translate(.25f * Vector3.forward * Time.deltaTime);
        }

        else if (Input.GetKey("down"))
        {
            obj.transform.Translate(-.25f * Vector3.forward * Time.deltaTime);
        }


        //  Move the side objs outward and inward
        if (Input.GetKey("right"))
        {
            rightObj.transform.Translate(.25f * Vector3.right * Time.deltaTime);
            leftObj.transform.Translate(-.25f * Vector3.right * Time.deltaTime);
        }

        else if (Input.GetKey("left"))
        {
            rightObj.transform.Translate(-.25f * Vector3.right * Time.deltaTime);
            leftObj.transform.Translate(.25f * Vector3.right * Time.deltaTime);
        }

        rightScreen.text = "Distance from edge:   " + (-1 * (table.transform.position.z - (table.transform.localScale.z / 2) - displayObj.transform.position.z)).ToString();
        leftScreen.text = "Distance from center:   " + (-table.transform.position.x + rightObj.transform.position.x).ToString();
    }
}
