using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SquirtBottle : MonoBehaviour
{
    [SerializeField] GameObject contents = null;
    public AudioSource squirtSound;

    public VRTK_InteractableObject bottle;
    public VRTK_InteractUse controllerUse;

    void Start() {
        controllerUse = GameObject.Find("RightHand/Right").GetComponent<VRTK_InteractUse>();
    }

    float squirting = 0;

    private void Update()
    {
        if (bottle.IsGrabbed() && controllerUse.IsUseButtonPressed()) {
            if (squirting <= 0) {
                squirting = 1;
                squirtSound.Play();
            }
        } else if (squirting > 0.2f) {
            squirting = 0.2f;
            squirtSound.Stop();
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
