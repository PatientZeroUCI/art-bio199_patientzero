using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseDisplay : MonoBehaviour
{
    public LogicBoardPhases LogicBoard;
    public Canvas textDisplay;
    public int phaseToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(LogicBoard.currentPhase == phaseToDisplay)
        {
            textDisplay.enabled = true;
        }
    }
}
