using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaccineBullet : MonoBehaviour
{
    public int vaccineType = 0;

    Transform tracer;
    Rigidbody rigidbody;

    Vector3 startPosition;
    Vector3 endPosition;
    bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        tracer = transform.FindChild("Tracer");
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
        endPosition = transform.position;

        tracer.localScale = Vector3.zero;
        //UpdateVisual();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collided) { return; }
        // TODO: Replace with something if multiple guns!
        if (collision.gameObject.name == "VaccineGun") { return; }
        if (collision.gameObject.name == "OVRCustomHandPrefab_R") { return; }
        if (collision.gameObject.name == "OVRCustomHandPrefab_L") { return; }
        Debug.Log(collision.gameObject.name);
        collided = true;
        rigidbody.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (!collided)
        {
            endPosition = transform.position;
        }
        
        // point the bullet in the right direction
        tracer.rotation = Quaternion.LookRotation(endPosition - startPosition);
        // put the center of the cylinder between the two points
        tracer.position = (endPosition + startPosition) / 2f;
        // set the length of the cylinder to the distance
        tracer.localScale = new Vector3(1, 1, Vector3.Distance(startPosition, endPosition));
    }
}
