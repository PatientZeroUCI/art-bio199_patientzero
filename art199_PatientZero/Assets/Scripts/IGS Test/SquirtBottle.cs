using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SquirtBottle : MonoBehaviour
{
    [SerializeField] GameObject contents = null;
    public AudioSource squirtSound;
    public AudioClip [] bottleClip;

    public VRTK_InteractableObject bottle;
    public VRTK_InteractUse controllerUse;

    void Start() {
        GameObject hand = GameObject.Find("RightHand/Right");
        if (hand == null)
        {
            hand = GameObject.Find("Controller (right)/Right");
        }
        controllerUse = hand.GetComponent<VRTK_InteractUse>();
    }

    float squirting = 0;

    bool yoink = true;

    private void Update()
    {
        if (bottle.IsGrabbed() && yoink) {
            int clipNum = Random.Range(1,4); //picks a random number between 1 and 3
            squirtSound.clip = bottleClip[clipNum];
            squirtSound.pitch = 1.3f;
            squirtSound.volume = 0.75f;
            squirtSound.Play();
            yoink = false;
        }
        else if (!bottle.IsGrabbed() && !yoink) {
            yoink = true;
        }
        if (bottle.IsGrabbed() && controllerUse.IsUseButtonPressed()) {
            if (squirtSound.clip != bottleClip[0]) {
                if (squirtSound.isPlaying) {
                    squirtSound.Stop();
                }
            }
            if (squirting <= 0 ) {
                squirting = 1;
                if (!squirtSound.isPlaying) {
                    squirtSound.clip = bottleClip[0];
                    squirtSound.pitch = 1.8f;
                    squirtSound.volume = 0.6f;
                    squirtSound.Play();
                }
            }
        } else if (squirting > 0.2f) {
            squirting = 0.2f;
            if (squirtSound.isPlaying) {
                squirtSound.Stop();
            }
        }

        if (squirting > 0.2f)
        {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
            //if (squirtSound.isPlaying)
            //{
            //    //squirtSound.PlayScheduled(.3f);
            //}
            //else
            //    squirtSound.Play();
        }
        else
        {
            //squirtSound.Stop();
        }

        squirting -= Time.deltaTime;
    }
}
