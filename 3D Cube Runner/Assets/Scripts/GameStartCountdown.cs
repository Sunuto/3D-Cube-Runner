using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class GameStartCountdown : MonoBehaviour
{
    private Label countdownLabel;
    public float countdownInterval = 1f; // time between each number
    public VisualElement root;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        countdownLabel = root.Q<Label>("CountdownText");
        countdownLabel.style.display = DisplayStyle.None; // hide initially
    }

    // Public method to trigger countdown externally (e.g. from Start button)
    public void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    private IEnumerator CountdownRoutine()
    {
        string[] countdownSequence = { "3", "2", "1", "Go!" };

        countdownLabel.style.display = DisplayStyle.Flex;

        foreach (string count in countdownSequence)
        {
            countdownLabel.text = count;
            yield return new WaitForSeconds(countdownInterval);
        }

        countdownLabel.style.display = DisplayStyle.None;

        // Start your game logic here
        StartGame();
    }

    private void StartGame()
    {
        Debug.Log("Game Started!");
        // Call your real game start method here
        // For example: GameManager.Instance.StartGame();
    }
}
