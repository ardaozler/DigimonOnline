using UnityEngine;

public abstract class Edible
{
    public abstract float SatiationPoint { get; set; }

    public virtual void Eat()
    {
        Debug.Log("YOUR HUNGER DROPPED BY" + SatiationPoint);
    }
}