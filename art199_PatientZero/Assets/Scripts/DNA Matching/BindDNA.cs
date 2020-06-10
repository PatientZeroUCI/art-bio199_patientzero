using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using TMPro;

// this attaches to a DNA "half"

public class BindDNA : MonoBehaviour
{
    // non-function members
    private Vector3 target;
    SpawnDNA spawner;

    private bool CanBind;

    // functions
    private void Start()
    {
        Vector3 DNAMidpoint = gameObject.transform.parent.position;
        Vector3 DNAHalf = gameObject.transform.position;

        // we use DNAHalf.y because DNA prefab's pivot is in the middle rather than bottom like the DNA halves
        target = new Vector3(DNAMidpoint.x, DNAHalf.y, DNAMidpoint.z);  
        CanBind = false;

        spawner = gameObject.transform.parent.GetComponentInParent<SpawnDNA>();
    }

    private void Update()
    {
        CanBind = spawner.puzzleSolved();
        Bind();
    }

    // helpers
    private void DisableHighlightsAndText()
    {
        VRTK_InteractObjectHighlighter[] highlighters = gameObject.GetComponentsInChildren<VRTK_InteractObjectHighlighter>();
        TextMeshPro[] bases = gameObject.GetComponentsInChildren<TextMeshPro>();

        for (int i = 0; i < bases.Length; ++i)
        {
            if (gameObject.name == "Right DNA")
            {
                Destroy(highlighters[i]);
            }
            Destroy(bases[i]);
        }
    }

    private void Bind()
    {
        bool strandsNotConnected = Mathf.Abs(gameObject.transform.localPosition.x) >= 1.80f;

        if (CanBind && strandsNotConnected)
        {
            DisableHighlightsAndText();
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, 0.01f);
        }
    }
    

   
}
