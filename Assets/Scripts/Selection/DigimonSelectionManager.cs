using UnityEngine;

public class DigimonSelectionManager : MonoBehaviour
{
    public static DigimonSelectionManager Instance { get; private set; }

    [SerializeField] private DigimonStatsUI statsUI;

    private void Awake()
    {
        Instance = this;
    }

    public void Select(DigimonStats stats)
    {
        statsUI.DisplayStats(stats);
    }
}