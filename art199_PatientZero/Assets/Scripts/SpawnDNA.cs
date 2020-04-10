using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDNA : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject leftSegmentPrefab;

    [SerializeField]
    private GameObject rightSegmentPrefab;

    [SerializeField]
    private float offsetScalar;

    public bool isRNA = false;

    private bool puzzleComplete = false;

    // store the state of each segment in an array when spawned...
    GameObject puzzleSegment;
    GameObject playerSegment;

    TextMesh[] puzzleStrands;
    TextMesh[] playerStrands;

    void Start()
    {
        SpawnDNASegments();
        RandomizeStrands();
    }

    private void Update()
    {
        puzzleSolved();
    }

    void puzzleSolved()
    {

        for (int i = 0; i < puzzleStrands.Length; ++i)
        {
            if (puzzleStrands[i].text != OppositeBase(playerStrands[i].text))
            {
                return;
            }
        }

        if (puzzleComplete == false)
        {
            SnapTogether();
            puzzleComplete = true;
        }
    }



    string OppositeBase(string strandBase)
    {
        if (strandBase == "A")
        {
            if (isRNA)
            {
                return "U";
            }

            return "T";
        }

        else if (strandBase == "U")
        {
            return "A";
        }

        else if (strandBase == "T")
        {
            return "A";
        }

        else if (strandBase == "C")
        {
            return "G";
        }

        else if (strandBase == "G")
        {
            return "C";
        }

        return "ERROR";
    }

    void SnapTogether()
    {
        playerSegment.transform.Translate(offsetScalar * Vector3.left, Space.World);
    }


    void SpawnDNASegments()
    {
        // Spawns the segment that you have to solve against...
        puzzleSegment = Instantiate(leftSegmentPrefab, gameObject.transform);
        puzzleStrands = puzzleSegment.GetComponentsInChildren<TextMesh>();
        
        // Spawns the segment that the player has to modify in order to match it... 
        playerSegment = Instantiate(rightSegmentPrefab, gameObject.transform);
        playerSegment.transform.Translate(offsetScalar * Vector3.right, Space.World);
      
        playerStrands = playerSegment.GetComponentsInChildren<TextMesh>();
    }

    void RandomizeStrands()
    {
        RandomizeBases(puzzleStrands, isRNA);

        // Makes sure the player segment won't end up being the same as the puzzle strand
        do
        {
            RandomizeBases(playerStrands, isRNA);
        }
        while (puzzleEqualsPlayer());
    }

    bool puzzleEqualsPlayer()
    {
        for (int i = 0; i < puzzleStrands.Length; ++i)
        {
            if (puzzleStrands[i] != playerStrands[i])
            {
                return false;
            }
        }

        return true;
    }

    
    void RandomizeBases(TextMesh[] segmentStrands, bool isRNA)
    {
        for (int i = 0; i < segmentStrands.Length; ++i)
        {
            int baseCode = Random.Range(0, 4);
            segmentStrands[i].text = SelectBase(baseCode, isRNA);
        }
    }

    string SelectBase(int baseNumber, bool isRNA)
    {
        switch (baseNumber)
        {
            case 0:
                return "A";

            case 1:
                if (isRNA)
                {
                    return "U";
                }

                return "T";

            case 2:
                return "C";

            case 3:
                return "G";

            default:
                return "ERROR";
        }
    }
}
