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
    
    private int lastPhase = -1;
    public LogicBoardPhases logicBoardPhases; 
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
                           // VRTK.VRTK_InteractableObject object_interact = obj.GetComponent<VRTK.VRTK_InteractableObject>();
                            Rigidbody object_collider = obj.GetComponent<Rigidbody>();
                            if (object_collider != null)
                            {
                                UnityEngine.Debug.Log("object enabled");
                                object_collider.detectCollisions = true;
                            }
                            //PR.setSpawn(obj);
                        }

                    }
                }
            }
        }
        if (aiVoice.ReadAllOpeningLines() && lastPhase != logicBoardPhases.currentPhase)
        {
            aiVoice.ReadVoiceClip(0);
            lastPhase += 1;
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

    public void dropSurface(int i)
    {
        if (aiVoice.ReadAllOpeningLines() && spawningAlready == false && surfaces[i] != outsideSurface)
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
                        Rigidbody object_collider = obj.GetComponent<Rigidbody>();
                        if (object_collider != null)
                        {
                            UnityEngine.Debug.Log("object disabled");

                            object_collider.detectCollisions = false;
                        }
                        PR.removeSpawn(obj);
                    }

                }
            }
            
         	StartCoroutine(spawnNewToolset(surfaces[i]));
        	spawningAlready = true;           	


            if (aiVoiceClips.Count > i) {
                aiVoice.ReadVoiceClip(aiVoiceClips[i]);
            }
        }
    }

    IEnumerator spawnNewToolset(GameObject toSpawn)
    {
        yield return new WaitForSeconds(delay);

        currSurface = Instantiate(toSpawn, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        foreach (Transform child in currSurface.transform)
        {
            GameObject obj = child.gameObject;
            if (PR.checkTag(obj.tag))
            {
                PR.setSpawn(obj);
            }
        }

        rb = currSurface.transform.Find("Surface").gameObject.GetComponent<Rigidbody>();
        spawned = true;
        canPlayAudio = true;

    }


}
