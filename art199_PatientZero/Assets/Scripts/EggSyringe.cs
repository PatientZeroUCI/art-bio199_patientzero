using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSyringe : MonoBehaviour
{
    [SerializeField]
    private GameObject Egg;  // The egg to poke
    [SerializeField]
    private GameObject PokeZone;  // Where the syringe has to poke

    private bool goodPoke;  // Whether or not the player has inserted the needle into the PokeZone first
    private bool badPoke;  //Whether or not the player has inserted the needle into the rest of the Egg first


    // Start is called before the first frame update
    void Start()
    {
        // Make sure the two parts of the egg don't collide
        Physics.IgnoreCollision(Egg.GetComponent<Collider>(), PokeZone.GetComponent<Collider>());

        goodPoke = false;
        badPoke = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision obj)
    {
        //Debug.Log(obj.gameObject.name);

        //if (obj.gameObject == PokeZone)
        //{
        //    Debug.Log("Good");
        //}
    }

    private void OnTriggerEnter(Collider obj)
    {
        // When the needle enters the PokeZone and hasn't entered the rest of the Egg first
        if ((obj.gameObject == PokeZone) && !badPoke)
        {
            Debug.Log("Good");
            goodPoke = true;

            // Call anything you need when a succesful poke is made
        }

        // When the needle enters the Egg and hasn't entered the PokeZone first
        if ((obj.gameObject == Egg) && !goodPoke)
        {
            Debug.Log("Bad");
            badPoke = true;

            // Call anything you need when a bad poke is made
        }
    }


    private void OnTriggerExit(Collider obj)
    {
        // When the needle leaves the PokeZone
        if (obj.gameObject == PokeZone)
        {
            goodPoke = false;
        }

        // When the needle leaves the Egg
        if (obj.gameObject == Egg)
        {
            badPoke = false;
        }
    }
}
