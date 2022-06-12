using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAResult : MonoBehaviour
{
    public GameObject test_result;
    public SpawnDNA puzzle;

    private AIVoice aiVoice;


    // Start is called before the first frame update
    void Start()
    {
        aiVoice = FindObjectOfType<AIVoice>();
    }

    private void Awake()
    {
        Level1Events.current.BacteriaInserted();
    }

    // Update is called once per frame
    void Update()
    {
        if (puzzle.puzzleSolved() && test_result.active == false)
        {
            test_result.SetActive(true);
            Level1Events.current.DNAMatched();
            aiVoice.ReadVoiceClip(79);
        }
    }
}
