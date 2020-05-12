using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatingUp : MonoBehaviour
{
    private float maxHP;
    public float currentHP;
    public bool isInFire;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        maxHP = 7;
        currentHP = maxHP;
        isInFire = false;
        rb = GetComponent<Rigidbody>();
    }

    //If sample enters fire set isInFire to true
    void onTriggerEnter(Collider other)
    {
        //Debug.Log("Sample entered the trigger");
        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            isInFire = true;
        }
    }

    //take away HP until HP = 0 then change the color of the sample 
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Sample stayed in the trigger");

        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            while (currentHP > 0)
            {
                HeatUp();
            }

            if (currentHP < 0)
            {
                currentHP = 0;
            }

            if (currentHP == 0)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    //when out of the fire set isInFire
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Sample exited the trigger");
        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            isInFire = false;
        }
    }


    //heat up method
    void HeatUp()
    {
        currentHP -= 1f * Time.deltaTime;
    }
}
