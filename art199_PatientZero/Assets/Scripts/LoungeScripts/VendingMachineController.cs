using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineController : MonoBehaviour
{

	public GameObject referenceMenu1;
	public GameObject referenceMenu2;
	
	// Start is called before the first frame update
	void Start()
    	{	
		referenceMenu1.SetActive(false);
		referenceMenu2.SetActive(false);
	}

    	public void toggleReferences()
	{
		if (referenceMenu1.activeSelf & referenceMenu2.activeSelf) {
			referenceMenu1.SetActive(false);
			referenceMenu2.SetActive(false);
		}
		else {
			referenceMenu1.SetActive(true);
			referenceMenu2.SetActive(true);
		}
	}

}
