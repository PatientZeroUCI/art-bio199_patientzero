using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionScript : MonoBehaviour
{
    public int cellCount = 0;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Infected")
        {
            cellCount++;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Healthy")
        {
            Debug.Log("HEALTHY RESET");
            other.gameObject.GetComponent<VirtualCell>().ResetDisplay();
        }
    }
}
