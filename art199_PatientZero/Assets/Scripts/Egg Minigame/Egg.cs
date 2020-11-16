using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
	//code for when the egg enters the flashlight light and changes meshes
	public Mesh inFlashlight;
	public Mesh outFlashlight;

    void Start()
    {
    	// getting the original mesh of the egg so that when the egg exits the light it reverts 
    	// back to normal
        outFlashlight = this.gameObject.GetComponent<MeshFilter>().mesh;
    }

	void OnCollisionEnter (Collision collision) {
		if(collision.gameObject.tag == "Flashlight"){
			this.gameObject.GetComponent<MeshFilter>().mesh = inFlashlight;
		}
	}

	void OnCollisionExit (Collision collision){
		this.gameObject.GetComponent<MeshFilter>().mesh = outFlashlight;
	}
}
