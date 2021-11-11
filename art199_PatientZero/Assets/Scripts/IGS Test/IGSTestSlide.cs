﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSTestSlide : MonoBehaviour {
    public enum State { Start, WaterAdded, SampleLoaded, SampleDried, Heated, DyeAdded, Washed, Done }

    public State state = State.Start;
    
    // progress depending on the different state
    // i.e. for state DyeAdded, tells how much dye has been added so far
    public float progress = 0;

    // whether the sample is gram positive or not
    public bool positive = false;

    ProgressBar progressBar = null;

    GameObject sample;

    private AIVoice aiVoice;

    void Start() {
        progressBar = GetComponentInChildren<ProgressBar>();
        progressBar.Visible = false;
        foreach (Transform child in transform) {
            if (child.CompareTag("IGSsample")) {
                sample = child.gameObject;
                break;
            }
        }
        sample.SetActive(false);
        aiVoice = FindObjectOfType<AIVoice>();
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
                tag = "GRAM";
                progress = 0;
                progressBar.Value = 0;
                progressBar.Visible = false;
            } else {
                progressBar.Value = progress / 10f;
                progressBar.Visible = true;
            }
        }
    }

    void OnTriggerEnter(Collider collision) {
        switch (state) {
            case State.Start:
                if (collision.gameObject.tag == "Water") {
                    UnityEngine.Debug.Log(":dsfiosadjf");
                    state = State.WaterAdded;
                    Destroy(collision.gameObject);

                    // Call aivoice voice line
                    aiVoice.ReadVoiceClip(67);
                }
                break;
            case State.WaterAdded:
                IGSscooperHP scooper = collision.gameObject.GetComponentInChildren<IGSscooperHP>();
                if (scooper != null && scooper.scoopCurrentHP == 0) {
                    sample.SetActive(true);
                    state = State.SampleLoaded;
                    positive = scooper.positive;

                    // Call aivoice voice line
                    aiVoice.ReadVoiceClip(69);
                }
                break;
            case State.Heated:
                if (collision.gameObject.tag == "IGS Dye") {
                    if (++progress >= 50) {
                        state = State.DyeAdded;
                        progress = 0;
                        progressBar.Value = 0;
                        progressBar.Visible = false;
                        sample.GetComponent<Renderer>().material = collision.gameObject.GetComponent<Renderer>().material;

                        // Call aivoice voice line
                        aiVoice.ReadVoiceClip(71);
                    } else {
                        progressBar.Value = progress / 50f;
                        progressBar.Visible = true;
                    }
                    Destroy(collision.gameObject);
                }
                break;
            case State.DyeAdded:
                if (collision.gameObject.tag == "Water") {
                    if (++progress >= 50) {
                        state = State.Washed;
                        progress = 0;
                        progressBar.Value = 0;
                        progressBar.Visible = false;

                        // Call aivoice voice line
                        aiVoice.ReadVoiceClip(72);
                    } else {
                        progressBar.Value = progress / 50f;
                        progressBar.Visible = true;
                    }
                    Destroy(collision.gameObject);
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

                // Call aivoice voice line
                aiVoice.ReadVoiceClip(70);
            } else {
                progressBar.Value = progress / 5f;
                progressBar.Visible = true;
            }
        }
    }
}
