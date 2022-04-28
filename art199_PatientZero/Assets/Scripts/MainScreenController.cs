using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenController : MonoBehaviour
{

    public GameObject controller;
    public GameObject nextMenu;
    public Transform spawnLoc;
    public List<GameObject> otherMenus;
    
    // settingsMenu and settingsInitialPos are intended to be temporary workarounds
    // (See the comment in SettingsButtonScript.cs)
    // Once that is resolved, you can delete these and just add the settings menu to otherMenus
    public GameObject settingsMenu;
    private Vector3 settingsInitialPos;

    GameObject spawned;
    //private VRTK_InteractUse use;

    // Start is called before the first frame update
    void Start()
    {
        settingsInitialPos = settingsMenu.transform.position;
        settingsInitialPos += new Vector3(0, 10, 0);
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
        {
            nextMenu.SetActive(false);
        }
        else
        {
            if (settingsMenu.transform.position == settingsInitialPos)
            {
                settingsMenu.transform.position += new Vector3(0, -10, 0);
            }

            foreach (GameObject menu in otherMenus)
            {
                menu.SetActive(false);
            }
            nextMenu.SetActive(true);
        }
        //}

    }

    public void beginGame() {
        //if (use.GetUsingObject().name == "playbutton")
        //{
        //SceneManager.LoadScene("Wrap Up");
        SceneManager.LoadScene("LoungeRoom"); 
        //}

    }
}
