using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTooltipScript : MonoBehaviour
{
    private Camera pCam;
    private GameObject[] targets;
    public GameObject tooltipContainer;
    public Transform tooltipPrefab;

    void Start()
    {
        pCam = GetComponent<Camera>();
        targets = GameObject.FindGameObjectsWithTag("Tool");
        Transform text = Instantiate(tooltipPrefab);
        text.SetParent(tooltipContainer.transform);
        text.localScale = new Vector3(1, 1, 1);
        text.localPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        for(int i = 0; i < targets.Length; i++) {
            GameObject target = targets[i];
            Renderer targetRenderer = target.GetComponent<Renderer>();
            if (targetRenderer != null && targetRenderer.isVisible) {
                Vector3 pos = pCam.WorldToViewportPoint(target.transform.position);
                Debug.Log(target.name + ": " + pos);
            }
        }
    }
}
