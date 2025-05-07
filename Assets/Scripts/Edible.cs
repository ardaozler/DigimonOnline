using UnityEngine;

public abstract class Edible
{
    public abstract float SatiationPoint { get; set; }

    public virtual void Eat()
    {
        Debug.Log("YOUR HUNGER DROPPED BY" + SatiationPoint);
    }
}

public class Apple : Edible
{
    public override float SatiationPoint { get; set; }

    public override void Eat()
    {
        base.Eat();
        Debug.Log("YOU ATE AN APPLE!");
    }
}