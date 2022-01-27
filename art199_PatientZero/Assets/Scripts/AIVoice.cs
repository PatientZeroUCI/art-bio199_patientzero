using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VRTK;
using UnityEngine.UI;

public class AIVoice : MonoBehaviour {
    private AudioSource audioSource;

    private List<(float time, string caption)> captions = new List<(float, string)>();
    private int currentIndex = 0;
    private float endTime = -1;
    private int indexPlaying;

    //public int playOnStart = -1;
    public TextMeshProUGUI textObject;
    public List<VoiceClip> voiceClips = new List<VoiceClip>();

    private List<int> playOnStart;
    private float delay = 0;

    public VRTK_ControllerEvents right_hand;

    private bool skipIntroVoicelines = false; // Set to true to skip intro voice lines (remember to eventually set back to false)

    private static bool turnOffCaptions = false; // Set to true to turn off captioning for the voice lines

    private static bool ThreeDCaptions = false; //Set to true to use 3D Captions

    bool gamePaused = false;

    private Captions ThreeDCaps; //Script that handles the 3D Captions

    public GameObject captionOnOffText;

    [SerializeField]
    private List<int> clipsToNotRepeat;  // List of clip numbers that should only play once per scene
    private List<int> playedClips = new List<int>();  // List of clip numbers that have been played so that they aren't repeated

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        ThreeDCaps = GameObject.FindGameObjectWithTag("Captions").GetComponent<Captions>();
    }

    private void Start() {
        playOnStart = new List<int> { 58, 59, 60, 61, 62, 63, 64 };
    }

    public void ReadVoiceClip(int index) {
        // If the audiio clip index hasn't been played or isn't an index in the clipsToNotRepeat list
        if (!clipsToNotRepeat.Contains(index) || !playedClips.Contains(index))
        {
            // add the clip indedx to the playedClips list so it isn't repeated
            playedClips.Add(index);

            indexPlaying = index;

            VoiceClip clip = voiceClips[index];

            if (!clip.repeatable && clip.played)
            {
                return;
            }
            clip.played = true;
            
            if (!turnOffCaptions) //Check if player wants voicelines to be read with or without captions
            {
                captions.Clear();
                foreach (string line in clip.captionsFile.text.Split('\n'))
                {
                    if (line != "")
                    {
                        string[] split = line.Split(new char[] { ';' }, 2);
                        captions.Add((float.Parse(split[0]), split[1]));
                    }
                }
            }     
            
            audioSource.clip = clip.audioClip;
            currentIndex = 0;
            audioSource.time = clip.start;
            endTime = clip.end;
            if (index == 65)
            {
                endTime = endTime - 0.2f;
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) { pauseAudio(); }
        if ((audioSource.isPlaying) && (!gamePaused)) 
        {
            while (currentIndex < captions.Count && captions[currentIndex].time < audioSource.time) 
            {
                if (ThreeDCaptions) //Check if player wants 3D captions
                {
                    ThreeDCaps.addCaptions(captions[currentIndex++].caption);
                    if (turnOffCaptions) ThreeDCaps.addCaptions("");
                }
                else
                {
                    textObject.text = captions[currentIndex++].caption;
                    if (turnOffCaptions) textObject.text = "";
                }
            }
            if ((audioSource.time > endTime) || right_hand.buttonOnePressed) {
                audioSource.Stop();
                ThreeDCaps.addCaptions("");
                audioSource.clip = null;
            }
        } 
        else 
        {
            textObject.text = "";

            if (audioSource.clip != null) {
                if (delay > 0) {
                    delay -= Time.deltaTime;
                } else {
                    audioSource.Play();
                }
            } else {
                if (playOnStart.Count > 0 & !skipIntroVoicelines) {
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
    
    // Returns true if the AI has finished reading all of the opening lines
    // This should be called by ToolCenter to make sure VIRA finishes reading lines
    // before the player can use the ToolCenter
    public bool ReadAllOpeningLines()
    {
        if (skipIntroVoicelines)
        {
            return true;
        }
        return playOnStart.Count == 0; // When a line gets played, it get removed from playOnStart, so the count should eventually reach zero
    }


    // Adds vocie clip to the Start queue that play when the AIvoice finishes it's current clip
    // Good when multiple clips ahve to be called at once, since calling ReadVoiceClip while one is running overides the current clip
    // Use this function for all but the first one to have them play when the first clip finishes
    public void AddClipToQueue(int index)
    {
        playOnStart.Add(index);
    }

    // Switches from either having captions on or having captions off for the voicelines
    public void switchCaptioning()
    {
        if (turnOffCaptions)
        {
            turnOffCaptions = false;
            GameObject.FindGameObjectWithTag("CaptionText").GetComponent<TextMeshPro>().text = "On";
        }
        else
        {
            turnOffCaptions = true;
            GameObject.FindGameObjectWithTag("CaptionText").GetComponent<TextMeshPro>().text = "Off";
        }
    }

    public void switchThreeDCaps()
    {
        if (ThreeDCaptions)
        {
            ThreeDCaptions = false;
            GameObject.FindGameObjectWithTag("Caption2D").GetComponent<TextMeshPro>().text = "2D";
        }
        else
        {
            ThreeDCaptions = true;
            GameObject.FindGameObjectWithTag("Caption2D").GetComponent<TextMeshPro>().text = "3D";
        }
    }

    private void pauseAudio()
    {
        if (gamePaused)
        {
            audioSource.Play();
            gamePaused = false;
        }
        else
        {
            audioSource.Stop();
            playOnStart.Insert(0, indexPlaying);
            ThreeDCaps.addCaptions("");
            audioSource.clip = null;
            gamePaused = true;
        }
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