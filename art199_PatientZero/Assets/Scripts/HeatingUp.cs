using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatingUp : MonoBehaviour
{
    //IGSsample gameobject
    //public GameObject IGSsample;

    //public GameObject IGSscooper;

    //not sure if I need this just precation
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //subtract 1 HP every second until HP = 0
    //HP can't be below 0
    //when HP = 0 then change the color of the sample/scooper 
    void OnTriggerStay(Collider IGSsample)
    {
        // Heating the sample is being handled in the IGSTestSlide script
        //if (IGSsample.gameObject.CompareTag("IGSsample"))
        //{
        //    if (IGSsample.GetComponent<IGSTestSlide>().progress < 5)
        //    {
        //        heatUpSample();
        //    }

        //    if (IGSsample.GetComponent<IGSTestSlide>().progress > 5)
        //    {
        //        IGSsample.GetComponent<IGSTestSlide>().progress = 5;
        //    }

        //    if (IGSsample.GetComponent<IGSTestSlide>().progress == 5)
        //    {
        //        IGSsample.GetComponent<Renderer>().material.color = Color.red;
        //    }
        //}

        if (IGSsample.gameObject.CompareTag("IGSscooper"))
        {
            IGSscooperHP scooper = IGSsample.GetComponent<IGSscooperHP>();
            if (scooper.scoopCurrentHP > 0) {
                scooper.scoopCurrentHP -= Time.fixedDeltaTime;
            }

            if (scooper.scoopCurrentHP < 0) {
                scooper.scoopCurrentHP = 0;
            }

            if (scooper.scoopCurrentHP == 0) {
                scooper.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    //heat up sample method
    //void heatUpSample()
    //{
    //    IGSsample.GetComponent<IGSTestSlide>().progress += Time.deltaTime;
    //}

    //void heatUpScooper()
    //{
    //    IGSscooper.GetComponent<IGSTestSlide>().progress += Time.deltaTime;
    //}
}
