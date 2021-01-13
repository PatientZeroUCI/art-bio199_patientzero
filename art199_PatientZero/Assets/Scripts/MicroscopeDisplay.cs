using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroscopeDisplay : MonoBehaviour
{
    public VRTK.VRTK_SnapDropZone microscope_zone;
    public GameObject bacteria;
    public GameObject gram_result;
    public Printer evidencePrinter;
    private bool printed;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        GameObject snapped_object = microscope_zone.GetCurrentSnappedObject();

        if ( snapped_object != null)
        {
            if(snapped_object.tag == "DNA")
            {
                bacteria.SetActive(true);
            }
            else if(snapped_object.tag == "GRAM")
            {
                gram_result.SetActive(true);
                //evidencePrinter.PrintIGS();
            }
        }
        else
        {
            if (bacteria.activeSelf)
            {
                bacteria.SetActive(false);
            }
            else if (gram_result.activeSelf)
            {
                gram_result.SetActive(false);
            }
        }
    }

}
