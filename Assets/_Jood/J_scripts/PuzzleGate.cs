using UnityEngine;
using TMPro;
using System.Collections;

public class PuzzleGate : MonoBehaviour
{
    [Header("Door")]
    public Animator doorAnimator;
    public string openTriggerName = "Open";

    [Header("Trigger")]
    public Collider gateTrigger; // assign the trigger collider here

    [Header("Optional UI Message")]
    public TextMeshProUGUI messageText;
    public float messageTime = 2f;

    [Header("VO - Locked")]
    public VoiceLine lockedJohnLine;
    public VoiceLine lockedDanLine;

    [Header("VO - After Door Opens")]
    public VoiceLine openJohnLine;
    public VoiceLine openDanLine;

    public VoiceManager voiceManager;

    private bool showing;
    private bool hasOpened;
    private bool voPlaying;

    void Reset()
    {
        gateTrigger = GetComponent<Collider>();
        doorAnimator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (hasOpened) return;

        if (ThirdGameManager.Instance.HasAllPieces())
        {
            StartCoroutine(OpenDoorSequence());
        }
        else
        {
            int left = ThirdGameManager.Instance.totalPieces
                     - ThirdGameManager.Instance.collectedPieces;

            ShowMessage($"Find {left} more piece(s) first!");

            if (!voPlaying)
                StartCoroutine(PlayLockedSequence());
        }
    }

    IEnumerator OpenDoorSequence()
    {
        hasOpened = true;

        // Disable trigger immediately so nothing repeats
        if (gateTrigger != null)
            gateTrigger.enabled = false;

        // Play door animation
        if (doorAnimator != null)
            doorAnimator.SetTrigger(openTriggerName);

        // Small delay so animation clearly starts
        yield return new WaitForSeconds(0.3f);

        // Play VO after opening
        if (!voPlaying)
            yield return PlayOpenSequence();
    }

    IEnumerator PlayLockedSequence()
    {
        voPlaying = true;

        yield return new WaitForSeconds(0.4f);

        if (voiceManager != null && lockedDanLine != null)
            voiceManager.PlayVoice(lockedDanLine);

        yield return WaitForVoice();

        if (voiceManager != null && lockedJohnLine != null)
            voiceManager.PlayVoice(lockedJohnLine);

        yield return WaitForVoice();

        voPlaying = false;
    }

    IEnumerator PlayOpenSequence()
    {
        voPlaying = true;

        if (voiceManager != null && openDanLine != null)
            voiceManager.PlayVoice(openDanLine);

        yield return WaitForVoice();

        if (voiceManager != null && openJohnLine != null)
            voiceManager.PlayVoice(openJohnLine);

        yield return WaitForVoice();

        voPlaying = false;
    }

    IEnumerator WaitForVoice()
    {
        if (voiceManager == null || voiceManager.audioSource == null)
            yield break;

        while (voiceManager.audioSource.isPlaying)
            yield return null;

        yield return new WaitForSeconds(0.3f);
    }

    void ShowMessage(string msg)
    {
        if (messageText == null || showing) return;

        showing = true;
        messageText.gameObject.SetActive(true);
        messageText.text = msg;

        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), messageTime);
    }

    void HideMessage()
    {
        if (messageText != null)
            messageText.gameObject.SetActive(false);

        showing = false;
    }
}
