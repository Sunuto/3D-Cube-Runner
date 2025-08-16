using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class NameManagerUI : MonoBehaviour
{
    private TextField nicknameInput;
    private Button enterButton;
    private Label nameDisplay;
    private Label errorMsg;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nicknameInput = root.Q<TextField>("NicknameInput");
        enterButton = root.Q<Button>("EnterButton");
        nameDisplay = root.Q<Label>("NameDisplay");
        errorMsg = root.Q<Label>("ErrorMsg");

        string savedName = PlayerPrefs.GetString("name", "none");

        // Display last name in label
        nameDisplay.text = $"Last Name: {savedName}";

        // Fill the input field with previous name
        nicknameInput.value = savedName;

        // Hide error message initially
        if (errorMsg != null)
            errorMsg.style.display = DisplayStyle.None;

        // Handle Enter button click
        enterButton.clicked += RenamePlayer;

        // Hide error when user starts typing again
        nicknameInput.RegisterValueChangedCallback(evt =>
        {
            if (!string.IsNullOrEmpty(evt.newValue) && errorMsg != null)
                errorMsg.style.display = DisplayStyle.None;
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            RenamePlayer();
        }
    }

    void RenamePlayer()
    {
        string name = nicknameInput.text.Trim();

        if (string.IsNullOrEmpty(name))
        {
            if (errorMsg != null)
            {
                errorMsg.text = "Name cannot be empty!";
                errorMsg.style.display = DisplayStyle.Flex;
            }
            return;
        }

        // Clear error, save name, update label
        if (errorMsg != null)
            errorMsg.style.display = DisplayStyle.None;

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.Save();
        nameDisplay.text = $"Hello, {name}!";

        SceneManager.LoadScene("MainMenu");
    }
}
