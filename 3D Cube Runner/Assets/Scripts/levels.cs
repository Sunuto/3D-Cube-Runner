using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelSelectorUI : MonoBehaviour
{
    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        Button button1 = root.Q<Button>("1");
        if (button1 != null)
            button1.clicked += () => SceneManager.LoadScene("Lvl1");

        Button button2 = root.Q<Button>("2");
        if (button2 != null)
            button2.clicked += () => SceneManager.LoadScene("Lvl2");

        Button button3 = root.Q<Button>("3");
        if (button3 != null)
            button3.clicked += () => SceneManager.LoadScene("Lvl3");

        Button button4 = root.Q<Button>("4");
        if (button4 != null)
            button4.clicked += () => SceneManager.LoadScene("Lvl4");

        Button button5 = root.Q<Button>("5");
        if (button5 != null)
            button5.clicked += () => SceneManager.LoadScene("Lvl5");

        Button button6 = root.Q<Button>("6");
        if (button6 != null)
            button6.clicked += () => SceneManager.LoadScene("Lvl6");

        Button menuButton = root.Q<Button>("Menu");
        if (menuButton != null)
            menuButton.clicked += () => SceneManager.LoadScene("MainMenu");
    }
}
