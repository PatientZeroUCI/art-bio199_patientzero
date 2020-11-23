using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
    public class RipApartGrabAttach : VRTK_ChildOfControllerGrabAttach
    {
        public VRTK_InteractableObject parent;
        bool rippedFromParent = false;

        public Vector3 basePosition;
        public Collider collider;

        protected override void Initialise()
        {
            base.Initialise();
            collider = GetComponent<Collider>();
            basePosition = this.transform.localPosition;
        }

        //public override bool StartGrab(GameObject grabbingObject, GameObject givenGrabbedObject, Rigidbody givenControllerAttachPoint)
        //{
        //    if (parent.IsGrabbed() || rippedFromParent)
        //    {
        //        return base.StartGrab(grabbingObject, givenGrabbedObject, givenControllerAttachPoint);
        //    }
        //    return false;
        //}


        public void FixedUpdate()
        {
            if (!rippedFromParent)
            {
                collider.enabled = parent.IsGrabbed();
            }

            if (grabbedObject == null)
            {
                if (!rippedFromParent)
                {
                    transform.localPosition = transform.localPosition * 0.8f + basePosition * 0.2f;
                }
            }
            else
            {
                if (!rippedFromParent)
                {
                    transform.position = (transform.parent.position + parent.transform.TransformPoint(basePosition)) / 2;
                }
                else
                {
                    transform.localPosition = transform.localPosition * 0.8f;
                }
            }
        }

        public override void ProcessFixedUpdate()
        {
            if (!rippedFromParent)
            {
                if (Vector3.Distance(grabbedObject.transform.position, parent.transform.position) > 0.5)
                {
                    Debug.Log("rip");
                    rippedFromParent = true;

                    Transform previousParent;
                    parent.GetPreviousState(out previousParent, out _, out _); // this script's parent's parent.
                    bool previousKinematic, previousGrabbable;
                    grabbedObjectScript.GetPreviousState(out _, out previousKinematic, out previousGrabbable);
                    grabbedObjectScript.OverridePreviousState(previousParent, previousKinematic, previousGrabbable);
                }
            }
            base.ProcessFixedUpdate();
        }
    }
}