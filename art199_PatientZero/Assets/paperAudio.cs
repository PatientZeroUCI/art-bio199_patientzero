using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class paperAudio : MonoBehaviour
{
    public AudioSource paperSound;

    public VRTK_InteractableObject paper;

    bool yoink;

    // Start is called before the first frame update
    void Start()
    {
        yoink = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (paper.IsGrabbed() && yoink) {
            paperSound.Play();
            yoink = false;
        }
        else if (!paper.IsGrabbed() && !yoink) {
            yoink = true;
        }
    }
}
