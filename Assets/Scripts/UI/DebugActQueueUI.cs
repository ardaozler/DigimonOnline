using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugActQueueUI : MonoBehaviour 
{
    
    public static DebugActQueueUI Instance;
    
    public TextMeshProUGUI actTextPrefab;
    public GameObject actsContainer;
    public Queue<TextMeshProUGUI> actTexts = new Queue<TextMeshProUGUI>();
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddActionText(string text)
    {
        var actText = Instantiate(actTextPrefab, actsContainer.transform);
        actText.text = text;
        actTexts.Enqueue(actText);
    }
    
    public void ClearActions()
    {
        while (actTexts.Count > 0)
        {
            var actText = actTexts.Dequeue();
            Destroy(actText.gameObject);
        }
    }
    
    public void RemoveLastActionText()
    {
        if (actTexts.Count > 0)
        {
            var actText = actTexts.Dequeue();
            Destroy(actText.gameObject);
        }
    }
    
    
}