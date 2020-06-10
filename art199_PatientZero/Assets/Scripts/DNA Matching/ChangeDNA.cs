using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using VRTK;

public class ChangeDNA : MonoBehaviour
{
    private SpawnDNA dnaSpawner;
    private TextMeshPro strandBase;

    public VRTK_InteractableObject strand;
    

    protected void OnEnable()
    {
        dnaSpawner = gameObject.transform.parent.transform.parent.transform.parent.GetComponent<SpawnDNA>();
        strandBase = gameObject.transform.Find("Strand Base").GetComponent<TextMeshPro>();
        strand = GetComponent<VRTK_InteractableObject>();
        
        strand.InteractableObjectTouched += InteractableObjectTouched;
    }

    protected void OnDisable()
    {
        strand.InteractableObjectTouched -= InteractableObjectTouched;
    }

    protected virtual void InteractableObjectTouched(object sender, InteractableObjectEventArgs e)
    {
        // change strand unless DNA is solved...
        // Debug.Log("TOUCHED!");
        if (!dnaSpawner.puzzleSolved())
        {
            ChangeBase();
        }
    }

    // helpers

    // this is for debugging
    void Change()
    {
        if (strandBase.text == "G")
        {
            strandBase.text = "E";
        }

        else
        {
            strandBase.text = "G";
        }
    }

    void ChangeBase()
    {
        /* change base

        0 - G
        1 - C
        2 - A
        3 - T/U

        */
        if (strandBase.text == "G")
        {
            strandBase.text = "C";
        }

        else if (strandBase.text == "C")
        {
            strandBase.text = "A";
        }

        else if (strandBase.text == "A")
        {
            if (dnaSpawner.isDNA)
            {
                strandBase.text = "T";
            }
            else
            {
                strandBase.text = "U";
            }
        }

        else if (strandBase.text == "T" || strandBase.text == "U")
        {
            strandBase.text = "G";
        }
    }
}
