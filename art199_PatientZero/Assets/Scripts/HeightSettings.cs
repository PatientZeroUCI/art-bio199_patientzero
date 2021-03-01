using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using VRTK;

public class HeightSettings: MonoBehaviour
{
    [Tooltip("The heads/necks of each VR setup that will be height adjusted")]
    // I left these separate instead of using the entire rig in case we want to scale them separately.
    public List<GameObject> playerHeads;
    public List<GameObject> leftHands;
    public List<GameObject> rightHands;
    public TextMeshProUGUI heightText;
    public TextMeshProUGUI scaleText;
    public float scaleRatio = 0.025f;

    private Transform playArea;
    private Transform currentHead;
    private Transform currentLeftHand;
    private Transform currentRightHand;
    private Transform currentSDK;
    private float initialPlayerHeight;
    private float initialHandHeight;
    private Vector3 initialPlayerScale;

    public void detectSetup()
    {
        // Activated through events. For now, Settings Menu button press event
        Transform searchChildren(Transform transform, List<GameObject> targets)
        {
            if (targets.Contains(transform.gameObject))
            {
                return transform;
            }
            else if (transform.childCount > 0)
            {
                foreach (Transform child in transform)
                {
                    Transform result = searchChildren(child, targets);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }

        playArea = VRTK.VRTK_DeviceFinder.PlayAreaTransform(); // Assign play area (Camera Rig)
        currentSDK = playArea.parent; // Assign current VR SDK (For player scaling)

        // Assign current player head/neck & hands
        currentHead = searchChildren(playArea, playerHeads);
        currentLeftHand = searchChildren(playArea, leftHands);
        currentRightHand = searchChildren(playArea, rightHands);

        if (currentHead != null)
        {
            setHeightText();
            setScaleText();
            initialPlayerHeight = currentHead.transform.position.y;
            initialHandHeight = currentLeftHand.position.y;
            initialPlayerScale = currentSDK.localScale;
            Debug.Log("Player SDK: " + currentSDK);
        }
        else
        {
            Debug.Log("Couldn't find headset. Were the headsets assigned in Inspector?"); // For debug
        }
    }

    /****************************** SCALE METHODS ******************************/

    public void adjustScale(bool add)
    {
        int sign = add ? 1 : -1;
        float scale = scaleRatio * sign;
        currentSDK.localScale += new Vector3(scale, scale, scale);
        setScaleText();
    }

    public void resetScale()
    {
        currentSDK.localScale = initialPlayerScale;
        resetHeight();
        setScaleText();
    }

    private void setScaleText()
    {
        int scale = Mathf.FloorToInt(currentSDK.localScale.x * 100);
        scaleText.text = scale + "%";
    }

    /****************************** HEIGHT METHODS ******************************/

    public void adjustHeight(bool add)
    {
        float inch = 0.0254f * currentSDK.localScale.y; // Note: 0.0254 meters == 1 inch
        int sign = add ? 1 : -1;
        currentHead.position += new Vector3(0, sign * inch, 0);
        currentLeftHand.position += new Vector3(0, sign * inch, 0);
        currentRightHand.position += new Vector3(0, sign * inch, 0);
        EditorPrefs.SetInt("feet", GetFeet());
        EditorPrefs.SetInt("inches", GetInches());
        EditorPrefs.SetBool("modificationFromMenu", true);
        setHeightText();
    }
    
    public void adjustHeight(float inches)
    {
        detectSetup();
        float inch = 0.0254f * currentSDK.localScale.y; // Note: 0.0254 meters == 1 inch
        currentHead.position = new Vector3(currentHead.position.x, inches * inch - (20 * 0.0254f), currentHead.position.z);
        currentLeftHand.position = new Vector3(currentLeftHand.position.x, inches * inch - (20 * 0.0254f), currentLeftHand.position.z);
        currentRightHand.position = new Vector3(currentRightHand.position.x, inches * inch - (20 * 0.0254f), currentRightHand.position.z);
        setHeightText();
    }
    
    public int GetFeet()
    {
        float playerHeight = currentHead.transform.localPosition.y;
        float inch = 0.0254f * currentSDK.localScale.y;
        return (int) Mathf.Floor(playerHeight / (inch * 12));
    }
    
    public int GetInches()
    {
        float playerHeight = currentHead.transform.localPosition.y;
        float inch = 0.0254f * currentSDK.localScale.y;
        return (int) Mathf.Floor((playerHeight % (inch * 12)) / inch);
    }

    public void resetHeight()
    {
        if (currentHead != null)
        {
            currentHead.position = new Vector3(currentHead.position.x, initialPlayerHeight * currentSDK.localScale.y, currentHead.position.z);
            currentLeftHand.position = new Vector3(currentLeftHand.position.x, initialHandHeight * currentSDK.localScale.y, currentLeftHand.position.z);
            currentRightHand.position = new Vector3(currentRightHand.position.x, initialHandHeight * currentSDK.localScale.y, currentRightHand.position.z);
            setHeightText();
        }
    }

    private void setHeightText()
    {
        // Get current player height
        float playerHeight = currentHead.transform.localPosition.y;

        // Set estimated height text depending on player scale
        // Note: 0.0254 meters == 1 inch
        float inch = 0.0254f * currentSDK.localScale.y;
        int heightFoot = (int) Mathf.Floor(playerHeight / (inch * 12));
        int heightInch = (int) Mathf.Floor((playerHeight % (inch * 12)) / inch);
        heightText.text = heightFoot + "\"" + heightInch;
    }

}
