using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HistoryManager : MonoBehaviour
{
    public TMP_Text line1Text; // Reference to the TMP_Text component for line 1
    public TMP_Text line2Text; // Reference to the TMP_Text component for line 2
    public TMP_Text line3Text; // Reference to the TMP_Text component for line 3

    private Queue<string> historyQueue = new Queue<string>(); // Queue to store history actions

    private void Start()
    {
        // Initialize history panel text lines
        UpdateHistoryPanel();
    }

    public void AddActionToHistory(string action)
    {
        AddToHistory(action);
        UpdateHistoryPanel();
    }

    public void ClearHistory()
    {
        historyQueue.Clear(); // Clear the history queue
        UpdateHistoryPanel(); // Update the history panel text lines
    }

    private void AddToHistory(string action)
    {
        historyQueue.Enqueue(action); // Add action to the history queue
    }

    private void UpdateHistoryPanel()
    {
        // Update text lines with history actions from the queue
        line1Text.text = historyQueue.Count > 0 ? historyQueue.ToArray()[historyQueue.Count - 1] : "";
        line2Text.text = historyQueue.Count > 1 ? historyQueue.ToArray()[historyQueue.Count - 2] : "";
        line3Text.text = historyQueue.Count > 2 ? historyQueue.ToArray()[historyQueue.Count - 3] : "";
    }
}
