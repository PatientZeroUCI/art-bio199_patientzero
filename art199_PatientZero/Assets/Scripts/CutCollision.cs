using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutCollision : MonoBehaviour
{
    public int CollisionNumber;
    public CuttingScript cuttingHitbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "ScalpelBlade")
        {
            //Debug.Log("InteriorCollider Hit!");
            cuttingHitbox.HitCollider(CollisionNumber);
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }
    }
}
