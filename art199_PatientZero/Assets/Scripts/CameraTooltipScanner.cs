using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraTooltipScanner : MonoBehaviour
{
    public Transform tooltipPrefab;

    private Camera playerCam;
    private GameObject[] targets;
    private Dictionary<GameObject, Transform> activeTooltips;

    void Start()
    {
        playerCam = GetComponent<Camera>();
        activeTooltips = new Dictionary<GameObject, Transform>();
    }

    void Update()
    {
        if(tooltipPrefab != null) {
            Scan();
            Cleanup();
        }
    }

    /// <summary>
    /// Scan's player camera for any GameObjects with the tag "Tool" and will either 1)instatiate a tooltip if
    /// they are within range or, 2)remove the tooltip if they are not within range.
    /// </summary>
    private void Scan() {
        targets = GameObject.FindGameObjectsWithTag("Tool");
        for (int i = 0; i < targets.Length; i++) {
            Vector3 targetDistance = playerCam.WorldToViewportPoint(targets[i].transform.position);
            if (IsWithinRange(targetDistance) && !activeTooltips.ContainsKey(targets[i])) {
                Vector3 tooltipPos = targets[i].transform.position + new Vector3(0, 0.5f, 0);
                Transform tooltip = Instantiate(tooltipPrefab, tooltipPos, Quaternion.identity); // Setting parent will distort the text
                tooltip.GetComponent<TooltipScript>().initTooltip(targets[i].name, targets[i].transform);
                activeTooltips.Add(targets[i], tooltip);
            }
            else if (!IsWithinRange(targetDistance) && activeTooltips.ContainsKey(targets[i])) {
                RemoveTooltip(targets[i]);
            }
        }
    }

    /// <summary>
    /// Removes Tooltips of destroyed GameObjects
    /// </summary>
    private void Cleanup() {
        List<GameObject> removals = new List<GameObject>();
        foreach (KeyValuePair<GameObject, Transform> entry in activeTooltips) {
            if (entry.Key == null) {
                Debug.Log("Found destroyed object");
                removals.Add(entry.Key);
            }
        }
        foreach (GameObject key in removals) {
            RemoveTooltip(key);
        }
    }

    /************** Helper methods **************/

    private void RemoveTooltip(GameObject key) {
        Destroy(activeTooltips[key].gameObject);
        activeTooltips.Remove(key);
    }

    private bool IsWithinRange(Vector3 pos) {
        return ((pos.x >= 0 && pos.x <= 1) && (pos.y >= 0 && pos.y <= 1) && (pos.z >= 0 && pos.z <= 6)) ? true : false;
    }
}
