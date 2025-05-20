using System;
using UnityEngine;

public class Apple : EdibleInteractable
{
    public override int SatiationPoint { get; set; }

    private void Awake()
    {
        SatiationPoint = 100; // Set the satiation point for the apple
    }

    public override bool Interact(InteractContext interactContext)
    {
        Debug.Log("YOU ATE AN APPLE!(maybe failed idk)");
        return base.Interact(interactContext);
    }
}