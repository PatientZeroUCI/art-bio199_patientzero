using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerPress : MonoBehaviour
{

    private Image progressBar;
    public GameObject canvas;
    public bool activated = false;
    public float cap = 0.3f;
    public float timeToHit = 3.0f;
    public float offsetPercent = 10f;
    float time = 0f;
    float timePassed;


    // Update is called once per frame
    void Update()
    {
        if (activated == true)
        {
            timePassed = Time.deltaTime;
            time += timePassed;
            if (Mathf.Floor((time/timeToHit) % 2) == 0)
            {
                progressBar.fillAmount = (time % timeToHit) / timeToHit;

                //this.gameObject.transform.Translate(Vector3.left * (timePassed / (10f * (timeToHit / 3f))));
            }
            else
            {
                progressBar.fillAmount = (timeToHit - (time % timeToHit)) / timeToHit;
                //this.gameObject.transform.Translate(Vector3.right * (timePassed / (10f * (timeToHit / 3f))));
            }
            
        }
    }

    public void activateTimer()
    {
        canvas.SetActive(true);
        progressBar = this.transform.Find("Progress Bar").gameObject.GetComponent<Image>();
        activated = true;
        time = 0f;
    }

    public void hit()
    {
        UnityEngine.Debug.Log(time);
        float iteration = Mathf.Floor((time / timeToHit) % 2);



        float alteredTimeToHit = timeToHit * iteration + 1;

        if (progressBar.fillAmount >= (1 - (offsetPercent/100f)))
        {
            UnityEngine.Debug.Log("Pass!");
        }
        else
        {
            UnityEngine.Debug.Log("Fail!");
        }
        activated = false;
        canvas.SetActive(false);
    }

}
