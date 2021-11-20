using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK;
public class Hint : MonoBehaviour
{
    ///This class is attached onto VRTK objects, displaying hints above the vrtk object when grabbed.
    ///Conditions for usage: There must be a gameobject with TextMeshPro in the scene, with the tag "Hint". This gameobject will be repositioned/edited by this script.
    public string hintInfo  = "Temporary string";
    private GameObject textObj;
    private TextMeshPro text;
    private MeshRenderer textDisplay;
    private Transform parent;
    private Transform focus;
    private Vector3 offset =new Vector3(0, 0.45f, 0);
    private VRTK_InteractableObject vrtkObject;
    private bool isDisplayed = false; //bool is used to know when to change text/visibility
    private Settings settingmenu;
    void Awake()
    {
        textObj = GameObject.FindGameObjectWithTag("Hint");
        text = textObj.GetComponent<TextMeshPro>();
        textDisplay = textObj.GetComponent<MeshRenderer>();
        parent = this.transform;
        focus = GameObject.FindGameObjectWithTag("MainCamera").transform;
        vrtkObject = this.GetComponent<VRTK_InteractableObject>();
    }

    void Update()
    {
        if (!Settings.showTooltips)
        {
            return;
        }
        if (vrtkObject.IsGrabbed())
        {
            HintPosition();
            if (!isDisplayed){
                NewHint(hintInfo);
            }
        }

        else
        {
            if (isDisplayed)
            {
                HideHint();
            }
        }
    }
    private void NewHint(string message)
    {
        //Changes the text of the hint, then makes it visible
        isDisplayed = true;
        text.text = message;
        textDisplay.enabled = true;
        text.transform.GetComponentInChildren<SpriteRenderer>().enabled = true; //may change later
    }
    private void HideHint()
    {
        //Makes text invisible
        isDisplayed = false;
        textDisplay.enabled = false;
        text.transform.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
    private void HintPosition()
    {
        //updates the position of the hint object
        textObj.transform.position = parent.position + offset;
        textObj.transform.LookAt(2 * textObj.transform.position - focus.position);
    }
}
