using UnityEngine;
using TMPro;

public class InteractionUI : MonoBehaviour
{
    public static InteractionUI Instance;

    public TextMeshProUGUI promptText;

    void Awake()
    {
        Instance = this;
        Hide();
    }

    public void Show(string message)
    {
        promptText.text = message;
        promptText.gameObject.SetActive(true);
    }

    public void Hide()
    {
        promptText.gameObject.SetActive(false);
    }
}
