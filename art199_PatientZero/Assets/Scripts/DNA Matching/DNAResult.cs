using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAResult : MonoBehaviour
{
    public GameObject test_result;
    public SpawnDNA puzzle;

    // Update is called once per frame
    void Update()
    {
        if (puzzle.puzzleSolved())
        {
            test_result.SetActive(true);
        }
    }
}
