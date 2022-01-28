using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LogicBoardPhases : MonoBehaviour
{
    public GameObject board_zones;
    //public List<GameObject> test;

    private List<List<GameObject>> phases = new List<List<GameObject>>();
    public int currentPhase;

    // Used to keep track of how long the player spends on a phase, used for the AI line when you spend too long on a certain phase
    private float timer = 0;
    public float secondForVoiceClip = 600;  // Number of seconds until voice clip plays
    private AIVoice aiVoice;

    private void Start()
    {
        for(int i = 0; i < board_zones.transform.childCount; i++) //need to populate Phases list of lists
        {
            phases.Add(new List<GameObject>());
            GameObject phaseZoneParent = board_zones.transform.GetChild(i).GetChild(0).GetChild(0).gameObject; // grab the current Parent Zone game object
            phases[i].Add(phaseZoneParent); // add parent to count for phases (base fill counts)

            int phaseZones = phaseZoneParent.transform.childCount; //assigns the number of snap zones (children) for this phase
            //Debug.Log("Phase " + i + " has " + phaseZones + " children." ); //check number of zones
            for (int j = 0; j < phaseZones; j++)
            {
                GameObject childZone = phaseZoneParent.transform.GetChild(j).gameObject;
                if (childZone.tag == "SnapZone") //loop through each child object of the snapzone parent, exclude VRTK highlighter for zone
                {
                    phases[i].Add(childZone.gameObject);
                }
            }
        }
        //test = phases[1];
        currentPhase = 0;


        // Set the timer so that it equals the nubmer of seconds times the amount of fixed frames in a second so that incrementing it in fixedUpdate works
        aiVoice = FindObjectOfType<AIVoice>();
        secondForVoiceClip = secondForVoiceClip / Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        bool phase_finished = false;
        for(int i = 0; i < phases[currentPhase].Count; i++)
        {
            VRTK_SnapDropZone phaseSnapZone = phases[currentPhase][i].GetComponent<VRTK_SnapDropZone>(); //select the current snap zone from the phase we are in.
            if (phaseSnapZone.GetCurrentSnappedObject() == null)
            {
                break;
            }
            if(i == phases[currentPhase].Count-1)
            {
                phase_finished = true;
                currentPhase += 1;

                // IGS phase start
                if (currentPhase == 1)
                {
                    // Describe first step of IGS test
                    aiVoice.AddClipToQueue(66);  // Add voice to queue 
                    Level1Events.current.EvidenceDone();
                }
                // DNA start
                else if (currentPhase == 2)
                {
                    // Describe first step of IGS test
                    Debug.Log("DNA START");
                }
                else
                {
                    Debug.Log(currentPhase);
                }
                

                // Reset timer for the Ai telling the player that they've been on a pahse for too long, since this is when they finisha  phase
                timer = 0;
            }
        }
    }

    void FixedUpdate()
    {
        timer += 1;

        if (secondForVoiceClip <= timer)
        {
            // Call aivoice voice line telling player they're taking a while
            aiVoice.ReadVoiceClip(81);
            timer = 0;

            //Debug.Log("test");
        }
    }
}
