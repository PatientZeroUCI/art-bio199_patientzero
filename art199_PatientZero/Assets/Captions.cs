using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Captions : MonoBehaviour
{
    private TextMeshPro text;
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("getCamera");
        text = gameObject.GetComponent<TextMeshPro>();
    }

    IEnumerator getCamera()
    {
        yield return new WaitForSeconds(.1f);
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = camera.transform.position + (camera.transform.forward);
        gameObject.transform.rotation = camera.transform.rotation;
    }

    public void addCaptions(string s)
    {
        text.text = s;
    }
}
