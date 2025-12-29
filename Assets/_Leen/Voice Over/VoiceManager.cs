using UnityEngine;
using TMPro;

public class VoiceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshProUGUI subtitleText;

    public void PlayVoice(VoiceLine line)
    {
        audioSource.clip = line.audio;
        audioSource.Play();
        subtitleText.text = line.subtitleText;
        Invoke(nameof(ClearText), audioSource.clip.length);
    }

    void ClearText() => subtitleText.text = "";
}
