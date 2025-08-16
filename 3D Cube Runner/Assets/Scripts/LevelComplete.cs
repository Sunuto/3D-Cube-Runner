using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelComplete : MonoBehaviour
{
    private Button menuButton;

    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement root = uiDocument.rootVisualElement;

        menuButton = root.Q<Button>("Menu");

        if (menuButton != null)
        {
            menuButton.clicked += OnMenuButtonClicked;
        }
        else
        {
            Debug.LogWarning("Menu button not found!");
        }
    }

    private void OnDisable()
    {
        if (menuButton != null)
        {
            menuButton.clicked -= OnMenuButtonClicked;
        }
    }

    private void OnMenuButtonClicked()
    {
        Debug.Log("Menu button clicked!");
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N key pressed: Loading next level...");
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("M key pressed: Loading MainMenu...");
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void LoadNextLevel()
    {
        // Get current active scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= totalScenes)
        {
            Debug.Log("No more levels. Returning to MainMenu.");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
