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
    // public TextMeshProUGUI heightText;
    // public TextMeshProUGUI scaleText;
    //public TextMesh heightText;
    //public TextMesh scaleText;
    public TextMeshPro heightText;
    public TextMeshPro scaleText;
    public float scaleRatio = 0.025f;

    private Transform playArea;
    private Transform currentHead;
    private Transform currentLeftHand;
    private Transform currentRightHand;
    private Transform currentSDK;
    private float initialPlayerHeight;
    private float initialHandHeight;
    private Vector3 initialPlayerScale;

    private bool checkedPlayerSettings = false;  //Keeps track if the player height settings from a previous scene has been checked


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            detectSetup();
        }

        //  Contineus trying to detect the setup until checkedPlayerSetup is true
        // Is turned to true when a setup is found
        // Done so that previous height and scale setting are appleid at the start of the scene

        if (!checkedPlayerSettings)
        {
            detectSetup();
        }
    }



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
            checkedPlayerSettings = true;
            // Check to see if there are player settings from a previous scene
            if (RememberPlayerSettings.Instance != null)
            {
                // Check to see if the headHeight variable is set to -777, which is the defualt variable
                // If it does, dont set the heights
                if (RememberPlayerSettings.Instance.headHeight != -777f)
                {
                    // Set the heightsigths and scale
                    currentHead.localPosition = new Vector3(currentHead.localPosition.x, RememberPlayerSettings.Instance.headHeight, currentHead.localPosition.z);
                    currentLeftHand.localPosition = new Vector3(currentLeftHand.localPosition.x, RememberPlayerSettings.Instance.leftHeight, currentLeftHand.localPosition.z);
                    currentRightHand.localPosition = new Vector3(currentRightHand.localPosition.x, RememberPlayerSettings.Instance.rightHeight, currentRightHand.localPosition.z);
                    currentSDK.localScale = new Vector3(RememberPlayerSettings.Instance.scale, RememberPlayerSettings.Instance.scale, RememberPlayerSettings.Instance.scale);
                    //Debug.Log(currentSDK.localScale);
                    //Debug.Log(new Vector3(RememberPlayerSettings.Instance.scale, RememberPlayerSettings.Instance.scale, RememberPlayerSettings.Instance.scale));
                }
            }

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

        // Store the scale to be saved between scenes
        RememberPlayerSettings.Instance.scale = currentSDK.localScale.x;
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
        if (!currentSDK) detectSetup();
        float inch = 0.0254f * currentSDK.localScale.y; // Note: 0.0254 meters == 1 inch
        /*currentHead.position = new Vector3(currentHead.position.x, inches * inch, currentHead.position.z);
        currentLeftHand.position = new Vector3(currentLeftHand.position.x, inches * inch, currentLeftHand.position.z);
        currentRightHand.position = new Vector3(currentRightHand.position.x, inches * inch, currentRightHand.position.z);
        */
        currentHead.localPosition = new Vector3(currentHead.localPosition.x, inches * inch, currentHead.localPosition.z);
        currentLeftHand.localPosition = new Vector3(currentLeftHand.localPosition.x, inches * inch, currentLeftHand.localPosition.z);
        currentRightHand.localPosition = new Vector3(currentRightHand.localPosition.x, inches * inch, currentRightHand.localPosition.z);
        Debug.Log("Neck: " + currentHead.localPosition);
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
        //heightText.text = heightFoot + "\"" + heightInch;
        heightText.text = heightFoot + "\"" + heightInch;

        // Store the height to be saved between scenes
        RememberPlayerSettings.Instance.headHeight = playerHeight;
        RememberPlayerSettings.Instance.leftHeight = currentLeftHand.transform.localPosition.y;
        RememberPlayerSettings.Instance.rightHeight = currentRightHand.transform.localPosition.y;
    }

}
