using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour
{

    public GameObject controller;
    public GameObject nextMenu;
    public Transform spawnLoc;
    GameObject spawned;
    //private VRTK_InteractUse use;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GameObject.FindGameObjectWithTag("controllerright");
        //use = controller.GetComponent<VRTK_InteractUse>();
    }

    //public void spawnNextMenu()
    //{
    //    Debug.Log("pass");
    //    spawned = Instantiate(nextMenu, spawnLoc.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    //}

    public void showNextMenu()
    {
        //if (use.GetUsingObject().name == "NextMenuBtn")
        //{
            if (nextMenu.activeSelf)
                nextMenu.SetActive(false);
            else
                nextMenu.SetActive(true);
        //}

    }

    public void beginGame() {
        //if (use.GetUsingObject().name == "playbutton")
        //{
            SceneManager.LoadScene("Wrap Up");
        //}
        
    }
}
