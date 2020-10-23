using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class MasterVolumeSlider : MonoBehaviour
{   
    public TextMesh volumeText;
    private Slider slider;

    void Start() {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { VolumeChange(); });
    }

    public void VolumeChange() {
        Debug.Log(slider.value);
    }
}
