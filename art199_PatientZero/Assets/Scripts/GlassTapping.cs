using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTapping : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void onCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.tag == "Tool")
        // {
        //     audioSource.Play();
        //     Debug.Log("collided!");
        // }
        Debug.Log("collided!");
    }

}
