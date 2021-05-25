using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;
using VRTK.UnityEventHelper;

public class LockedButton : MonoBehaviour
{
    public LogicBoardPhases LogicBoard;
    public Canvas textDisplay;
    public int phaseToDisplay;
    public VRTK_BaseControllable_UnityEvents ButtonEvents;
    public GameObject toolStation;  // a reference to the toolstation to chaneg the surface of

    private AIVoice aiVoice;

    void Start()
    {
        aiVoice = FindObjectOfType<AIVoice>();
        ButtonEvents.enabled = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (LogicBoard.currentPhase == phaseToDisplay)
        {
            textDisplay.enabled = true;
        }
    }


    // Given an int index, will activate that surface on the Toolstation
    // Should be called by the On Max Limit Reached on the VRTK_BaseControllable_UnityEvents component on the physics pusher child of the button
    public void ChangeToolStation(int index)
    {

        if (LogicBoard.currentPhase >= phaseToDisplay)
        {
            toolStation.GetComponent<ToolCenter>().dropSurface(index);
        }

        else
        {
            //Play ai audio coice clip saying this option is locked
            aiVoice.ReadVoiceClip(80);
        }
    }
}
