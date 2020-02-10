using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Kevin Huang
//Last edited: Feburary 10th, 2020

//Since we are developing a virtual reality game, we are using...
//  the VRTK framework to assist in development. We need to import their
//  code in order to use it in our project.
using VRTK;         

/*
 * This script is meant to help the player quickly turn their camera
 * For example, if they hit the turn button, they turn about 45 degrees.
 * If they hold it, they turn as long as they are holding the button.
 * 
 * This prevents them from getting motion-sick
 */

public class QuickTurn : MonoBehaviour
{
    //Theroretically, we should be able to turn the player's view by simply
    //  rotating the transform of the VR Camera component

    //public Transform cameraTransform = VRTK_DeviceFinder.HeadsetCamera();


    [SerializeField]
    private Transform player;

    [SerializeField]
    private int quickTurnAmount = 45;

    // Update is called once per frame
    void Update()
    {
        processKeyboardInput();
    }

    void processKeyboardInput()
    {
        //To process input, we will initially test using a keyboard
        //Eventually though, we want to use the headset's controls...

        if (Input.GetKeyDown("q"))
        {
            turnSetAmount(quickTurnAmount);
        }

        else if (Input.GetKeyDown("e"))
        {
            turnSetAmount(quickTurnAmount);
        }

        else if (Input.GetKeyDown("r"))
        {
            turnSetAmount(180);
        }
        
      
       //we need like a new axis exclusively for moving the player
       //because this conflicts with the existing arrow keys...
        player.Rotate(0, Input.GetAxis("Horizontal"), 0);
        
        
    }

    //makes the player rotate x degrees using player.Rotate
    void turnSetAmount(int degree)
    {
        player.Rotate(0, degree, 0);
    }

    void buttonHeldTurn()
    {
        
    }
}
