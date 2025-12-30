using UnityEngine;
using TMPro;

public class VoiceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public TextMeshProUGUI subtitleText;
    public GameObject subtitleDisplay;

    private void Start()
    {
        subtitleDisplay.SetActive(false);
    }

    public void PlayVoice(VoiceLine line)
    {
        subtitleDisplay.SetActive(true);
        Debug.Log("set active true");

        audioSource.clip = line.audio;
        audioSource.Play();
        subtitleText.text = line.subtitleText;
        Invoke(nameof(ClearText), audioSource.clip.length);
        
    }

    void ClearText()
    {
        subtitleText.text = "";
        subtitleDisplay.SetActive(false);
        Debug.Log("set active false");
    }
}
