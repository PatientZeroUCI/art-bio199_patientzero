using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject egg;
    public Mesh cut_eggMesh;

    public bool[] ColliderTriggers = new bool[2];
    private bool CutSuccessful = false;
    private Egg eggScript;
    // Update is called once per frame
    void Start()
    {
        eggScript = egg.GetComponent<Egg>();

        ColliderTriggers[0] = false;
        ColliderTriggers[1] = false;
        // ColliderTriggers[2] = false;
        // ColliderTriggers[3] = false;

    }

    // void Update()
    // {
    //     for (int i = 0; i < 4; i++)
    //         {
    //             UnityEngine.Debug.Log(i + " " + ColliderTriggers[i]);
    //         }
    //         if (checkCut())
    //         {
    //             MeshFilter egg_mesh = egg.gameObject.GetComponent<MeshFilter>();
    //             egg_mesh.mesh = cut_eggMesh;
    //             eggScript.setEggState(true);
    //         }
    // }
    
    public void HitCollider(int collider_num)
    {
        ColliderTriggers[collider_num] = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.Log(other.name);
        if (other.name == "ScalpelBlade")
        {
            // for (int i = 0; i < 2; i++)
            // {
            //     UnityEngine.Debug.Log(i + " " + ColliderTriggers[i]);
            // }
            // if (checkCut())
            // {
            //     MeshFilter egg_mesh = egg.gameObject.GetComponent<MeshFilter>();
            //     egg_mesh.mesh = cut_eggMesh;
            //     eggScript.setEggState(true);
            // }
            //StartCoroutine(CutCheck());
        }
    }
    
    private bool checkCut()
    {
        for (int i = 0; i < 2; i++)
        {
            if (ColliderTriggers[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    // IEnumerator CutCheck()
    // {
    //     //Debug.Log("Still in Outer Collider...");

    //     for (int i = 0; i < ColliderTriggers.Length; i++)
    //     {
    //         if (!ColliderTriggers[i])
    //         {
    //             break;
    //         }
    //         UnityEngine.Debug.Log(i + " " + ColliderTriggers[i]);
    //         if (i == ColliderTriggers.Length - 1)
    //         {
    //             Debug.Log("Cut all hitboxes!");
    //             CutSuccessful = true;
    //         }
    //     }
    //     if (CutSuccessful)
    //     {
    //         MeshFilter egg_mesh = egg.gameObject.GetComponent<MeshFilter>();
    //         egg_mesh.mesh = cut_eggMesh;
    //         eggScript.setEggState(true);
    //     }
    //     return null;
    // }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ScalpelBlade")
        {
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Debug.Log(i + " " + ColliderTriggers[i]);
            }
            if (checkCut())
            {
                MeshFilter egg_mesh = egg.gameObject.GetComponent<MeshFilter>();
                egg_mesh.mesh = cut_eggMesh;
                eggScript.setEggState(true);
            }
        }
    }
}
