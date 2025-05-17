using System;
using System.Collections;
using UnityEngine;

public abstract class Edible : MonoBehaviour
{
    public bool isBeingEaten;
    private Digimon _owner; //is the one eating
    public abstract int SatiationPoint { get; set; }

    public virtual void Eat(Digimon owner, Action onFinishEating = null)
    {
        isBeingEaten = true;
        _owner = owner;

        //some animation or effect here
        StartCoroutine(Dispose(onFinishEating));
    }

    public virtual IEnumerator Dispose(Action onDispose)
    {
        yield return new WaitForSeconds(2);

        // Call the action to dispose of the object
        onDispose?.Invoke();
        _owner.Hunger -= SatiationPoint;
        Debug.Log("YOUR HUNGER DROPPED BY" + SatiationPoint);
        // Optionally, destroy the object after disposal
        Destroy(gameObject);
    }
}