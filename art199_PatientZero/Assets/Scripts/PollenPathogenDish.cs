using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenPathogenDish : MonoBehaviour
{
    public int itemsToCollect = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (itemsToCollect == 0) { return; }

        if (collision.gameObject.name == "Pathogen")
        {
            collision.gameObject.name = "Pathogen Collected"; // HACK
            Destroy(collision.gameObject);
            itemsToCollect -= 1;
        }
    }
}
