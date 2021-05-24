using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickInstantiate : MonoBehaviour
{
    // Spawns a prefab after start, basically done to bypass a thing where the bottles,
    // Look for a ahand component on the VRTK object, but the hand becomes a child during start,
    // so the bottles can't find it there, usually they are spawned by the toolstation so this isn't a problem
    // Unity weird

    public GameObject prefab;  //Prefab to spawn
    public GameObject parent;  // Obj it will be parented to

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Instantiate(prefab, gameObject.transform.position, gameObject.transform.rotation, parent.transform);

        Destroy(gameObject);

        //GameObject hand = GameObject.Find("RightHand/Right");
        //Debug.Log(hand);
    }
}
