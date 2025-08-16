using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class HighScoreTable : MonoBehaviour
{
    private ScrollView scoreTable;
    private Button resetButton;
    private Button backButton;

    private string[] levelNames = { "lvl1", "lvl2", "lvl3", "lvl4", "lvl5", "lvl6" }; // Add more levels as needed

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        scoreTable = root.Q<ScrollView>("ScoreTable");
        resetButton = root.Q<Button>("ResetScoresButton");
        backButton = root.Q<Button>("BackButton");

        if (scoreTable == null || resetButton == null || backButton == null)
        {
            Debug.LogError("Missing UI elements!");
            return;
        }

        resetButton.clicked += ResetScores;
        backButton.clicked += () => SceneManager.LoadScene("MainMenu"); // change scene name if needed

        LoadHighScores();
    }

    void LoadHighScores()
    {
        scoreTable.Clear();

        for (int i = 0; i < levelNames.Length; i++)
        {
            string level = levelNames[i];
            string scoreKey = "HighScore_" + level;
            string nameKey = "HighScoreName_" + level;

            float score = PlayerPrefs.GetFloat(scoreKey, 0);
            string name = PlayerPrefs.GetString("name", "None");

            // Create row
            VisualElement row = new VisualElement();
            row.style.flexDirection = FlexDirection.Row;
            row.style.justifyContent = Justify.SpaceBetween;
            row.style.marginBottom = 4;
            row.style.paddingLeft = 10;
            row.style.paddingRight = 10;
            row.style.backgroundColor = (i % 2 == 0) ? new Color(0.92f, 0.92f, 0.92f) : Color.white;

            // Level column
            Label levelLabel = new Label(level);
            levelLabel.style.flexGrow = 1;

            // Score column
            Label scoreLabel = new Label(score.ToString("0"));
            scoreLabel.style.flexGrow = 1;
            scoreLabel.style.unityTextAlign = TextAnchor.MiddleCenter;

            // Name column
            Label nameLabel = new Label(name);
            nameLabel.style.flexGrow = 1;
            nameLabel.style.unityTextAlign = TextAnchor.MiddleRight;

            row.Add(nameLabel);
            row.Add(levelLabel);
            row.Add(scoreLabel);
            

            scoreTable.Add(row);
        }
    }

    void ResetScores()
    {
        foreach (string level in levelNames)
        {
            PlayerPrefs.DeleteKey("HighScore_" + level);
            PlayerPrefs.DeleteKey("HighScoreName_" + level);
        }

        PlayerPrefs.Save();
        LoadHighScores();
        Debug.Log("All scores reset.");
    }
}
