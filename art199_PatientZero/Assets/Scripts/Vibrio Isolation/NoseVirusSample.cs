using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseVirusSample : MonoBehaviour
{
	//public GameObject nose;

	//public var Sneezing : AudioSource;

	void OnCollisionEnter(Collision collider)
	{
	    if(collider.gameObject.tag == "tool")
	    {
	     	Debug.Log(collider.gameObject.name);
	        //add the code you want to execute on collision
	        //to access the Ball gameObject use : col.gameObject
	    }
	 }

}
