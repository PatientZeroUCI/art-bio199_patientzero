using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;
using VRTK.UnityEventHelper;

public class PhaseDisplay : MonoBehaviour
{
    public LogicBoardPhases LogicBoard;
    public Canvas textDisplay;
    public int phaseToDisplay;
    public VRTK_BaseControllable_UnityEvents ButtonEvents;

    // Update is called once per frame
    void Update()
    {
        if(LogicBoard.currentPhase == phaseToDisplay)
        {
            ButtonEvents.enabled = true;
            textDisplay.enabled = true;
        }
    }

    // For voice clips when button is locked, use the LockedButton script
}
