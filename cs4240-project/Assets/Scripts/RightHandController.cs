using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTC.UnityPlugin.Vive;
using HTC.UnityPlugin.Utility;
using HTC.UnityPlugin.VRModuleManagement;

public class RightHandController : MonoBehaviour
{
    public float grabRadius;
    public LayerMask grabMask; // only objects in this layer can be grabbed

    private GameObject grabbedObject;
    private bool grabbing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!grabbing && ViveInput.GetAxis(HandRole.RightHand, ControllerAxis.Trigger) == 1f)
        {
            GrabObject();
        }

        if (grabbing && ViveInput.GetPressDown(HandRole.RightHand, ControllerButton.Grip))
        {
            DropObject();
        }
    }

    public GameObject GetGrabbedObject()
    {
        return grabbedObject;
    }

    void GrabObject()
    {
        RaycastHit[] hits;

        hits = Physics.SphereCastAll(transform.position, grabRadius, transform.forward, 0f, grabMask);

        if (hits.Length > 0)
        {
            // there is something within range to grab
            grabbing = true;

            // find closest hit/object
            int closestHit = 0;

            for (int i = 0; i < hits.Length; i++)
            {
                if ((hits[i]).distance < hits[closestHit].distance)
                {
                    closestHit = i;
                }
            }

            grabbedObject = hits[closestHit].transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().isKinematic = true; // grabbedObject is not affected by gravity
            grabbedObject.transform.position = transform.position + transform.forward.normalized; // grabbedObject will be set at the offset
            grabbedObject.transform.rotation = transform.rotation; // set rotation of object to the parent's rotation
            grabbedObject.transform.parent = transform; // grabbedObject set as child of the controller so will move together
            grabbedObject.GetComponent<GrabbableBehaviour>().grabbed = true;
        }
    }

    void DropObject()
    {
        grabbedObject.GetComponent<GrabbableBehaviour>().grabbed = false;
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.parent = null;
        grabbedObject = null;
        grabbing = false;
    }
}