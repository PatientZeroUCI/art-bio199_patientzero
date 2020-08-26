using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

public class RotatingQueue : MonoBehaviour
{
    public Material[] possible_materials;
    public VRTK_PhysicsPusher attached_button;
    public GameObject screen_surface;
    public RotatingQueue[] connected_lists;

    private bool pressed;
    public int curr_material;
    private Material current_material;


    // Start is called before the first frame update

    private void Start()
    {
        curr_material = 0;
        //possible_materials = new Material[material_amount];
    }
    // Update is called once per frame
    void Update()
    {
        if (attached_button.GetValue() <= -0.025 & pressed == false)
        {
            for(int reset = 0; reset < connected_lists.Length; reset++)
            {
                connected_lists[reset].curr_material = 0;
            }
            pressed = true;
            StartCoroutine(MaterialSwap());
        }
    }

    IEnumerator MaterialSwap()
    {


        if (curr_material >= possible_materials.Length)
        {
            curr_material = 0;
        }


        screen_surface.GetComponent<MeshRenderer>().material = possible_materials[curr_material];
        curr_material += 1;

        yield return new WaitForSeconds(0.5f);

        pressed = false;
    }
}
