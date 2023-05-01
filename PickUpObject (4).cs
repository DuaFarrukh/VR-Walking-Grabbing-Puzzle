using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUpObject : MonoBehaviour
{
    private XRGrabInteractable interactable;

    private void Start()
    {
        // Get a reference to the XRGrabInteractable component on this object
        interactable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        // Subscribe to the on select enter and exit events of the XRGrabInteractable
        interactable.onSelectEnter.AddListener(PickupObject);
        interactable.onSelectExit.AddListener(DropObject);
    }

    private void OnDisable()
    {
        // Unsubscribe from the on select enter and exit events of the XRGrabInteractable
        interactable.onSelectEnter.RemoveListener(PickupObject);
        interactable.onSelectExit.RemoveListener(DropObject);
    }

    private void PickupObject(XRBaseInteractor interactor)
    {
        // Attach the object to the interactor's attach point
        interactable.attachTransform.SetParent(interactor.transform);
        interactable.attachTransform.localPosition = Vector3.zero;
        interactable.attachTransform.localRotation = Quaternion.identity;
    }

    private void DropObject(XRBaseInteractor interactor)
    {
        // Detach the object from the interactor's attach point
        interactable.attachTransform.SetParent(null);
    }
}
