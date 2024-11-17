using System;
using UnityEngine;

public class InteractableButton : Interactable
{
    public GameObject triggerableObject;
    bool wasPressed = false;

    public override void Activate()
    {
        if (!wasPressed)
        {
            Debug.Log("Activating!");
            wasPressed = true;
            triggerableObject.GetComponent<Triggerable>().Trigger();
        }
    }
}
