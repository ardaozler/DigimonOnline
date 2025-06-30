using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugActQueueUI : MonoBehaviour
{
    public static DebugActQueueUI Instance;

    public TextMeshProUGUI queueCountText;

    public TextMeshProUGUI actTextPrefab;
    public GameObject actsContainer;
    public Queue<TextMeshProUGUI> actTexts = new Queue<TextMeshProUGUI>();

    private Queue<(DigimonAction, ActContext)> _actionQueue = new Queue<(DigimonAction, ActContext)>();

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

        InvokeRepeating(nameof(UpdateActionsList), 0, 0.2f);
    }

    private void UpdateActionsList()
    {
        ClearActions();

        if (_actionQueue.Count == 0)
        {
            AddActionText("No actions in queue.");
            return;
        }

        foreach (var (action, context) in _actionQueue)
        {
            AddActionText($"{action.GetType().Name} - {context}");
        }
    }

    private void Update()
    {
        queueCountText.text = actTexts.Count + "";
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

    public void DisplayActionQueue(ref Queue<(DigimonAction, ActContext)> queue)
    {
        ClearActions();
        _actionQueue = queue;
    }
}