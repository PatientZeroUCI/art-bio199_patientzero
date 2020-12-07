using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLengthSwitch : MonoBehaviour
{
    public GameObject shortHitbox;
    public GameObject longHitbox;

    public bool shortGrab;
    public bool longGrab;



    // Start is called before the first frame update
    void Start()
    {
        shortHitbox.SetActive(shortGrab);
        longHitbox.SetActive(longGrab);
        if (shortGrab == longGrab)
        {
            Debug.LogError("Cannot have both Long and Short Grabs enabled!");
        }
    }

    public void setLength()
    {
        shortGrab = !shortGrab;
        longGrab = !longGrab;
        shortHitbox.SetActive(shortGrab);
        longHitbox.SetActive(longGrab);
    }
}
