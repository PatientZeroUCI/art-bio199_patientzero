using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm_Light : MonoBehaviour
{
    public Light alarm;

    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Alarm());
    }

    // Update is called once per frame
    IEnumerator Alarm ()
    {
        while (true)
        {

        }
    }
}
