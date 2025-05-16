using UnityEngine;

public class Apple : Edible
{
    public override float SatiationPoint { get; set; }

    public override void Eat()
    {
        base.Eat();
        Debug.Log("YOU ATE AN APPLE!");
    }
}