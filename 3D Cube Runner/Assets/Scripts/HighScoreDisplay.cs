using UnityEngine;
using UnityEngine.UIElements;

public class HighScoreDisplay : MonoBehaviour
{
    private Label highScoreLabel;
    private Label nameLabel;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        highScoreLabel = root.Q<Label>("HighScore"); // Make sure this name matches the UI element name in the UI Builder
        nameLabel = root.Q<Label>("PlayerName");    // Make sure this name matches the UI element name in the UI Builder

        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        string playerName = PlayerPrefs.GetString("name", "Guest"); // Match the key name with the one used in NameDisplayUI

        // Display the high score
        highScoreLabel.text = "High Score: " + highScore.ToString("0");

        // Display the player name
        nameLabel.text = "Player Name: " + playerName;
    }
}
