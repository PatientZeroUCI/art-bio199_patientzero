using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCenter : MonoBehaviour
{
    public GameObject currSurface;
    public GameObject surface1;
    public GameObject surface2;
    
    public Transform surfacePos;
    public Transform spawnLoc;

    bool spawned = false;
    bool spawningAlready = false;

    public float speed;

    public float delay;

    Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = currSurface.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (spawned == true)
        {
            float step = speed * Time.deltaTime;
            currSurface.transform.position = Vector3.MoveTowards(currSurface.transform.position, surfacePos.position, step);
            if (currSurface.transform.position == surfacePos.position)
            {
                spawned = false;
                spawningAlready = false;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Tool"){
            //collision.gameObject.transform.DetachChildren();
            Destroy(collision.gameObject);
        }

    }

    public void dropSurface1()
    {
        if (spawningAlready == false)
        {
            rb.isKinematic = false;
            StartCoroutine(MyCoroutine(surface1));
            spawningAlready = true;
        }

    }

    public void dropSurface2()
    {
        if (spawningAlready == false)
        {
            rb.isKinematic = false;
            StartCoroutine(MyCoroutine(surface2));
            spawningAlready = true;
        }

    }

    IEnumerator MyCoroutine(GameObject toSpawn)
    {

        yield return new WaitForSeconds(delay);

        currSurface = Instantiate(toSpawn, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        rb = currSurface.GetComponent<Rigidbody>();
        spawned = true;

    }


}
