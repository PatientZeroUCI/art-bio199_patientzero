using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pipette : MonoBehaviour
{
    public GameObject contents = null;
    public VRTK_InteractableObject pipette;
    public AudioSource squirting;

    private GameObject hand;
    public VRTK_InteractUse controllerUse;

    // Spawns copies of the stored object

    void OnEnable()
    {
        hand = GameObject.Find("RightHand/Right");
        if (hand == null)
        {
            hand = GameObject.Find("Controller (right)/Right");
        }
        controllerUse = hand.GetComponent<VRTK_InteractUse>();
    }

    void Update()
    {
        if (pipette.IsGrabbed() && controllerUse.IsUseButtonPressed())
        {
            DropLiquid();
        }
        else
            squirting.Stop();
    }

    public void DropLiquid()
    {
        if (contents != null)
        {
            GameObject liquid = Instantiate(contents);
            liquid.transform.position = transform.position;
            liquid.SetActive(true);
            if (squirting.isPlaying)
            {

            }
            else
                squirting.Play();
        }
    }
}
