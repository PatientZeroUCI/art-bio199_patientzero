using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ObservatoryDisplay : MonoBehaviour
{

    public GameObject observatory_hologram;

    public void WaitDisplay()
    {
        StartCoroutine(SleepDisplay());
    }

    IEnumerator SleepDisplay()
    {
        //Anything that needs to be "loaded in" can be placed after the wait. 
        yield return new WaitForSeconds(3.0f);
        observatory_hologram.SetActive(true);
    }
}
