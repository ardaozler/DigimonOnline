using UnityEngine;

public abstract class DigimonInteractable : MonoBehaviour
{
    
    public const float INTERACTABLE_RADIUS = 1.5f;
    public abstract InteractContext GetContext(GameObject agent);

    public virtual bool Interact(InteractContext interactContext)
    {
        Debug.Log(interactContext + " interacted");
        return true;
    }
}