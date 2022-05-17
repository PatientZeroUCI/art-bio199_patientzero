using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoungeElevator : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log("help");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Left" || other.gameObject.name == "Right" || other.gameObject.name == "[VRTK][AUTOGEN][BodyColliderContainer]")
        {
            SceneManager.LoadScene("ElevatorScene");

        }
    }
}
