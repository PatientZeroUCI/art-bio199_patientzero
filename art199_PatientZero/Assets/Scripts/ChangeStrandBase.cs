using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStrandBase : MonoBehaviour
{
    [SerializeField]
    private Material selected;

    [SerializeField]
    private Material deselected;

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnMouseOver()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = selected; 

    }

    private void OnMouseExit()
    {
        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.material = deselected;
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
