using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPress : MonoBehaviour
{
    public bool activated = false;
    public float timeToHit = 3.0f;
    public float offset = 0.5f;
    float time = 0f;

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            time += Time.deltaTime;
        }
    }

    public void activateTimer()
    {
        activated = true;
        time = 0f;
    }

    public void hit()
    {
        if (time > timeToHit-offset && time < timeToHit + offset)
        {
            UnityEngine.Debug.Log("Pass!");
        }
        else
        {
            UnityEngine.Debug.Log("Fail!");
        }
        activated = false;
    }

}
