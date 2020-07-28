using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIVoice : MonoBehaviour {
    private AudioSource audioSource;

    private List<(float time, string caption)> captions = new List<(float, string)>();
    private int currentIndex = 0;

    public int playOnStart = -1;
    public TextMeshProUGUI textObject;
    public List<VoiceClip> voiceClips = new List<VoiceClip>();

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        if (playOnStart > -1) {
            ReadVoiceClip(playOnStart);
        }
    }

    public void ReadVoiceClip(int index) {
        VoiceClip clip = voiceClips[index];

        if (!clip.repeatable && clip.played) {
            return;
        }
        clip.played = true;

        captions.Clear();
        foreach (string line in clip.captionsFile.text.Split('\n')) {
            if (line != "") {
                string[] split = line.Split(';');
                captions.Add((float.Parse(split[0]), split[1]));
            }
        }

        audioSource.clip = clip.audioClip;
        currentIndex = 0;
        audioSource.Play();
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

[System.Serializable]
public class VoiceClip {
    public AudioClip audioClip;
    public TextAsset captionsFile;
    public bool repeatable;
    [System.NonSerialized] public bool played;
}