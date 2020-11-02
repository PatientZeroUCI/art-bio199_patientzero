using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRTK;

public class AIVoice : MonoBehaviour {
    private AudioSource audioSource;

    private List<(float time, string caption)> captions = new List<(float, string)>();
    private int currentIndex = 0;
    private float endTime = -1;

    //public int playOnStart = -1;
    public TextMeshProUGUI textObject;
    public List<VoiceClip> voiceClips = new List<VoiceClip>();

    private List<int> playOnStart;
    private float delay = 0;

    public VRTK_ControllerEvents right_hand;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        playOnStart = new List<int> { 58, 59, 60, 61, 62, 63, 64 };
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
                string[] split = line.Split(new char[] { ';' }, 2);
                captions.Add((float.Parse(split[0]), split[1]));
            }
        }

        audioSource.clip = clip.audioClip;
        currentIndex = 0;
        audioSource.time = clip.start;
        endTime = clip.end;
    }

    private void Update() {
        if (audioSource.isPlaying) {
            while (currentIndex < captions.Count && captions[currentIndex].time < audioSource.time) {
                textObject.text = captions[currentIndex++].caption;
            }

            if ((audioSource.time > endTime) || right_hand.buttonOnePressed) {
                audioSource.Stop();
                audioSource.clip = null;
            }
        } else {
            textObject.text = "";

            if (audioSource.clip != null) {
                if (delay > 0) {
                    delay -= Time.deltaTime;
                } else {
                    audioSource.Play();
                }
            } else {
                if (playOnStart.Count > 0) {
                    delay = 0.5f;
                    ReadVoiceClip(playOnStart[0]);
                    playOnStart.RemoveAt(0);
                }
            }
        }

        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    ReadVoiceClip(++playOnStart);
        //}
    }
}

[System.Serializable]
public class VoiceClip {
    public AudioClip audioClip;
    public TextAsset captionsFile;
    public bool repeatable;
    public float start;
    public float end;
    [System.NonSerialized] public bool played;
}