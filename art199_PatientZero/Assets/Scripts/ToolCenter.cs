using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCenter : MonoBehaviour
{
    public GameObject surface;
    public Transform spawnLoc;
    public float speed;
    public Transform surfacePos;
    public GameObject toSpawn;
    Rigidbody rb;
    bool spawned = false;
    bool spawningAlready = false;

    public float delay;


    // Start is called before the first frame update
    void Start()
    {
        rb = surface.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (spawned == true)
        {
            float step = speed * Time.deltaTime;
            surface.transform.position = Vector3.MoveTowards(surface.transform.position, surfacePos.position, step);
            if (surface.transform.position == surfacePos.position)
            {
                spawned = false;
                spawningAlready = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Tool"){
            Destroy(collision.gameObject);
        }

    }

    public void dropSurface()
    {
        if (spawningAlready == false)
        {
            rb.isKinematic = false;
            StartCoroutine(MyCoroutine());
            spawningAlready = true;
        }

    }

    IEnumerator MyCoroutine()
    {

        yield return new WaitForSeconds(delay);

        surface = Instantiate(toSpawn, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        rb = surface.GetComponent<Rigidbody>();
        spawned = true;

    }


}
