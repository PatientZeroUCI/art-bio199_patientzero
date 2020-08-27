using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintIGS : MonoBehaviour
{
    public GameObject Snapzone;
    public GameObject Printer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void printGram()
    {
        if (Snapzone.GetComponent<VRTK.VRTK_SnapDropZone>().GetCurrentSnappedObject() != null)
        {
            Printer.GetComponent<Printer>().PrintIGS();
        }

    }
}
