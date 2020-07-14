using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Captions : MonoBehaviour {
    private AudioSource audioSource;

    public TextMeshProUGUI textObject;
    public TextAsset file;

    private List<(float time, string caption)> captions = new List<(float, string)>();
    private int currentIndex = 0;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        foreach (string line in file.text.Split('\n')) {
            if (line != "") {
                string[] split = line.Split(';');
                captions.Add((float.Parse(split[0]), split[1]));
            }
        }
    }

    private void Update() {
        if (audioSource.isPlaying) {
            if (currentIndex < captions.Count && captions[currentIndex].time < audioSource.time) {
                textObject.text = captions[currentIndex++].caption;
            }
        } else {
            textObject.text = "";
        }
    }
}