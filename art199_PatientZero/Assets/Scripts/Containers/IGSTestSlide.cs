using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSTestSlide : MonoBehaviour {
    public enum State { Start, WaterAdded, SampleLoaded, SampleDried, Heated, DyeAdded, Washed, Done }

    public State state = State.Start;
    
    // progress depending on the different state
    // i.e. for state DyeAdded, tells how much dye has been added so far
    public float progress = 0;

    ProgressBar progressBar = null;

    void Start() {
        progressBar = GetComponentInChildren<ProgressBar>();
        progressBar.Visible = false;
    }

    void Update() {
        if (state == State.SampleLoaded) {
            progress += Time.deltaTime;

            if (progress >= 10f) {
                state = State.SampleDried;
                progress = 0;
                progressBar.Value = 0;
                progressBar.Visible = false;
            } else {
                progressBar.Value = progress / 10f;
                progressBar.Visible = true;
            }
        } else if (state == State.Washed) {
            progress += Time.deltaTime;

            if (progress >= 10f) {
                state = State.Done;
                progress = 0;
                progressBar.Value = 0;
                progressBar.Visible = false;
            } else {
                progressBar.Value = progress / 10f;
                progressBar.Visible = true;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        switch (state) {
            case State.Start:
                WaterDrop water;
                if ((water = collision.gameObject.GetComponent<WaterDrop>()) != null) {
                    state = State.WaterAdded;
                    Destroy(water.gameObject);
                }
                break;
            case State.WaterAdded:
                IGSscooperHP scooper;
                if ((scooper = collision.gameObject.GetComponent<IGSscooperHP>()) != null && scooper.scoopCurrentHP == 0) {
                    if (++progress >= 5) {
                        state = State.SampleLoaded;
                        progress = 0;
                        progressBar.Value = 0;
                        progressBar.Visible = false;
                    } else {
                        progressBar.Value = progress / 5f;
                        progressBar.Visible = true;
                    }
                }
                break;
            case State.Heated:
                IGSDye dye;
                if ((dye = collision.gameObject.GetComponent<IGSDye>()) != null) {
                    if (++progress >= 50) {
                        state = State.DyeAdded;
                        progress = 0;
                        progressBar.Value = 0;
                        progressBar.Visible = false;
                    } else {
                        progressBar.Value = progress / 50f;
                        progressBar.Visible = true;
                    }
                    Destroy(dye.gameObject);
                }
                break;
            case State.DyeAdded:
                if ((water = collision.gameObject.GetComponent<WaterDrop>()) != null) {
                    if (++progress >= 50) {
                        state = State.Washed;
                        progress = 0;
                        progressBar.Value = 0;
                        progressBar.Visible = false;
                    } else {
                        progressBar.Value = progress / 50f;
                        progressBar.Visible = true;
                    }
                    Destroy(water.gameObject);
                }
                break;
        }
    }

    void OnTriggerStay(Collider other) {
        if (state == State.SampleDried && other.tag == "Fire") {
            progress += Time.fixedDeltaTime;

            if (progress >= 5) {
                state = State.Heated;
                progress = 0;
                progressBar.Value = 0;
                progressBar.Visible = false;
            } else {
                progressBar.Value = progress / 5f;
                progressBar.Visible = true;
            }
        }
    }
}
