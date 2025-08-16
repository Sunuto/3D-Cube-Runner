using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    private Label nameDisplay;
    private Button startButton;
    private Button renameButton;
    private Button levelButton;
    private Button highScoreButton;
    private Button quitButton;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("StartGameButton");
        renameButton = root.Q<Button>("Rename");
        levelButton = root.Q<Button>("Levels");
        highScoreButton = root.Q<Button>("highScore");
        quitButton = root.Q<Button>("Quit");
        nameDisplay = root.Q<Label>("NameDisplay");

        if (startButton == null) Debug.LogWarning("StartGameButton not found.");
        if (renameButton == null) Debug.LogWarning("Rename button not found.");
        if (levelButton == null) Debug.LogWarning("Levels button not found.");
        if (highScoreButton == null) Debug.LogWarning("highscore button not found.");
        if (quitButton == null) Debug.LogWarning("Quit button not found.");
        if (nameDisplay == null) Debug.LogWarning("NameDisplay label not found.");

        if (nameDisplay != null)
        {
            string savedName = PlayerPrefs.GetString("name", "none");
            nameDisplay.text = $"Last Name: {savedName}";
        }

        if (startButton != null)
            startButton.clicked += () => SceneManager.LoadScene("lvl1");

        if (renameButton != null)
        {
            renameButton.clicked += () => Debug.Log("Rename button clicked.");
            renameButton.clicked += () => SceneManager.LoadScene("RenameUI");

        }

        if (levelButton != null)
        { 
            levelButton.clicked += () => Debug.Log("Levels button clicked.");
            levelButton.clicked += () => SceneManager.LoadScene("LevelUI");
        }

        if (highScoreButton != null)
            highScoreButton.clicked += () => SceneManager.LoadScene("HighScoreUI");

        if (quitButton != null)
            quitButton.clicked += () =>
            {
                Debug.Log("Quit button pressed.");
                Application.Quit();
            };
    }
}
