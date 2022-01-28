using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSubmissionController : MonoBehaviour
{
    public List<GameObject> buttons;
    public bool[] buttonsPressed = { false, false, false, false };

    void toggleButton(GameObject button)
    {
        button.SetActive(false);
    }

    bool isSubmittable()
    {
        int pressedCount = 0;
        foreach (bool pressed in buttonsPressed)
        {
            if (pressed)
            {
                pressedCount++;
            }
        }
        return pressedCount > 1;
    }
}