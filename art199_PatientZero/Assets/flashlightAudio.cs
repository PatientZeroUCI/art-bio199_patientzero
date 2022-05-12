using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class flashlightAudio : MonoBehaviour
{
    public AudioSource flashlightSound;
    public AudioClip [] flashlightClips;
    public AudioClip toggleSFX;

    public VRTK_InteractableObject flashlight;

    bool yoink;

    // Start is called before the first frame update
    void Start()
    {
        yoink = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (flashlight.IsGrabbed() && yoink) {
            int clipNum = Random.Range(0,2); //picks a random number between 1 and 3
            flashlightSound.clip = flashlightClips[clipNum];
            flashlightSound.Play();
            yoink = false;
        }
        else if (!flashlight.IsGrabbed() && !yoink) {
            yoink = true;
        }
    }

    public void flashlightToggleSFX() {
        flashlightSound.clip = toggleSFX;
        flashlightSound.Play();
    }
}
