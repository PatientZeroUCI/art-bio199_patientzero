using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Events : MonoBehaviour
{
    public static Level1Events current;

    void Awake()
    {
        current = this;
    }


    //  When AI voice finishes reading intro lines
    public event Action onIntroDone;
    public void IntroDone()
    {
        if (onIntroDone != null)
        {
            onIntroDone();
        }
    }


    //  When all evidence is palced
    public event Action onEvidenceDone;
    public void EvidenceDone()
    {
        Debug.Log("Evidence Done");
        if (onEvidenceDone != null)
        {
            onEvidenceDone();
        }
    }


    //  When water is added to slide
    public event Action onSlideWet;
    public void SlideWet()
    {
        Debug.Log("Slide Wet");
        if (onSlideWet != null)
        {
            onSlideWet();
        }
    }

    //  When loop is ehated in the fire
    public event Action onLoopHeated;
    public void LoopHeated()
    {
        Debug.Log("Loop Heated");
        if (onLoopHeated != null)
        {
            onLoopHeated();
        }
    }

    //  When the heated loop applied to the wet slide
    public event Action onSampleOnSlide;
    public void SampleOnSlide()
    {
        Debug.Log("Sample On Slide");
        if (onSampleOnSlide != null)
        {
            onSampleOnSlide();
        }
    }

    //  When the slide is dried by putting it in the fire or adding waiting
    public event Action onSlideDried;
    public void SlideDried()
    {
        Debug.Log("Slide Dried");
        if (onSlideDried != null)
        {
            onSlideDried();
        }
    }

    //  When Dye is added to the slide
    public event Action onSlideDyed;
    public void SlideDyed()
    {
        Debug.Log("Slide Dyed");
        if (onSlideDyed != null)
        {
            onSlideDyed();
        }
    }

    //  When water is added tot he slide
    public event Action onSlideWashed;
    public void SlideWashed()
    {
        Debug.Log("Slide Washed");
        if (onSlideWashed != null)
        {
            onSlideWashed();
        }
    }

    //  When the heated loop applied to the wet slide
    public event Action onSlideInsertedInMicroscope;
    public void SlideInsertedInMicroscope()
    {
        Debug.Log("Slide Inserted In Microscope");
        if (onSlideWashed != null)
        {
            onSlideInsertedInMicroscope();
        }
    }


    //  When IGS phase is finished by placing the hologram gram results on the board
    public event Action onIGSDone;
    public void IGSDone()
    {
        Debug.Log("IGS Done");
        if (onIGSDone != null)
        {
            onIGSDone();
        }
    }
}
