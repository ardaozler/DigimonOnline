using System;
using UnityEngine;

public class Apple : Edible
{
    public override int SatiationPoint { get; set; }

    public override void Eat(Digimon owner, Action onFinishEating = null)
    {
        Debug.Log("YOU ATE AN APPLE!");
        base.Eat(owner, onFinishEating);
    }
}