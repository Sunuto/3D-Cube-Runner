using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Score : MonoBehaviour
{
    public Transform player;

    private Label scoreLabel;
    private Label highScoreLabel;

    private float highScore = 0;
    private GameManager gameManager;
    private bool scoreHidden = false;

    private string highScoreKey;

    void Start()
    {
        // Level-specific key
        string sceneName = SceneManager.GetActiveScene().name;
        highScoreKey = "HighScore_" + sceneName;

        // Connect UI
        var root = GetComponent<UIDocument>().rootVisualElement;
        scoreLabel = root.Q<Label>("Score");
        highScoreLabel = root.Q<Label>("HighScore");

        // Load saved high score
        highScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        highScoreLabel.text = "High Score: " + highScore.ToString("0");

        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        // Press H to reset high score for this level
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerPrefs.DeleteKey(highScoreKey);
            highScore = 0;
            highScoreLabel.text = "High Score: 0";
            Debug.Log("High score reset for this level.");
        }

        // Hide score label if level is complete
        if (!scoreHidden && gameManager.LevelCompleted)
        {
            scoreLabel.style.display = DisplayStyle.None;
            scoreHidden = true;
        }

        // Stop if game ended or level completed
        if (gameManager.GameHasEnded || gameManager.LevelCompleted) return;

        // Score based on Z position
        float currentScore = player.position.z;
        scoreLabel.text = "Score: " + currentScore.ToString("0");

        // New high score?
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat(highScoreKey, highScore);
            PlayerPrefs.Save();
            highScoreLabel.text = "High Score: " + highScore.ToString("0");
        }
    }
}
