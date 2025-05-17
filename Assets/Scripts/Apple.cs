using System;
using UnityEngine;

public class Apple : Edible
{
    public override int SatiationPoint { get; set; }

    private void Awake()
    {
        SatiationPoint = 100; // Set the satiation point for the apple
    }

    public override void Eat(Digimon owner, Action onFinishEating = null)
    {
        Debug.Log("YOU ATE AN APPLE!");
        base.Eat(owner, onFinishEating);
    }
}