using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Component that checks what pieces of evidence contradict with each other.
    For instance, if a document contradicts with a gram strain, that information would be stored in this script in the list contradictoryEvidence.
    Contradictions are checked in LogicBoardController.cs
    
    Potential Issues:
        - Time-consuming to update every object that could go on the logic board with a list of contradictory items
*/
public class ContradictionRecorder : MonoBehaviour
{
    public List<GameObject> contradictoryEvidence;
    
    public bool DoesContradictionExist (GameObject obj)
    {
        return contradictoryEvidence.Contains(obj);
    }
}
