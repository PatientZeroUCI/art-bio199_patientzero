using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using System.Diagnostics;


/* NOTES
 * 
 * VRTK_POLICYLIST
 *      Preferably find some way to include this in one place and use it in snapzone script, instead of having a separate copy of the policy list in every gameobject
 *      Wait now testing with Brendan's scene, I don't think I even needed this to get snapping to work
 * Cannot snap multiple things to the same area
 * 
 * 
 * Now have multiple snap zones, which add to dictionary
 * 
 * Items around fall off when center removed
 * 
 * 
 * 
 * Need a way to control multiple snapzone sections at once
 *      Was considering the use of parent.getsnappedobject but doesnt work
 *      Can easily do this by making multiple scripts of the same thing, but wouldn't that be bad practice?
 *      Considered making a class of all the below information/code, but would still need access to exactly which snapzone was used
 *      
 *      
 *      MAKE THIS A CLASS, HAVE OUTSIDE SCRIPT WITH ADD/REMOVE FUNCTIONS FOR EVERY AREA
 *      
 *      
 *      
 *      
 * Try public gameobject to differentiate different snapzones, using the same script
 */

public class LogicBoardController : MonoBehaviour
{

    public GameObject centerSnapped;
    public GameObject LinePrefab;
    public int areaAmount = 2;
    private VRTK_PolicyList validObjects = null; // Policy list used to see if the object attached to the SnapZone is valid or not

    List<List<GameObject>> areaObjects = new List<List<GameObject>>();

    private AIVoice aiVoice;

    void Start()
    {
        for(int i = 0; i < areaAmount; i++)
        {
            List<GameObject> object_and_line = new List<GameObject>();
            areaObjects.Add(object_and_line);
        }
        aiVoice = FindObjectOfType<AIVoice>();
        validObjects = this.GetComponent<VRTK_PolicyList>();
    }


    public void SnappedToCenter(object o, SnapDropZoneEventArgs e)
    {
        centerSnapped = e.snappedObject;
        if (validObjects.Find(e.snappedObject))
        {
            aiVoice.ReadVoiceClip(3); // Incorrect placement on the logic board
        }
        else
        {
            aiVoice.ReadVoiceClip(2); // Correct placement on the logic board
        }
        printObjects();
    }

    public void RemovedFromCenter(object o, SnapDropZoneEventArgs e)
    {
        centerSnapped = null;
        foreach (List<GameObject> areaZone in areaObjects)
        {
            if (areaZone.Count != 0)
            {
                Destroy(areaZone[1]);
                areaZone.Clear();
            }

        }
        printObjects();
    }
    
    public void AddedToArea(object o, SnapDropZoneEventArgs e)
    {
        foreach (List<GameObject> areaZone in areaObjects)
        {
            if (areaZone.Count == 0)
            {
                areaZone.Add(e.snappedObject);

                GameObject line = Instantiate(LinePrefab, centerSnapped.transform.position, Quaternion.identity);
                LineRenderer lr = line.GetComponent<LineRenderer>();
                Vector3[] points = { centerSnapped.transform.position, e.snappedObject.transform.position };
                lr.SetPositions(points);
                Vector3 v = new Vector3(0f, 0f, 0.15f);
                line.transform.position = v;

                areaZone.Add(line);
                break;
            }
        }
        if (!validObjects.Find(e.snappedObject))
        {
            aiVoice.ReadVoiceClip(2); // Correct placement on the logic board
        }
        else
        {
            aiVoice.ReadVoiceClip(3); // Incorrect placement on the logic board
        }
        CheckObjects(centerSnapped, e.snappedObject);
    }

    public void RemovedFromArea(object o, SnapDropZoneEventArgs e)
    {
        foreach (List<GameObject> areaZone in areaObjects)
        {
            if (areaZone.Count != 0 && areaZone[0] == e.snappedObject)
            {
                Destroy(areaZone[1]);
                areaZone.Clear();
                break;
            }
        }

        printObjects();

    }
    
    // Check the objects added to the snapzones for any contradictions
    private void CheckObjects(GameObject obj1, GameObject obj2)
    {
        ContradictionRecorder contradictionList1 = obj1.GetComponent<ContradictionRecorder>();
        ContradictionRecorder contradictionList2 = obj2.GetComponent<ContradictionRecorder>();
        
        if (contradictionList1 == null && contradictionList2 == null) return;
   
        if ((contradictionList1 != null && contradictionList1.DoesContradictionExist(obj2)) || (contradictionList2 != null && contradictionList2.DoesContradictionExist(obj1)))
        {
            aiVoice.ReadVoiceClip(1);// Contradictory evidence -- will not trigger if one of the pieces of evidence is not in the center
            // (ex. if A is connected to B, and B is connected to C, even if A and C contradicteach other, this line will not fire.)
        }
    }
    
    private void printObjects()
    {
        string vals = "";
        foreach (List<GameObject> areaZone in areaObjects)
        {
            if (areaZone.Count != 0 && areaZone[0] != null)
            {
                vals += areaZone[0].name;
                vals += " ";
            }

        }

        if (centerSnapped != null)
        {
            UnityEngine.Debug.Log("Center: " + centerSnapped.name);
        }
        else
        {
            UnityEngine.Debug.Log("Center: ");
        }
        UnityEngine.Debug.Log("Area: " + vals);

    }
}
