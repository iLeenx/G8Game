using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class PuzzleGate : MonoBehaviour
{
    public string puzzleSceneName = "PuzzleScene";

    [Header("Optional UI Message")]
    public TextMeshProUGUI messageText;  // small text like “Need more pieces”
    public float messageTime = 2f;

    bool showing;
    public VoiceLine JohnLine;
    public VoiceLine DanLine;
    public VoiceManager voiceManager;

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
            StartCoroutine(PlaySequence());
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
    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(2f);

        // play first line
        voiceManager.PlayVoice(JohnLine);

        // wait for that audio to finish + 3 seconds
        yield return new WaitForSeconds(voiceManager.audioSource.clip.length + 3f);

        // play next line
        voiceManager.PlayVoice(DanLine);
    }
}
