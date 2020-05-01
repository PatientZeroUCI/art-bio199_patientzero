using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGSTestSlide : MonoBehaviour {
    public enum State { Start, WaterAdded, SampleLoaded, SampleDried, Heated, DyeAdded, Washed }

    public State state = State.Start;
    
    // progress depending on the different state
    // i.e. for state DyeAdded, tells how much dye has been added so far
    public int progress = 0;

    void OnCollisionEnter(Collision collision) {
        switch (state) {
            case State.Start:
                WaterDrop water;
                if ((water = collision.gameObject.GetComponent<WaterDrop>()) != null) {
                    state = State.WaterAdded;
                }
                break;
            case State.WaterAdded:
                // add sample
                break;
            case State.SampleDried:
                // heat up
                break;
            case State.Heated:
                IGSDye dye;
                if ((dye = collision.gameObject.GetComponent<IGSDye>()) != null) {
                    if (++progress >= 60) {
                        state = State.DyeAdded;
                        progress = 0;
                    }
                }
                break;
            case State.DyeAdded:
                if ((water = collision.gameObject.GetComponent<WaterDrop>()) != null) {
                    if (++progress >= 60) {
                        state = State.Washed;
                        progress = 0;
                    }
                }
                break;
        }
    }
}
