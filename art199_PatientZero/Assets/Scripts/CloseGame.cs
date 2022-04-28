using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class CloseGame : MonoBehaviour
{
    private GameObject camera;
    public bool isPaused = false;
    public bool isStartScreen = false;  // Stops esc from opening the menu if in the start screen

    void Start()
    {
        StartCoroutine("getCamera");
    }

    IEnumerator getCamera()
    {
        yield return new WaitForSeconds(.1f);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) && (!isPaused) && (!isStartScreen))
        {
            PauseGame();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape)) && (isPaused) && (!isStartScreen))
        {
            UnpauseGame();
        }
            
    }

    void PauseGame()
    {
        isPaused = true;
        GameObject.FindWithTag("SettingMenu").transform.position = camera.transform.position + (camera.transform.forward * 2);
        GameObject.FindWithTag("SettingMenu").transform.rotation = camera.transform.rotation;
        GameObject.FindWithTag("SettingMenu").GetComponentInChildren<HeightSettings>().detectSetup();
    }

    void UnpauseGame()
    {
        isPaused = false;
        GameObject.FindWithTag("SettingMenu").transform.position = new Vector3(0.145f, -16.64f, -6.06f);
    }

    public void closeGame()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

}
