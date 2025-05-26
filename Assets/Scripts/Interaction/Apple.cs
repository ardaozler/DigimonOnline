using System;
using UnityEngine;

public class Apple : EdibleInteractable
{
    public override int SatiationPoint { get; set; }

    private void Awake()
    {
        SatiationPoint = 100; // Set the satiation point for the apple
    }

    public override bool Interact(InteractContext interactContext, Action onInteractionCompleted = null)
    {
        if (interactContext is not EdibleInteractContext edibleContext)
        {
            Debug.LogError("Invalid context for Apple interaction.");
            return false;
        }

        return base.Interact(interactContext, onInteractionCompleted);
    }
}