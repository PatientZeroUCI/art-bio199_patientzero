using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSelection : MonoBehaviour
{
    public TextMesh Pathogen;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public bool VCneutral;
    public bool VCeliminated;
    public bool VCfinalChoice;
    private bool Cneutral;
    private bool Celiminated;
    private bool CfinalChoice;
    private bool ECneutral;
    private bool ECeliminated;
    private bool ECfinalChoice;
    private bool BCneutral;
    private bool BCeliminated;
    private bool BCfinalChoice;

    //Starts off all pathogens in nutral state
    void Start()
    {
        P1 = GameObject.Find("Pathogen 1 Text");
        VCneutral = true;
        VCeliminated = false;
        VCfinalChoice = false;
        P2 = GameObject.Find("Pathogen 2 Text");
        Cneutral = true;
        Celiminated = false;
        CfinalChoice = true;
        P3 = GameObject.Find("Pathogen 3 Text");
        ECneutral = true;
        ECeliminated = false;
        ECfinalChoice = false;
        P4 = GameObject.Find("Pathogen 4 Text");
        BCneutral = true;
        BCeliminated = false;
        BCeliminated = false;
    }

    public void Selection()
    {
        Color32 grey = new Color32(173, 166, 166, 255);
        Color32 red = new Color32(255, 102, 71, 255);
        Color32 green = new Color32(71, 255, 182, 255);
        Pathogen = GetComponent<TextMesh>();

        if (Pathogen == P1.GetComponent<TextMesh>())
        {

            if (VCneutral == true)
            {
                print("Switching to eliminate p1");
                VCneutral = false;
                VCeliminated = true;
                VCfinalChoice = false;
                Pathogen.color = red;
            }
            else if (VCeliminated == true)
            {
                print("Switching to final choice p1");
                VCneutral = false;
                VCeliminated = false;
                VCfinalChoice = true;
                Pathogen.color = green;
            }
            else if (VCfinalChoice == true)
            {
                print("Switching to nutral p1");
                VCneutral = true;
                VCeliminated = false;
                VCfinalChoice = false;
                Pathogen.color = grey;
            }

        }

        if (Pathogen == P2.GetComponent<TextMesh>())
        {
            if (Cneutral == true)
            {
                print("Switching to eliminate p2");
                Cneutral = false;
                Celiminated = true;
                CfinalChoice = false;
                Pathogen.color = red;
            }
            else if (Celiminated == true)
            {
                Cneutral = false;
                Celiminated = false;
                CfinalChoice = true;
                Pathogen.color = green;
            }
            else if (CfinalChoice == true)
            {
                Cneutral = true;
                Celiminated = false;
                CfinalChoice = false;
                Pathogen.color = grey;
            }
        }

        if (Pathogen == P3.GetComponent<TextMesh>())
        {
            if (ECneutral == true)
            {
                print("Switching to eliminate p3");
                ECneutral = false;
                ECeliminated = true;
                ECfinalChoice = false;
                Pathogen.color = red;
            }
            else if (ECeliminated == true)
            {
                ECneutral = false;
                ECeliminated = false;
                ECfinalChoice = true;
                Pathogen.color = green;
            }
            else if (ECfinalChoice == true)
            {
                ECneutral = true;
                ECeliminated = false;
                ECfinalChoice = false;
                Pathogen.color = grey;
            }
        }

        if (Pathogen == P4.GetComponent<TextMesh>())
        {
            if (BCneutral == true)
            {
                print("Switching to eliminate p4");
                BCneutral = false;
                BCeliminated = true;
                BCfinalChoice = false;
                Pathogen.color = red;
            }
            else if (BCeliminated == true)
            {
                BCneutral = false;
                BCeliminated = false;
                BCfinalChoice = true;
                Pathogen.color = green;
            }
            else if (BCfinalChoice == true)
            {
                BCneutral = true;
                BCeliminated = false;
                BCfinalChoice = false;
                Pathogen.color = grey;
            }
        }
    }
}
