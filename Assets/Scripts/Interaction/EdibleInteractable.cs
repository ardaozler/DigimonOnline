using System;
using System.Collections;
using UnityEngine;

public abstract class EdibleInteractable : DigimonInteractable
{
    public bool IsBeingEaten { get; private set; }

    public abstract int SatiationPoint { get; set; }

    private Digimon _eater;

    public override InteractContext GetContext(GameObject agent)
    {
        return new EdibleInteractContext(agent);
    }

    public override bool Interact(InteractContext interactContext, Action onInteractionCompleted)
    {
        if (interactContext is not EdibleInteractContext edibleContext)
        {
            Debug.LogError("Invalid context for Edible interaction.");
            return false;
        }
        
        if (IsBeingEaten) return false;
        
        
        IsBeingEaten = true;
        _eater = edibleContext.Agent.GetComponent<Digimon>();

        // Optionally trigger animation or effect here

        StartCoroutine(HandleConsumption(onInteractionCompleted));
        return true;
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