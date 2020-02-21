using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;


public class KeyItem : MonoBehaviour
{
    Vector3 spawnPoint;
    Color originalColor;
    Color itemColor;
    float lastTimeAtSpawn;
    VRTK_InteractableObject virtualGameObject;

    [SerializeField]
    [Range(0, 100)]
    private float spawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = gameObject.GetComponent<Transform>().position;
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        itemColor = new Color(94, 0, 169, 1);
        lastTimeAtSpawn = Time.time;
        virtualGameObject = gameObject.GetComponent<VRTK_InteractableObject>();


    }

    void teleportBackToSpawn()
    {
        //if not in hand and not on the spawn
        if (!virtualGameObject.IsGrabbed() && gameObject.transform.position != spawnPoint)
        {
            float currentTime = Time.time;

            //print(currentTime - lastTimeAtSpawn);
            //print(spawnTime);
            //print('\n');

            if (currentTime - lastTimeAtSpawn > spawnTime)
            {
                gameObject.transform.position = spawnPoint;
                lastTimeAtSpawn = Time.time;
            }
        }
    }

    void OnBecameVisible()
    {
        //if visible and not in hand, object should glow purple
        if (!virtualGameObject.IsGrabbed())
        {
            gameObject.GetComponent<Renderer>().material.color = itemColor;
        }
    }

    void OnBecameInvisible()
    {
        //if not visible, object should not be purple...
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }

   

    // Update is called once per frame
    void Update()
    {
        teleportBackToSpawn();

    }


}

