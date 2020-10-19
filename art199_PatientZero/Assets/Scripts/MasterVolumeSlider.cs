using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;

public class MasterVolumeSlider : MonoBehaviour
{   
    public VRTK_BaseControllable controllable;
    public TextMesh volumeText;

    protected virtual void OnEnable() {
        controllable = controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable;
        controllable.ValueChanged += ValueChanged;
        Debug.Log("On runtime - Volume = " + AudioListener.volume + "; Value before change = " + controllable.GetValue());
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e) {
        AudioListener.volume = controllable.GetNormalizedValue();
        volumeText.text = ((int)(AudioListener.volume * 100)) + "%";
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
    }
}
