using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{
    public TMP_Text line1Text; // Reference to the TMP_Text component for line 1
    public TMP_Text line2Text; // Reference to the TMP_Text component for line 2
    public TMP_Text line3Text; // Reference to the TMP_Text component for line 3
    private string action = ""; // String to store the current action
    private string target = ""; // String to store the current target
    private float moveDistance = 0f; // Float to store the move distance
    private Queue<string> historyQueue = new Queue<string>(); // Queue to store history actions

    public void SetAction(string newAction)
    {
        action = newAction; // Set the current action
    }

    public void SetTarget(string newTarget)
    {
        target = newTarget; // Set the current target
    }

    public void SetMoveDistance(float distance)
    {
        moveDistance = distance; // Set the move distance
    }

    public void ConfirmAction()
    {
        string actionString = "";

        if (action == "move")
        {
            actionString = "You moved " + moveDistance.ToString("F1") + "m";
        }
        else if (!string.IsNullOrEmpty(action) && !string.IsNullOrEmpty(target))
        {
            actionString = "You used " + action + " on " + target;
        }

        if (!string.IsNullOrEmpty(actionString))
        {
            // Output the action to the history
            AddToHistory(actionString);

            // Reset action, target, and moveDistance
            action = "";
            target = "";
            moveDistance = 0f;
        }
    }

    private void AddToHistory(string action)
    {
        historyQueue.Enqueue(action); // Add action to the history queue
        UpdateHistoryPanel();
    }

    private void UpdateHistoryPanel()
    {
        // Update TMP Text components with history actions from the queue
        line1Text.text = historyQueue.Count > 0 ? historyQueue.ToArray()[historyQueue.Count - 1] : "";
        line2Text.text = historyQueue.Count > 1 ? historyQueue.ToArray()[historyQueue.Count - 2] : "";
        line3Text.text = historyQueue.Count > 2 ? historyQueue.ToArray()[historyQueue.Count - 3] : "";
    }

    public void ClearHistory()
    {
        historyQueue.Clear(); // Clear the history queue
        UpdateHistoryPanel(); // Update the history panel text lines
    }
}
