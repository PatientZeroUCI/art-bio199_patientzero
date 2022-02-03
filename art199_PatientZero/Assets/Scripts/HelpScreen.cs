using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpScreen : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer screen;

    [SerializeField]
    private Material GramStain;
    [SerializeField]
    private Material DNAMatch;
    [SerializeField]
    private Material DNACompare;


    // Start is called before the first frame update
    void Start()
    {
        Level1Events.current.onSlideInsertedInMicroscope += LoadGramStain;
        Level1Events.current.onPetriInsertedInMicroscope += LoadDNAMatch;
        Level1Events.current.onDNAMatched += LoadDNAComapre;
    }

    void LoadGramStain()
    {
        screen.material = GramStain;
    }

    void LoadDNAMatch()
    {
        screen.material = DNAMatch;
    }

    void LoadDNAComapre()
    {
        screen.material = DNACompare;
    }
}
