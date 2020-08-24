using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsenBurner : MonoBehaviour
{
    ParticleSystem ps;

    public AudioSource onSound;        //
    public AudioSource runnningSound;      //
    public AudioSource offSound;       //
    Collider col;
    Light lgt;

    public bool turnedOn = false;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        col = GetComponentInChildren<Collider>();
        lgt = GetComponentInChildren<Light>();
        //onSound = GameObject.Find("")

        if (turnedOn)
        {
            TurnOn();
            runnningSound.loop = true;      //
            runnningSound.Play();
        }
        else
        {
            TurnOff();
        }
    }

    //private void Update() {
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        Toggle();
    //    }
    //}

    public void Toggle()
    {
        if (turnedOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        turnedOn = true;
        ps.Play();
        col.enabled = true;
        lgt.enabled = true;
        onSound.Play();
        runnningSound.loop = true;      //
        runnningSound.Play();       //
    }

    public void TurnOff()
    {
        turnedOn = false;
        ps.Stop();
        col.enabled = false;
        lgt.enabled = false;
        runnningSound.loop = false;     //
        runnningSound.Stop();       //
        offSound.Play();        //
    }
}
