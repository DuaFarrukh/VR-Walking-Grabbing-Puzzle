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

        interactable.onSelectEntered.AddListener(PickupObject);
    }

    private void PickupObject(XRBaseInteractor interactor)
    {
        PuzzlePieceCounter.decrementCounter();

        Destroy(this.gameObject, 1.0f);
    }
}
