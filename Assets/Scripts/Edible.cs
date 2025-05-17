using UnityEngine;

public abstract class Edible : MonoBehaviour
{
    public bool isBeingEaten;
    public abstract float SatiationPoint { get; set; }

    public virtual void Eat()
    {
        isBeingEaten = true;
        Debug.Log("YOUR HUNGER DROPPED BY" + SatiationPoint);
    }
}