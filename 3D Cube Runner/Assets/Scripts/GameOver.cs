using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameOverUI : MonoBehaviour
{
    private UIDocument uiDocument;
    private VisualElement root;

    private Button restartButton;
    private Button menuButton;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        root = uiDocument.rootVisualElement;

        restartButton = root.Q<Button>("Restart");
        menuButton = root.Q<Button>("Menu");

        if (restartButton != null)
        {
            restartButton.clicked += RestartLevel;
        }
        else
        {
            Debug.LogWarning("Restart button not found!");
        }

        if (menuButton != null)
        {
            menuButton.clicked += GoToMainMenu;
        }
        else
        {
            Debug.LogWarning("Menu button not found!");
        }

        root.style.display = DisplayStyle.None;
    }

    public void ShowGameOverUI()
    {
        root.style.display = DisplayStyle.Flex;
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting level...");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

     void GoToMainMenu()
    {
        Debug.Log("Going to Main Menu...");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
