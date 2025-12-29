using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PuzzleGate : MonoBehaviour
{
    public string puzzleSceneName = "PuzzleScene";

    [Header("Optional UI Message")]
    public TextMeshProUGUI messageText;  // small text like “Need more pieces”
    public float messageTime = 2f;

    bool showing;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (ThirdGameManager.Instance.HasAllPieces())
        {
            SceneManager.LoadScene(puzzleSceneName);
        }
        else
        {
            int left = ThirdGameManager.Instance.totalPieces - ThirdGameManager.Instance.collectedPieces;
            ShowMessage($"Find {left} more piece(s) first!");
        }
    }

    void ShowMessage(string msg)
    {
        if (messageText == null || showing) return;
        showing = true;
        messageText.gameObject.SetActive(true);
        messageText.text = msg;
        Invoke(nameof(HideMessage), messageTime);
    }

    void HideMessage()
    {
        if (messageText != null)
            messageText.gameObject.SetActive(false);
        showing = false;
    }
}
