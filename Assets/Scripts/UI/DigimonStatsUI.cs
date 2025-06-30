using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigimonStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private TMP_Text hungerRate;
    [SerializeField] private Slider cleanlinessSlider;
    [SerializeField] private TMP_Text cleanlinessRate;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private TMP_Text happinessRate;
    [SerializeField] private GameObject statsPanelParent;


    private DigimonStats _stats;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateStats), 0, .5f);
    }

    public void DisplayStats(DigimonStats stats)
    {
        nameText.text = stats.gameObject.name;
        hungerRate.text = $"-{stats.hungerTickSpeed:F2}/s";
        cleanlinessRate.text = $"-{stats.cleanlinessTickSpeed:F2}/s";
        happinessRate.text = $"-{stats.happinessTickSpeed:F2}/s";
        _stats = stats;

        UpdateStats();
        statsPanelParent.SetActive(true);

        //Invoke(nameof(HideStats), 10f);
    }

    private void HideStats()
    {
        statsPanelParent.SetActive(false);
        _stats = null;
    }


    public void UpdateStats()
    {
        if (_stats == null) return;

        hungerSlider.value = _stats.Hunger / 100f;
        cleanlinessSlider.value = _stats.Cleanliness / 100f;
        happinessSlider.value = _stats.Happiness / 100f;
    }
}