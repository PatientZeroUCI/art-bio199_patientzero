using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


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
 */




public class LogicBoardController : MonoBehaviour
{

    Dictionary<GameObject, List<GameObject>> objects = new Dictionary<GameObject, List<GameObject>>();
    VRTK_SnapDropZone snapScript;

    // These will need to be changed to have multiple snap zones
    GameObject obj;
    GameObject line;


    public GameObject LinePrefab;

    // Start is called before the first frame update
    void Start()
    {
        VRTK_SnapDropZone snapScript = this.gameObject.GetComponent<VRTK_SnapDropZone>();

    }



    public void SnappedToCenter(object o, SnapDropZoneEventArgs e)
    {
        obj = e.snappedObject;
        List<GameObject> newList = new List<GameObject>();
        objects.Add(e.snappedObject, newList);

    }

    public void RemovedFromCenter(object o, SnapDropZoneEventArgs e)
    {
        objects.Remove(e.snappedObject);
        if (line != null)
        {
            Destroy(line);
        }
    }

    public void AddToArea(object o, SnapDropZoneEventArgs e)
    {
        if (objects.ContainsKey(obj)){
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

    public void RemoveFromArea(object o, SnapDropZoneEventArgs e)
    {
        if (objects.ContainsKey(obj)){
            objects[obj].Remove(e.snappedObject);
            printdictionary();
            Destroy(line);
        }

    }

    private void printdictionary()
    {
        string vals = "";
        foreach (GameObject ob in objects[obj])
        {
            vals += ob.name;
            vals += " ";
        }
        Debug.Log("Center: " + obj.name);
        Debug.Log("Area: " + vals);
        
    }
}
