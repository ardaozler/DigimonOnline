using UnityEngine;

[RequireComponent(typeof(Collider))]
public class DigimonSelectable: MonoBehaviour
{
    public DigimonStats stats;

    private void OnMouseDown()
    {
        if (stats != null)
        {
            DigimonSelectionManager.Instance.Select(stats);
        }
    }
}