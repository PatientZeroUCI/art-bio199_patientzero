using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class PlayAudioClipOnGrab : MonoBehaviour
{
    public int audioClipIndex;  // index number for the audio clip to play

    private AIVoice aiVoice;



    // Start is called before the first frame update
    void Start()
    {
        //subscribe to the event.  NOTE: the "ObectGrabbed"  this is the procedure to invoke if this objectis grabbed.. 

        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += new InteractableObjectEventHandler(ObjectGrabbed);

        aiVoice = FindObjectOfType<AIVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsGrabbed())
        //{
        //    gameObject.Debug.Log("TEST");
        //}
    }

    private void ObjectGrabbed(object sender, InteractableObjectEventArgs e)

    {
        aiVoice.ReadVoiceClip(audioClipIndex);
    }
}
