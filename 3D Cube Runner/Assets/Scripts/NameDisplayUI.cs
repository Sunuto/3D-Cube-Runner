using UnityEngine;
using UnityEngine.UIElements;

public class NameDisplayUI : MonoBehaviour
{
    private Label nameLabel;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        nameLabel = root.Q<Label>("NameDisplay");

        string playerName = PlayerPrefs.GetString("name", "Guest");
        nameLabel.text = $"Name: {playerName}";
    }
}
