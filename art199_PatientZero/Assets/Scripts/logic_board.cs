using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_board : MonoBehaviour
{
    public GameObject unit1;
    public GameObject unit2;
    public GameObject unit3;
    public GameObject unit4;
    public GameObject unit5;

    public Material wrong_connection;
    public Material good_connection;

    // Start is called before the first frame update
    void Start()
    {
        //wrong_connection = Resources.Load<Material>("negative_connection");
        //good_connection = Resources.Load<Material>("positive_connection");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.name == "Brain")
        {
            GameObject connector = unit1.transform.GetChild(1).gameObject;
            Renderer connector_renderer = connector.GetComponent<Renderer>();
            connector_renderer.material = good_connection;
        }
        Debug.Log(collider.name);
    }
}
