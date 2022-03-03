using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MicroscopeDisplay : MonoBehaviour
{
    public VRTK.VRTK_SnapDropZone microscope_zone;
    public GameObject bacteria;
    public GameObject gram_result;
    public GameObject cellProjections;
    public Printer evidencePrinter;

    private bool printed;
    private AIVoice aiVoice;

    // Start is called before the first frame update
    void Start()
    {
        aiVoice = FindObjectOfType<AIVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject snapped_object = microscope_zone.GetCurrentSnappedObject();

        if ( snapped_object != null)
        {
            if (snapped_object.tag == "DNA")
            {
                bacteria.SetActive(true);
                Level1Events.current.PetriInsertedInMicroscope();
                aiVoice.ReadVoiceClip(76);
            }
            else if (snapped_object.tag == "Tool")
            {
                // Fixes the orientation of the tweezers and slide
                snapped_object.transform.rotation = Quaternion.Euler(-90.0f, 0.0f, -6.0f);
                snapped_object.transform.position = new Vector3(8.18f, 1.73f, -0.3f);

                // Checks to ensure that the IGS test has been completed before displaying results                
                Transform slide = snapped_object.transform.Find("Slide");
                IGSTestSlide slideScript = slide.GetComponent<IGSTestSlide>();
                if (slideScript.state == IGSTestSlide.State.Done)
                {
                    gram_result.SetActive(true);
                    Level1Events.current.SlideInsertedInMicroscope();
                } 
                //evidencePrinter.PrintIGS();
            }
            else if (snapped_object.GetComponent<PCRTestSlide>() != null && snapped_object.GetComponent<PCRTestSlide>().virusLoaded)
            {
                cellProjections.SetActive(true);   
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
