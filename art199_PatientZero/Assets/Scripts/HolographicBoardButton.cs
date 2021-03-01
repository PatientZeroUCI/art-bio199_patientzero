using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HolographicBoardButton : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject nextScreen;
    public Slider volumeSlider;
    public TextMeshProUGUI volumeNumber;

    private void Start()
    {
        // Get current volume and display
        if (volumeSlider != null)
        {
            volumeSlider.value = AudioListener.volume * 100;
            updateVolumeText();
        }
    }

    /****************************** BASIC SCREEN METHODS ******************************/
    public void volumeAdjust()
    {
        if (volumeSlider != null)
        {
            AudioListener.volume = volumeSlider.value / 100;
            updateVolumeText();
            Debug.Log("DEBUG: Current volume = " + AudioListener.volume);
        }
    }

    public void switchScreen()
    {
        if (currentScreen != null && nextScreen != null)
        {
            currentScreen.SetActive(false);
            nextScreen.SetActive(true);
        }
    }

    public void beginGame()
    {
        SceneManager.LoadScene("Wrap Up");
    }

    /****************************** HELPER METHODS ******************************/
    private void updateVolumeText()
    {
        if (volumeNumber != null)
            volumeNumber.text = volumeSlider.value.ToString();
    }
}
