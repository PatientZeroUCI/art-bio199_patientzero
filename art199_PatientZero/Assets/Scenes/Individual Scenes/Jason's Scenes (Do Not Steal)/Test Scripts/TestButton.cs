using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    private AIVoice aiVoice;

    // Start is called before the first frame update
    void Start()
    {
        aiVoice = FindObjectOfType<AIVoice>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        aiVoice.ReadVoiceClip(81);
    }
}
