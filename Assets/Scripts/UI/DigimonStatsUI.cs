using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DigimonStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider cleanlinessSlider;
    [SerializeField] private Slider happinessSlider;
    private DigimonStats _stats;

    private void Start()
    {
        InvokeRepeating(nameof(UpdateStats), 0, .5f);
    }

    public void DisplayStats(DigimonStats stats)
    {
        nameText.text = stats.gameObject.name;
        _stats = stats;
        gameObject.SetActive(true);
    }

    public void UpdateStats()
    {
        if (_stats == null) return;

        hungerSlider.value = _stats.Hunger / 100f;
        cleanlinessSlider.value = _stats.Cleanliness / 100f;
        happinessSlider.value = _stats.Happiness / 100f;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _stats = null;
    }
}