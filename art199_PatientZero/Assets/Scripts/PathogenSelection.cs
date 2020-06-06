using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathogenSelection : MonoBehaviour
{
    public TextMesh Pathogen;
    private GameObject P1;
    private GameObject P2;
    private GameObject P3;
    private GameObject P4;
    public GameObject VCbutton;
    public GameObject Cbutton;
    public GameObject ECbutton;
    public GameObject BCbutton;
    public Material negative_connection;
    public Material positive_connection;
    public Material nutrual_color;
    private bool VCneutral;
    private bool VCeliminated;
    private bool VCfinalChoice;
    private bool Cneutral;
    private bool Celiminated;
    private bool CfinalChoice;
    private bool ECneutral;
    private bool ECeliminated;
    private bool ECfinalChoice;
    private bool BCneutral;
    private bool BCeliminated;
    private bool BCfinalChoice;
    public bool isSelected; //If one of the buttons is green this is set to true and will make the submit button work

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
        CfinalChoice = false;
        P3 = GameObject.Find("Pathogen 3 Text");
        ECneutral = true;
        ECeliminated = false;
        ECfinalChoice = false;
        P4 = GameObject.Find("Pathogen 4 Text");
        BCneutral = true;
        BCeliminated = false;
        BCeliminated = false;
        isSelected = false;
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
                VCneutral = false;
                VCeliminated = true;
                VCfinalChoice = false;
                if (VCeliminated == true)
                {
                    Pathogen.color = red;
                    VCbutton.GetComponent<Renderer>().material = negative_connection;
                }
            }
            else if (VCeliminated == true && P2.GetComponent<PathogenSelection>().CfinalChoice == false && P3.GetComponent<PathogenSelection>().ECfinalChoice == false && P4.GetComponent<PathogenSelection>().BCfinalChoice == false)
            {
                VCneutral = false;
                VCeliminated = false;
                VCfinalChoice = true;
                if (VCfinalChoice == true)
                {
                    Pathogen.color = green;
                    VCbutton.GetComponent<Renderer>().material = positive_connection;
                    isSelected = true;
                }
            }
            else if (VCfinalChoice == true || (VCeliminated == true && (P2.GetComponent<PathogenSelection>().CfinalChoice == true || P3.GetComponent<PathogenSelection>().ECfinalChoice == true || P4.GetComponent<PathogenSelection>().BCfinalChoice == true)))
            {
                VCneutral = true;
                VCeliminated = false;
                VCfinalChoice = false;
                if (VCneutral == true)
                {
                    Pathogen.color = grey;
                    VCbutton.GetComponent<Renderer>().material = nutrual_color;
                    isSelected = false;
                }
            }

        }

        if (Pathogen == P2.GetComponent<TextMesh>())
        {
            if (Cneutral == true)
            {
                Cneutral = false;
                Celiminated = true;
                CfinalChoice = false;
                if (Celiminated == true)
                {
                    Pathogen.color = red;
                    Cbutton.GetComponent<Renderer>().material = negative_connection;
                }
            }
            else if (Celiminated == true && P1.GetComponent<PathogenSelection>().VCfinalChoice == false && P3.GetComponent<PathogenSelection>().ECfinalChoice == false && P4.GetComponent<PathogenSelection>().BCfinalChoice == false)
            {
                Cneutral = false;
                Celiminated = false;
                CfinalChoice = true;
                if (CfinalChoice == true)
                {
                    Pathogen.color = green;
                    Cbutton.GetComponent<Renderer>().material = positive_connection;
                    isSelected = true;
                }
            }
            else if (CfinalChoice == true || (Celiminated == true && (P1.GetComponent<PathogenSelection>().VCfinalChoice == true || P3.GetComponent<PathogenSelection>().ECfinalChoice == true || P4.GetComponent<PathogenSelection>().BCfinalChoice == true)))
            {
                Cneutral = true;
                Celiminated = false;
                CfinalChoice = false;
                if (Cneutral == true)
                {
                    Pathogen.color = grey;
                    Cbutton.GetComponent<Renderer>().material = nutrual_color;
                    isSelected = false;
                }
            }
        }

        if (Pathogen == P3.GetComponent<TextMesh>())
        {
            if (ECneutral == true)
            {
                ECneutral = false;
                ECeliminated = true;
                ECfinalChoice = false;
                if (ECeliminated == true)
                {
                    Pathogen.color = red;
                    ECbutton.GetComponent<Renderer>().material = negative_connection;
                }
            }
            else if (ECeliminated == true && P1.GetComponent<PathogenSelection>().VCfinalChoice == false && P2.GetComponent<PathogenSelection>().CfinalChoice == false && P4.GetComponent<PathogenSelection>().BCfinalChoice == false)
            {
                ECneutral = false;
                ECeliminated = false;
                ECfinalChoice = true;
                if (ECfinalChoice == true)
                {
                    Pathogen.color = green;
                    ECbutton.GetComponent<Renderer>().material = positive_connection;
                    isSelected = true;
                }
            }
            else if (ECfinalChoice == true || (ECeliminated == true && (P1.GetComponent<PathogenSelection>().VCfinalChoice == true || P2.GetComponent<PathogenSelection>().CfinalChoice == true || P4.GetComponent<PathogenSelection>().BCfinalChoice == true)))
            {
                ECneutral = true;
                ECeliminated = false;
                ECfinalChoice = false;
                if (ECneutral == true)
                {
                    Pathogen.color = grey;
                    ECbutton.GetComponent<Renderer>().material = nutrual_color;
                    isSelected = false;
                }
            }
        }

        if (Pathogen == P4.GetComponent<TextMesh>())
        {
            if (BCneutral == true)
            {
                BCneutral = false;
                BCeliminated = true;
                BCfinalChoice = false;
                if (BCeliminated == true)
                {
                    Pathogen.color = red;
                    BCbutton.GetComponent<Renderer>().material = negative_connection;
                }
            }
            else if (BCeliminated == true && P1.GetComponent<PathogenSelection>().VCfinalChoice == false && P2.GetComponent<PathogenSelection>().CfinalChoice == false && P3.GetComponent<PathogenSelection>().ECfinalChoice == false)
            {
                BCneutral = false;
                BCeliminated = false;
                BCfinalChoice = true;
                if (BCfinalChoice == true)
                {
                    Pathogen.color = green;
                    BCbutton.GetComponent<Renderer>().material = positive_connection;
                    isSelected = true;
                }
            }
            else if (BCfinalChoice == true || (BCeliminated == true && (P1.GetComponent<PathogenSelection>().VCfinalChoice == true || P2.GetComponent<PathogenSelection>().CfinalChoice == true || P3.GetComponent<PathogenSelection>().ECfinalChoice == true)))
            {
                BCneutral = true;
                BCeliminated = false;
                BCfinalChoice = false;
                if (BCneutral == true)
                {
                    Pathogen.color = grey;
                    BCbutton.GetComponent<Renderer>().material = nutrual_color;
                    isSelected = false;
                }
            }

        }
    }

    //Only print to the consol is the submit button will work or not
    public void FinalSubmit()
    {
        if (P1.GetComponent<PathogenSelection>().isSelected == true || P2.GetComponent<PathogenSelection>().isSelected == true || P3.GetComponent<PathogenSelection>().isSelected == true || P4.GetComponent<PathogenSelection>().isSelected == true)
        {
            print("submit will work");
        }
        else
        {
            print("submiy wont work");
        }
    }
}
