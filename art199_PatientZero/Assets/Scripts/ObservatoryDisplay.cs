using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ObservatoryDisplay : MonoBehaviour
{
    public GameObject observatory_hologram;
    public GameObject tutorialDiagram;
    public AudioSource voiceOverInstructions;

    public void WaitDisplay()
    {
        StartTutorial();
        StartCoroutine(SleepDisplay());
    }

    private void StartTutorial()
    {
        tutorialDiagram.SetActive(true);
        voiceOverInstructions.gameObject.SetActive(true);
    }

    IEnumerator SleepDisplay()
    {
        //Anything that needs to be "loaded in" can be placed after the wait. 
        yield return new WaitForSeconds(3.0f);
        observatory_hologram.SetActive(true);
    }
}
