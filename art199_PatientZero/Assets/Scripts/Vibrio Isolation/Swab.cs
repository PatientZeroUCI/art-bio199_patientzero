using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Swab : VRTK_InteractableObject
{
    // private uint 
    // private VRTK_ControllerReference controller;

    public PetriDish petriDish;
    private RaycastHit swabTouching;
    public int swabTipSize = 5;
    public float tipHeight = 1.0f;
    public GameObject hologram;
    public GameObject virus;


    public Color swabColor = Color.green;
    

    private bool lastTouch;
    private Quaternion lastAngle;

	private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        // controller = VRTK_ControllerReference.GetControllerReference();
        // petriDish = GameObject.Find("PetriDish").GetComponent<PetriDish>();

        
    }

    // Update is called once per frame
    override protected void Update()
    {
  
        // float tipHeight = transform.Find("Tip").transform.localScale.y;
        Vector3 tip = transform.Find("Tipper").transform.position;
        // tipHeight should be last parameter...
        if (Physics.Raycast(tip, transform.TransformDirection(Vector3.down), out swabTouching, tipHeight)) 
        {
            if (!swabTouching.collider.gameObject.CompareTag("PetriDish"))
            {
                
                return; // we want to break out of this if it's not touching petri dish
            }

            // VRTK_ControllerHaptics.TriggerHapticPulse(controller, 0.1f); // haptic feedback

            //UnityEngine.Debug.Log("Pass Raycast");
            UnityEngine.Debug.Log(swabTouching.textureCoord.x.ToString() + " | " + swabTouching.textureCoord.y.ToString());

            petriDish = swabTouching.collider.gameObject.GetComponent<PetriDish>();
            petriDish.setSwabSize(swabTipSize);
            petriDish.SetColor(swabColor);
            petriDish.SetTouchPosition(swabTouching.textureCoord.x, swabTouching.textureCoord.y);
            petriDish.ToggleSwab(true);

            if (!lastTouch)
            {
                lastTouch = true;
                lastAngle = transform.rotation;
            }
        }

        else
        {
            UnityEngine.Debug.Log(swabTouching.collider.gameObject.name);
            UnityEngine.Debug.Log("not passing");
            if (petriDish != null)
            {
                petriDish.ToggleSwab(false);
                lastTouch = false;
            }
            
        }
        

        if (lastTouch)
        {
            transform.rotation = lastAngle;
        }
    }


	void OnTriggerEnter(Collider col)
	{
		// If the virus is not on the swab yet (not active)
		if(virus.activeSelf == false)
		{
		    if(col.gameObject.name == "Nose")
		    {
		    	audio = GetComponent<AudioSource>();
		    	virus.SetActive(true);
		     	Debug.Log(col.gameObject.name);
		     	audio.Play();
		    }
            // For PCR minigame
            if(col.gameObject.name == hologram.name)
		    {
		    	col.gameObject.SetActive(false);
		    	virus.SetActive(true);
		    }
		}
		else
		{
			if(col.gameObject.name == "Nose")
			{
				virus.SetActive(false);
				col.transform.GetChild(0).gameObject.SetActive(true);
			}
		}
	 }
}
