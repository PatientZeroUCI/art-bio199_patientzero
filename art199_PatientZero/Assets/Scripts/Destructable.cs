using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{

    public GameObject destroyedVersion;

    // Start is called before the first frame update
    // Update is called once per frame
    public void Shatter()
    {
        Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
