using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreenController : MonoBehaviour
{

    public GameObject nextMenu;
    public Transform spawnLoc;
    GameObject spawned;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void spawnNextMenu()
    {
        Debug.Log("pass");
        spawned = Instantiate(nextMenu, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
