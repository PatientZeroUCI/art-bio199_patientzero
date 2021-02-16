using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject egg;
    public Mesh cut_eggMesh;

    private bool[] ColliderTriggers = new bool[8];
    private bool CutSuccessful = false;
    // Update is called once per frame
    void Start()
    {
        ColliderTriggers[0] = false;
        ColliderTriggers[1] = false;
        ColliderTriggers[2] = false;
        ColliderTriggers[3] = false;
        ColliderTriggers[4] = false;
        ColliderTriggers[5] = false;
        ColliderTriggers[6] = false;
        ColliderTriggers[7] = false;
    }
    public void HitCollider(int collider_num)
    {
        ColliderTriggers[collider_num] = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ScalpelBlade")
        {
            StartCoroutine(CutCheck());
        }
    }
    
    IEnumerator CutCheck()
    {
        //Debug.Log("Still in Outer Collider...");

        for (int i = 0; i < ColliderTriggers.Length; i++)
        {
            if (!ColliderTriggers[i])
            {
                break;
            }
            if (i == ColliderTriggers.Length - 1)
            {
                Debug.Log("Cut all hitboxes!");
                CutSuccessful = true;
            }
        }
        if (CutSuccessful)
        {
            MeshFilter egg_mesh = egg.gameObject.GetComponent<MeshFilter>();
            egg_mesh.mesh = cut_eggMesh;
        }
        return null;
    }

    /*
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ScalpelBlade")
        {
            Debug.Log("Left the cutting zone...!");
            for (int i = 0; i < ColliderTriggers.Length; i++)
            {
                ColliderTriggers[i] = false;
            }
        }
    }*/
}
