using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineGameCellScript : MonoBehaviour
{
    public bool isHealthyCell;
    public GameObject bullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == bullet.name + "(Clone)") // This works but I feel like there's a 'safer' way to do this.
        {
            if (isHealthyCell)
            {
                Debug.Log("BAD SHOT: Shot healthy cell!");
            } 
            else
            {
                Debug.Log("GOOD SHOT: Shot infected cell!");
            }
        }
    }
}
