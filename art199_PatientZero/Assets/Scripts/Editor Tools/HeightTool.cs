using UnityEditor;
using UnityEngine;

public class HeightTool : EditorWindow
{
    private HeightSettings currentHeightSetting;
    private int feet;
    private int inches;
    
    // Create a new GUI window
    [MenuItem("Custom Tools/Player Height Tool")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(HeightTool));
    }
    
    public void Awake()
    {
        if (Application.isPlaying)
        {
            ResetHeightSettings();
        }
    }
    
    public void OnGUI()
    {
        if (EditorPrefs.GetBool("modificationFromMenu"))
        {
            feet = EditorPrefs.GetInt("feet");
            inches = EditorPrefs.GetInt("inches");
            EditorPrefs.SetBool("modificationFromMenu", false);
        }
        
        GUILayout.Label("Height Options", EditorStyles.boldLabel);
        feet = EditorGUILayout.DelayedIntField("Feet:", feet);
        if (feet < 0) feet = 0;
        inches = EditorGUILayout.DelayedIntField("Inches:", inches);
        if (inches < 0) inches = 0;
        EditorGUILayout.LabelField("Centimeters:", ((feet * 30.48) + (inches * 2.54)).ToString());
        
        if (currentHeightSetting == null && Application.isPlaying) ResetHeightSettings();
        if (currentHeightSetting != null) 
        {
            currentHeightSetting.adjustHeight((feet * 12) + inches);
        }
        // else Debug.Log("No Change Recorded");
    }
    
    private void ResetHeightSettings()
    {
        currentHeightSetting = Object.FindObjectsOfType<HeightSettings>()[0]; 
    }
}
