using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseUIManager : MonoBehaviour
{
    private UIDocument pauseUIDocument;
    private VisualElement root;

    private Button restartButton;
    private Button menuButton;

    private bool isPaused = false;

    void Start()
    {
        pauseUIDocument = GetComponent<UIDocument>();
        root = pauseUIDocument.rootVisualElement;

        // Initially hide the pause UI
        root.style.display = DisplayStyle.None;

        // Query buttons from UI Document
        restartButton = root.Q<Button>("restart");
        menuButton = root.Q<Button>("menu");

        if (restartButton != null)
        {
            restartButton.clicked += RestartScene;
            Debug.Log(" Restart button found and event assigned.");
          
        }
        else
        {
            Debug.LogWarning(" Restart button not found!");
        }

        if (menuButton != null)
        {
            menuButton.clicked += GoToMainMenu;
            Debug.Log(" Menu button found and event assigned.");
        }
        else
        {
            Debug.LogWarning(" Menu button not found!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        // Temporary shortcut keys to test functions manually
        if (isPaused && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Manual Restart Shortcut Triggered");
            RestartScene();
        }

        if (isPaused && Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Manual Menu Shortcut Triggered");
            GoToMainMenu();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            root.style.display = DisplayStyle.Flex;  // Show pause UI
            Debug.Log("Game Paused.");
        }
        else
        {
            Time.timeScale = 1f;
            root.style.display = DisplayStyle.None;  // Hide pause UI
            Debug.Log("Game Resumed.");
        }
    }

    void RestartScene()
    {
        Debug.Log("Restarting scene...");
        Time.timeScale = 1f;
        FindFirstObjectByType<GameManager>().RestartLevel();
    }

    void GoToMainMenu()
    {
        Debug.Log(" Loading MainMenu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
