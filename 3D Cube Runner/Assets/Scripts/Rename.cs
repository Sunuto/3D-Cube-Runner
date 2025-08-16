using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Rename : MonoBehaviour
{
    private TextField nicknameInput;
    private Button enterButton;
    private Label errorMsg;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nicknameInput = root.Q<TextField>("NicknameInput");
        enterButton = root.Q<Button>("EnterButton");
        errorMsg = root.Q<Label>("ErrorMsg");

        string savedName = PlayerPrefs.GetString("name", "Guest");
        nicknameInput.value = savedName;

        if (errorMsg != null)
            errorMsg.style.display = DisplayStyle.None;

        enterButton.clicked += RenamePlayer;

        nicknameInput.RegisterValueChangedCallback(evt =>
        {
            if (!string.IsNullOrEmpty(evt.newValue) && errorMsg != null)
            {
                errorMsg.style.display = DisplayStyle.None;
            }
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

        PlayerPrefs.SetString("name", name);
        PlayerPrefs.Save();

       
        SceneManager.LoadScene("MainMenu");
    }
}
