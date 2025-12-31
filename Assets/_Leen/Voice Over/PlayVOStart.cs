using UnityEngine;
using System.Collections;

public class PlayVOStart : MonoBehaviour
{
    public VoiceLine introLine;
    public VoiceLine doorTutorialLine;

    public VoiceManager voiceManager;

    void Start()
    {
        StartCoroutine(PlaySequence());
    }

    IEnumerator PlaySequence()
    {
        yield return new WaitForSeconds(0.5f);

        // play first line
        voiceManager.PlayVoice(introLine);

        // wait for that audio to finish + 1 seconds
        yield return new WaitForSeconds(voiceManager.audioSource.clip.length + 1f);

        // play next line
        voiceManager.PlayVoice(doorTutorialLine);
    }
}
