using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for the submission board
// Includes functions that control each button and the board as a whole
public class SubmitBoardController : MonoBehaviour
{
    // Stores each button mapped to a bool to determine if the
    // button has been set active by the player
    private Dictionary<GameObject, bool> buttons;
    // Stores the submission button
    public GameObject submitButton;
    // Stores the red and green shaders that the buttons switch between
    public Material[] shaders;
    private bool canSubmit = false;

    // Puts the buttons into the dictionary by finding them by name
    void Start()
    {
        buttons = new Dictionary<GameObject, bool>();
        buttons.Add(GameObject.Find("Cube.001"), false);
        buttons.Add(GameObject.Find("Cube.002"), false);
        buttons.Add(GameObject.Find("Cube.003"), false);
        buttons.Add(GameObject.Find("Cube.004"), false);

        // Sunscrive to event
        Level1Events.current.onEvidenceDone += AllowSubmissions;
    }

    // Toggles the button between active and not active when a player presses it
    // Every time a button is pressed it checks if the final submit button should
    // also be made active
    // Called by Interactable_Object_Unity_Events On Use
    public void toggleButton(GameObject button)
    {
        if (buttons[button] == true)
        {
            buttons[button] = false;
            button.GetComponent<Renderer>().material = shaders[0];
        }
        else
        {
            buttons[button] = true;
            button.GetComponent<Renderer>().material = shaders[1];
        }

        if (isSubmittable())
        {
            submitButton.GetComponent<Renderer>().material = shaders[1];
        }
        else
        {
            submitButton.GetComponent<Renderer>().material = shaders[0];
        }
    }

    // Checks if the final submit button should be enabled by looking at the
    // boolean values for every button
    // Returns true if only one button is active
    bool isSubmittable()
    {
        if (canSubmit == false)
        {
            return false;
        }

        int selectedCount = 0;

        foreach (GameObject button in buttons.Keys)
        {
            if (buttons[button] == true)
            {
                selectedCount += 1;
            }
        }

        if (selectedCount == 1)
        {
            Debug.Log("finish");
        }
        return selectedCount == 1;
    }

    // When called, allows the submit button to be pressed
    void AllowSubmissions()
    {
        Debug.Log("dsaijahcdsunauhvecfdnijvefsanijuecfdra");
        canSubmit = true;
    }
}