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
        maxHP = 5;
        currentHP = maxHP;
        isInFire = false;
        rb = GetComponent<Rigidbody>();
    }

    void update()
    {
    }
    //If sample enters fire set isInFire to true
    void onTriggerEnter(Collider other)
    {
        print("Sample entered the trigger");
        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            isInFire = true;
        }
    }

    //take away HP until HP = 0 then change the color of the sample 
    void OnTriggerStay(Collider other)
    {
        print("Sample stayed in the trigger");

        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            if (currentHP > 0)
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
        print("Sample exited the trigger");
        if (other.gameObject.CompareTag("Fire Hitbox"))
        {
            isInFire = false;
        }
    }


    //heat up method
    void HeatUp()
    {
        currentHP -= Time.deltaTime;

    }
}
