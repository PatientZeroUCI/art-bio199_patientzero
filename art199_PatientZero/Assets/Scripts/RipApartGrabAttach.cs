using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK.GrabAttachMechanics
{
    public class RipApartGrabAttach : VRTK_ChildOfControllerGrabAttach
    {
        public VRTK_InteractableObject parent;
        bool rippedFromParent = false;

        private Vector3 basePosition;
        private Vector3 grabPoint;
        public Collider collider;

        protected override void Initialise()
        {
            base.Initialise();
            collider = GetComponent<Collider>();
            basePosition = this.transform.localPosition;
        }

        protected override void SnapObjectToGrabToController(GameObject obj)
        {
            base.SnapObjectToGrabToController(obj);
            grabPoint = obj.transform.localPosition;
        }


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
                    // average between the hand's position and the original position
                    transform.position = (transform.parent.TransformPoint(grabPoint) + parent.transform.TransformPoint(basePosition)) / 2;
                }
                else
                {
                    transform.localPosition = transform.localPosition * 0.8f + grabPoint * 0.2f;
                }
            }
        }

        public override void ProcessFixedUpdate()
        {
            if (!rippedFromParent)
            {
                if (Vector3.Distance(grabbedObject.transform.position, parent.transform.position) > 0.2)
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