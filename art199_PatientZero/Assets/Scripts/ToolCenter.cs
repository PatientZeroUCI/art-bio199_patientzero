using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCenter : MonoBehaviour
{
    public GameObject currSurface;
    public List<GameObject> surfaces;
    public AIVoice aiVoice;
    public List<int> aiVoiceClips;
    
    public Transform surfacePos;
    public Transform spawnLoc;

    bool spawned = false;
    bool spawningAlready = false;
    bool canPlayAudio = true;
    public float speed;

    public float delay;

    Rigidbody rb;

    AudioSource tableRisingSound;
    // Start is called before the first frame update
    void Start()
    {
        rb = currSurface.GetComponent<Rigidbody>();
        tableRisingSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (spawned == true)
        {
            float step = speed * Time.deltaTime;
            currSurface.transform.position = Vector3.MoveTowards(currSurface.transform.position, surfacePos.position, step);
            if (canPlayAudio)
            {
                canPlayAudio = false;
                tableRisingSound.Play();
            }
            if (currSurface.transform.position == surfacePos.position)
            {
                spawned = false;
                spawningAlready = false;
                tableRisingSound.Stop();
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Tool")
        {
            //collision.gameObject.transform.DetachChildren();
            Destroy(collision.gameObject);
        }

    }

    public void dropSurface1()
    {
        dropSurface(0);

    }

    public void dropSurface2()
    {
        dropSurface(1);

    }

    public void dropSurface(int i)
    {
        if (spawningAlready == false)
        {
            rb.isKinematic = false;
            StartCoroutine(MyCoroutine(surfaces[i]));
            spawningAlready = true;

            if (aiVoiceClips.Count > i) {
                aiVoice.ReadVoiceClip(aiVoiceClips[i]);
            }
        }

    }

    IEnumerator MyCoroutine(GameObject toSpawn)
    {

        yield return new WaitForSeconds(delay);

        currSurface = Instantiate(toSpawn, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        rb = currSurface.GetComponent<Rigidbody>();
        spawned = true;
        canPlayAudio = true;
    }


}
