using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerPress : MonoBehaviour
{
    public bool activated = false;
    public float cap = 0.3f;
    public float timeToHit = 3.0f;
    public float offset = 0.5f;
    float time = 0f;
    float timePassed;

    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            timePassed = Time.deltaTime;
            time += timePassed;
            if (time < timeToHit)
            {
                this.gameObject.transform.Translate(Vector3.left * (timePassed / (10f * (timeToHit / 3f))));
            }
            else
            {
                this.gameObject.transform.Translate(Vector3.right * (timePassed / (10f * (timeToHit / 3f))));
            }
            
        }
    }

    public void activateTimer()
    {
        activated = true;
        time = 0f;
    }

    public void hit()
    {
        UnityEngine.Debug.Log(time);
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
