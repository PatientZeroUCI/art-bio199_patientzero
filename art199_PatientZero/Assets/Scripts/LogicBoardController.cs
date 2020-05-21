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
 */




public class LogicBoardController : MonoBehaviour
{

    Dictionary<GameObject, List<GameObject>> objects = new Dictionary<GameObject, List<GameObject>>();
    VRTK_SnapDropZone snapScript;
    public GameObject surf;
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        VRTK_SnapDropZone snapScript = this.gameObject.GetComponent<VRTK_SnapDropZone>();
        //make sure the object has the VRTK script attached... 

        /*if (GetComponent<VRTK_SnapDropZone>() == null)

        {

            Debug.LogError("LogicBoardController is required to be attached to an Object that has the VRTK_SnapDropZone script attached to it");

            return;

        }*/

        //GetComponent<VRTK_SnapDropZone>().ObjectSnappedToDropZone += new SnapDropZoneEventHandler(ObjectSnappedToDropZone);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void SnappedToCenter(object o, SnapDropZoneEventArgs e)
    {
        obj = e.snappedObject;
        List<GameObject> newList = new List<GameObject>();
        objects.Add(e.snappedObject, newList);
        
        //Destroy(surf);
        //List<GameObject> objs = snapScript.GetHoveringObjects();
        //Debug.Log(objs[0].name);
        //GameObject ob = snapScript.GetCurrentSnappedObject();


        //Debug.Log(o.name);
        //GameObject ob = GameObject.Find(obj.name);

        //objects.Add(ob, newList);
    }

    public void RemovedFromCenter(object o, SnapDropZoneEventArgs e)
    {
        objects.Remove(e.snappedObject);
    }

    public void AddToArea(object o, SnapDropZoneEventArgs e)
    {
        //check if something is in the center snap first
        if (objects.ContainsKey(obj)){
            objects[obj].Add(e.snappedObject);
            printdictionary();
        }

    }

    public void RemoveFromArea(object o, SnapDropZoneEventArgs e)
    {
        if (objects.ContainsKey(obj)){
            objects[obj].Remove(e.snappedObject);
            printdictionary();
        }

    }

    private void printdictionary()
    {
        /*
        string vals = "";
        objs = snapScript.GetHoveringObjects();
        foreach (GameObject ob in objs){
            vals += ob.name + " ";
        }
        Debug.Log(obj.name);
        Debug.Log(vals);
        */

        
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
