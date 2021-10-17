using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionButton : MonoBehaviour
{
    // Script used to change the text displayed on the captions button in the settings, from on to off and vice versa

    public TextMesh captionsText;

    private void Start()
    {
        captionsText = GetComponent<TextMesh>();
    }

    public void turnTextToOn()
    {
        captionsText.text = "On";
    }

    public void turnTextToOff()
    {
        captionsText.text = "Off";
    }

}
