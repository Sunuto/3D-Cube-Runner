using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public UIDocument completeLevelUIDocument;  // Assign in Inspector
    public UIDocument gameOverUIDocument;       // Assign in Inspector

    private VisualElement completeRoot;
    private VisualElement gameOverRoot;

    private Button restartButton;
    private Button menuButton;

    private bool gameHasEnded = false;
    private bool levelCompleted = false;

    public bool GameHasEnded => gameHasEnded;
    public bool LevelCompleted => levelCompleted;

    void OnEnable()
    {
        // Setup Complete UI
        if (completeLevelUIDocument != null)
        {
            completeRoot = completeLevelUIDocument.rootVisualElement;
            completeRoot.style.display = DisplayStyle.None;

            Button completeMenuButton = completeRoot.Q<Button>("Menu");
            if (completeMenuButton != null)
            {
                completeMenuButton.clicked += GoToMainMenu;
            }
        }

        // Setup Game Over UI
        if (gameOverUIDocument != null)
        {
            gameOverRoot = gameOverUIDocument.rootVisualElement;
            gameOverRoot.style.display = DisplayStyle.None;

            restartButton = gameOverRoot.Q<Button>("Restart");
            menuButton = gameOverRoot.Q<Button>("Menu");

            if (restartButton != null)
                restartButton.clicked += RestartLevel;
            else
                Debug.LogWarning("Restart button not found!");

            if (menuButton != null)
                menuButton.clicked += GoToMainMenu;
            else
                Debug.LogWarning("Menu button not found!");
        }
    }

    void Update()
    {
        // Keyboard shortcuts (only work when game over or completed)
        if (gameHasEnded || levelCompleted)
        {
            if (Input.GetKeyDown(KeyCode.R))
                RestartLevel();

            if (Input.GetKeyDown(KeyCode.M))
                GoToMainMenu();
        }
    }

    public void Completelevel()
    {
        if (levelCompleted) return;
        levelCompleted = true;

        if (completeRoot != null)
        {
            completeRoot.style.display = DisplayStyle.Flex;
            Debug.Log("Level Complete UI shown.");
            Time.timeScale = 0f;
        }
    }

    public void EndGame()
    {
        if (gameHasEnded || levelCompleted) return;
        gameHasEnded = true;

        if (gameOverRoot != null)
        {
            Debug.Log("Game Over UI shown.");
            Time.timeScale = 0f;
            gameOverRoot.style.display = DisplayStyle.Flex;
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting level...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
