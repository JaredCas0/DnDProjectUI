using UnityEngine;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{
    private TurnManager turnManager;

    void Start()
    {
        turnManager = FindObjectOfType<TurnManager>(); // Find TurnManager in the scene
        Button btn = GetComponent<Button>(); // Get the Button component
        btn.onClick.AddListener(EndCurrentTurn); // Add listener for button click
    }

    void EndCurrentTurn()
    {
        turnManager.EndTurn(); // End the current turn
    }
}
