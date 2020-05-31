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
 */


class LBSnapZone
{
    Dictionary<GameObject, List<GameObject>> objects = new Dictionary<GameObject, List<GameObject>>();

    public GameObject obj;
    public GameObject line;



    public GameObject LinePrefab;

    // Start is called before the first frame update

    public void SnappedToCenter(object o, SnapDropZoneEventArgs e)
    {
        obj = e.snappedObject;
        List<GameObject> newList = new List<GameObject>();
        objects.Add(e.snappedObject, newList);
        printdictionary();
    }

    public void RemovedFromCenter(object o, SnapDropZoneEventArgs e)
    {
        objects.Remove(e.snappedObject);
        //if (line != null)
        //{
        //    Destroy(line);
        //}
        printdictionary();
    }
    /*
    public void AddedToArea(object o, SnapDropZoneEventArgs e)
    {
        if (objects.ContainsKey(obj))
        {
            objects[obj].Add(e.snappedObject);

            line = Instantiate(LinePrefab, obj.transform.position, Quaternion.identity);
            LineRenderer lr = line.GetComponent<LineRenderer>();
            Vector3[] points = { obj.transform.position, e.snappedObject.transform.position };
            lr.SetPositions(points);
            Vector3 v = new Vector3(0f, 0f, 0.15f);
            line.transform.position = v;
            printdictionary();
        }

    }

    public void RemovedFromArea(object o, SnapDropZoneEventArgs e)
    {
        if (objects.ContainsKey(obj))
        {
            objects[obj].Remove(e.snappedObject);
            printdictionary();
            Destroy(line);
        }

    }
    */
    private void printdictionary()
    {
        string vals = "";
        foreach (GameObject ob in objects[obj])
        {
            vals += ob.name;
            vals += " ";
        }
        UnityEngine.Debug.Log("Center: " + obj.name);
        UnityEngine.Debug.Log("Area: " + vals);

    }
}











public class LogicBoardController : MonoBehaviour
{
    List<LBSnapZone> lbSnapZones;

    public int numberofSnapZones = 2;



    void Start()
    {
        lbSnapZones = new List<LBSnapZone>();
        for (int i = 0; i < numberofSnapZones; i++)
            lbSnapZones.Add(new LBSnapZone() { obj = null, line = null });
    }
    
    public void snappedToAnyCenter(object o, SnapDropZoneEventArgs e)
    {
        string callingFuncName = new StackFrame(2).GetMethod().Name;
        UnityEngine.Debug.Log(callingFuncName);
        LBSnapZone toChange = lbSnapZones[0];
        int snapNumber = 1;
        for (int i = 0; i < numberofSnapZones; i++)
        {
            if (lbSnapZones[i].obj == null)
            {
                toChange = lbSnapZones[i];
                snapNumber = i+1;
                break;
            }
        }

        e.snappedObject.tag = "Snap" + snapNumber.ToString();
        toChange.SnappedToCenter(o, e);

    }

    void removedFromAnyCenter(object o, SnapDropZoneEventArgs e)
    {

        LBSnapZone toChange = lbSnapZones[0];
        int snapNumber = 1;
        for (int i = 0; i < numberofSnapZones; i++)
        {
            if (lbSnapZones[i].obj.tag == e.snappedObject.tag)
            {
                toChange = lbSnapZones[i];
                snapNumber = i+1;
                break;
            }
        }

        // TO CHANGE TO WHATEVER POLICY LIST IS
        e.snappedObject.tag = "Tool";
        toChange.RemovedFromCenter(o, e);
    }
    /*
    void addedToAnyArea(object o, SnapDropZoneEventArgs e)
    {

        LBSnapZone toChange = lbSnapZones[0];
        int snapNumber = 1;
        for (int i = 0; i < numberofSnapZones; i++)
        {
            if (lbSnapZones[i].obj == null)
            {
                toChange = lbSnapZones[i];
                snapNumber = i+1;
                break;
            }
        }

        e.snappedObject.tag = "Snap" + snapNumber.ToString();
        toChange.addedToArea(o, e);
    }
    */
}
