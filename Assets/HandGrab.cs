// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Oculus;

// public class HandGrab : MonoBehaviour
// {
// public Transform grabPoint; // The place where the object will be held
// private GameObject currentGrabbableObject;
// private bool isGrabbing;

// void Update()
// {
// // Check if the hand trigger is pressed
// if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) > 0.5f && !isGrabbing)
// {
// TryGrabObject();
// }
// else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch) < 0.5f && isGrabbing)
// {
// DropObject();
// }
// }

// void TryGrabObject()
// {
// RaycastHit hit;
// if (Physics.Raycast(grabPoint.position, grabPoint.forward, out hit, 0.1f))
// {
// if (hit.collider.gameObject.CompareTag("Grabbable"))
// {
// currentGrabbableObject = hit.collider.gameObject;
// GrabObject();
// }
// }
// }

// void GrabObject()
// {
// isGrabbing = true;

// // Make the object a child of the hand
// currentGrabbableObject.transform.SetParent(grabPoint);

// // Disable the object's physics while it's being held
// Rigidbody rb = currentGrabbableObject.GetComponent<Rigidbody>();
// if (rb)
// {
// rb.isKinematic = true;
// }
// }

// void DropObject()
// {
// isGrabbing = false;

// // Remove the object from being a child of the hand
// currentGrabbableObject.transform.SetParent(null);

// // Re-enable the object's physics
// Rigidbody rb = currentGrabbableObject.GetComponent<Rigidbody>();
// if (rb)
// {
// rb.isKinematic = false;
// }

// currentGrabbableObject = null;
// }
// }
using UnityEngine;

public class HandGrabbing : MonoBehaviour
{
 public OVRInput.Controller controllerType; // Define which hand this script is for
 private bool isGrabbing;
 private Rigidbody grabbedObjectRb;

 void Update()
 {
 // Check if the grab button is pressed
 if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controllerType) > 0.5f && !isGrabbing)
 {
 RaycastHit hitInfo;
 if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 0.1f))
 {
 if (hitInfo.collider.gameObject.CompareTag("Graph"))
 {
 grabbedObjectRb = hitInfo.collider.gameObject.GetComponent<Rigidbody>();
 grabbedObjectRb.isKinematic = true;
 grabbedObjectRb.transform.SetParent(transform);
 isGrabbing = true;
 }
 }
 }
 // Release the object when the button is released
 else if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, controllerType) < 0.5f && isGrabbing)
 {
 grabbedObjectRb.transform.SetParent(null);
 grabbedObjectRb.isKinematic = false;
 grabbedObjectRb = null;
 isGrabbing = false;
 }
 }
}