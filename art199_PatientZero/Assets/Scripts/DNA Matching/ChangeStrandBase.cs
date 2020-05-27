using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStrandBase : MonoBehaviour
{
    private MeshRenderer baseRenderer; // renderer component attached to DNA/RNA base 
    private Material originalMaterial; // original material

    [SerializeField]
    private Material selected;

    private void Start()
    {
        baseRenderer = gameObject.GetComponent<MeshRenderer>();
        originalMaterial = baseRenderer.material;
    }


    private void OnMouseOver()
    { 
        baseRenderer.material = selected; 
    }

    private void OnMouseExit()
    {
        baseRenderer.material = originalMaterial;
    }

    private void OnMouseDown()
    {
        TextMesh strandBase = gameObject.transform.Find("Strand Base").GetComponent<TextMesh>();

        if (strandBase.text == "A")
        {
            if (GameObject.Find("DNASpawner").GetComponent<SpawnDNA>().isRNA)
            {
                strandBase.text = "U";
            }

            else
            {
                strandBase.text = "T";
            }
        }

        else if (strandBase.text == "U" || strandBase.text == "T")
        {
            strandBase.text = "G";
        }

        else if (strandBase.text == "G")
        {
            strandBase.text = "C";
        }

        else if (strandBase.text == "C")
        {
            strandBase.text = "A";
        }
    }
}
