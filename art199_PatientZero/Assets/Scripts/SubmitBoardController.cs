using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    // Stores a boolean if the board is able to be used, changed by EventSystem
    private bool canSubmit = false;
     
    private AIVoice aiVoice;

    // Puts the buttons into the dictionary by finding them by name
    void Start()
    {
        buttons = new Dictionary<GameObject, bool>();
        buttons.Add(GameObject.Find("Slot 1"), true);
        buttons.Add(GameObject.Find("Slot 2"), true);
        buttons.Add(GameObject.Find("Slot 3"), true);
        buttons.Add(GameObject.Find("Slot 4"), true);

        // Sunscribe to event
        Level1Events.current.onDNADone += AllowSubmissions;

        aiVoice = FindObjectOfType<AIVoice>();
    }

    // Toggles the button between active and not active when a player presses it
    // Every time a button is pressed it checks if the final submit button should
    // also be made active
    // Called by Interactable_Object_Unity_Events On Use
    public void toggleButton(GameObject button)
    {
        Debug.Log("help");
        Debug.Log(buttons[button]);
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

        if (canSubmit)
        {
            if (isSubmittable())
            {
                submitButton.GetComponent<Renderer>().material = shaders[1];
            }
            else
            {
                submitButton.GetComponent<Renderer>().material = shaders[0];
            }
        }
    }

    // Checks if the final submit button should be enabled by looking at the
    // boolean values for every button
    // Returns true if only one button is active
    private bool isSubmittable()
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

        return selectedCount == 1;
    }

    // When called, allows the submit button to be pressed
    public void AllowSubmissions()
    {
        Debug.Log("Submissions now allowed");
        canSubmit = true;
        //submitButton.GetComponent<Renderer>().material = shaders[0];

        if (isSubmittable())
        {
            submitButton.GetComponent<Renderer>().material = shaders[1];
        }
        else
        {
            submitButton.GetComponent<Renderer>().material = shaders[0];
        }
    }

    // Checks that the correct answer is submitted
    // Returns to the title screen if the correct answer was chose
    public void submit()
    {
        if (canSubmit && isSubmittable())
        {
            if (buttons[GameObject.Find("Cube.001")] == true)
            {
                //aiVoice.ReadVoiceClip(74);
                Debug.Log("Correct answer! Returning to title screen.");
                StartCoroutine(loadTitleScene());
            }
            else
            {
                //aiVoice.ReadVoiceClip(73);
                Debug.Log("Incorrect answer");
                //SceneManager.LoadScene("Wrap Up");
            }
        }
    }

    // Waits for 5 seconds before returning to the title screen
    IEnumerator loadTitleScene()
    {
        // Wait for 5 seconds and then load the title scene
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Title Scene");
    }
}