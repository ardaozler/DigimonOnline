using System;
using System.Collections;
using UnityEngine;

public abstract class Edible : MonoBehaviour
{
    public bool IsBeingEaten { get; private set; }

    public abstract int SatiationPoint { get; set; }

    private Digimon _eater;

    public virtual void Eat(Digimon eater, Action onFinishEating = null)
    {
        if (IsBeingEaten) return;

        IsBeingEaten = true;
        _eater = eater;

        // Optionally trigger animation or effect here

        StartCoroutine(HandleConsumption(onFinishEating));
    }

    protected virtual IEnumerator HandleConsumption(Action onFinishEating)
    {
        Debug.Log("Starting to eat...");
        yield return new WaitForSeconds(1f);

        Debug.Log("Finished eating!");

        onFinishEating?.Invoke();

        if (_eater != null)
        {
            // Reduce hunger, assuming it's exposed via property or method
            _eater.GetComponent<DigimonStats>()?.UpdateUrge("Hunger", SatiationPoint);
            Debug.Log($"Hunger reduced by {SatiationPoint} for {_eater.name}");
        }

        Destroy(gameObject, 0.5f);
    }
}