using UnityEngine;
using UnityEngine.UI;

public class TurnManager : MonoBehaviour
{
    public enum TurnState { PlayerTurn, EnemyTurn }; // Define turn states
    public TurnState currentTurn; // Current turn state
    public GameObject playerToken; // Reference to player token UI GameObject
    public GameObject enemyToken; // Reference to enemy token UI GameObject
    public GameObject playerCharacter; // Reference to player character GameObject
    public GameObject enemyCharacter; // Reference to enemy character GameObject
    public Camera mainCamera; // Reference to the main camera
    public GameObject[] turnOrderTokens; // Array of turn order token GameObjects

    void Start()
    {
        currentTurn = TurnState.PlayerTurn; // Start with player's turn
        SetTokenColors(); // Set token colors based on the current turn
        CenterCameraOnCharacter(playerCharacter); // Center camera on player character at start
    }

    public void EndTurn()
    {
        // Switch turn
        if (currentTurn == TurnState.PlayerTurn)
        {
            currentTurn = TurnState.EnemyTurn;
            Debug.Log("Enemy's Turn");
            SetTokenColors(); // Set token colors based on the current turn
            CenterCameraOnCharacter(enemyCharacter); // Center camera on enemy character
            // Implement enemy actions here
        }
        else if (currentTurn == TurnState.EnemyTurn)
        {
            currentTurn = TurnState.PlayerTurn;
            Debug.Log("Player's Turn");
            SetTokenColors(); // Set token colors based on the current turn
            CenterCameraOnCharacter(playerCharacter); // Center camera on player character
            // Implement player actions here
        }
    }

    void CenterCameraOnCharacter(GameObject character)
    {
        // Center the camera on the character
        if (character != null && mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, mainCamera.transform.position.z);
        }
    }

    void SetTokenColors()
    {
        // Set token colors based on the current turn
        Color defaultColor = Color.white;
        Color darkColor = new Color(0.5f, 0.5f, 0.5f); // Darker color

        foreach (GameObject token in turnOrderTokens)
        {
            Image tokenImage = token.GetComponent<Image>();

            if (token.name == "TPlayerToken" && currentTurn == TurnState.PlayerTurn)
            {
                tokenImage.color = defaultColor;
            }
            else if (token.name == "TPlayerToken")
            {
                tokenImage.color = darkColor;
            }

            if (token.name == "TEnemyToken" && currentTurn == TurnState.EnemyTurn)
            {
                tokenImage.color = defaultColor;
            }
            else if (token.name == "TEnemyToken")
            {
                tokenImage.color = darkColor;
            }
        }
    }
}
