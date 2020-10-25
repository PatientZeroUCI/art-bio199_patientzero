using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonScript : MonoBehaviour
{
    public GameObject settingsMenu;
    private Vector3 initialMenuPos;
    public List<GameObject> otherMenus;

    private void Start() {
        initialMenuPos = settingsMenu.transform.position;
        settingsMenu.transform.position += new Vector3(0, -10, 0);
    }

    public void displaySettings() {
        // Temporary workaround. VRTK's Artificial Slider seems to reinstantiate itself for each time it is reactivated
        if(settingsMenu.transform.position == initialMenuPos) {
            settingsMenu.transform.position += new Vector3(0, -10, 0);
        } else {

            foreach (GameObject menu in otherMenus)
            {
                menu.SetActive(false);
            }

            settingsMenu.transform.position = initialMenuPos;
        }
    }
}
