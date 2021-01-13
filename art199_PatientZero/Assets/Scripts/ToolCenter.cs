using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ToolCenter : MonoBehaviour
{
    public PositionResetter PR;

    public GameObject currSurface;
    public List<GameObject> surfaces;
    private GameObject outsideSurface;
    private int surfacenum;
    
    public Transform surfacePos;
    public Transform spawnLoc;

    bool spawned = false;
    bool spawningAlready = false;

    public float speed;
    public float delay;
    Rigidbody rb;

    bool canPlayAudio = true;
    public AIVoice aiVoice;
    public List<int> aiVoiceClips;
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
                outsideSurface = surfaces[surfacenum];
                if (PR != null)
                {
                    foreach (Transform child in currSurface.transform)
                    {
                        GameObject obj = child.gameObject;
                        if (PR.checkTag(obj.tag))
                        {
                            PR.setSpawn(obj);
                        }

                    }
                }
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {

        if (PR.checkTag(collision.gameObject.tag))
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

    public void dropSurface3()
    {
        dropSurface(2);
    }

    public void dropSurface(int i)
    {
        if (spawningAlready == false && surfaces[i] != outsideSurface)
        {
        	surfacenum = i;
            rb.isKinematic = false;
            if (PR != null)
            {
                foreach (Transform child in currSurface.transform)
                {
                    GameObject obj = child.gameObject;
                    if (PR.checkTag(obj.tag))
                    {
                        PR.removeSpawn(obj);
                    }

                }
            }
 
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
        rb = currSurface.transform.Find("Surface").gameObject.GetComponent<Rigidbody>();
        spawned = true;
        canPlayAudio = true;

    }


}
