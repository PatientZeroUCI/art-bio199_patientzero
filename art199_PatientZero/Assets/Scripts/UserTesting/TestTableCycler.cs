using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTableCycler : MonoBehaviour
{
    public GameObject testingTables;  // Empty GameObject holding all the test tables
    private int currTable;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            testingTables.transform.Translate(new Vector3(-10, 0, 0));

            currTable += 1;
        }
    }
}
