using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    static public bool showTooltips = true;
    public TextMeshPro textTooltips;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void switchTooltips()
    {
        showTooltips = !showTooltips;
        textTooltips.text = (showTooltips) ? "On" : "Off";
    }
}
