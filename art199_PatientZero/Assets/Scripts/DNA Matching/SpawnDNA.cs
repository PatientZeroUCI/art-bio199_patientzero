using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public class SpawnDNA : MonoBehaviour
{
    // members that are not visible within inspector.
    private TextMeshPro[] puzzleStrands;    // this is the "left" DNA
    private TextMeshPro[] playerStrands;    // this is the "right" DNA

    public OrderedDictionary bases = new OrderedDictionary();

    // the reason these are serialized is because none of these 
    // should change during runtime... but people need to edit these.
    [SerializeField]
    private GameObject DNAPrefab;

    public bool isDNA;

    [SerializeField]
    private bool isRandomlyGenerated;

    [SerializeField]
    private string sequence;

    private AIVoice aiVoice;


    // Start is called before the first frame update
    void Start()
    {
        aiVoice = FindObjectOfType<AIVoice>();
    }

    void OnEnable() // so that way, this doesn't immediately do stuff until needed
    {
        // Spawn DNA
        GameObject gObject = Instantiate(DNAPrefab, gameObject.transform);
        gObject.name = "DNA";

        // Get references to TMPro Objects
        puzzleStrands = gameObject.transform.Find("DNA/Left DNA").GetComponentsInChildren<TextMeshPro>();
        playerStrands = gameObject.transform.Find("DNA/Right DNA").GetComponentsInChildren<TextMeshPro>();


        //aiVoice.ReadVoiceClip(78);


        // Set up bases for random generation
        bases.Add("G", "C");
        bases.Add("C", "G");

        if (isDNA)
        {
            bases.Add("A", "T");
            bases.Add("T", "A");
        }
        else
        {
            bases.Add("A", "U");
            bases.Add("U", "A");
        }

        bases = bases.AsReadOnly();

        // Generate bases
        LoadSequence();
    }

    private void Update()
    {
    }

    // helper functions
    private void LoadSequence()
    {
        // sets up sequence for both puzzle strand and player strand
        // aka left and right DNA respectively...

        for (int i = 0; i < puzzleStrands.Length; ++i)
        {
            // puzzle strand first
            
            if (isRandomlyGenerated)
            {
                puzzleStrands[i].text = bases[Random.Range(0,4)].ToString();
            }
            else
            {
                puzzleStrands[i].text = sequence[i].ToString();
            }

            // player strand next
            string randomBase;

            do
            {
                randomBase = bases[Random.Range(0, 4)].ToString();
            }
            while (randomBase == bases[puzzleStrands[i].text]);

            playerStrands[i].text = randomBase;
        }
    }

    public bool puzzleSolved()
    {

        for (int i = 0; i < puzzleStrands.Length; ++i)
        {
            string currentBase = puzzleStrands[i].text;         // strand evaluated against
            string correspondingBase = playerStrands[i].text;   // strand providing answer
            if (correspondingBase != bases[currentBase].ToString())
            {
                return false;
            }
        }

        return true;
    }





}   
