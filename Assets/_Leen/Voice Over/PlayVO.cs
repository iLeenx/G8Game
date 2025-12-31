using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class VoiceLineData
{
    public VoiceLine line;      // the audio + subtitle
    public float delayAfter;    // how long to wait after this line finishes
}

public class PlayVO : MonoBehaviour
{
    public List<VoiceLineData> voiceLines = new List<VoiceLineData>();
    public VoiceManager voiceManager;

    private bool isPlaying = false;

    public bool DestroyAfterPlay = false;

    private void Start()
    {
        if (voiceManager == null)
        {
            voiceManager = FindFirstObjectByType<VoiceManager>();
        }
    }

    public void PlaySequence()
    {
        if (!isPlaying)
            StartCoroutine(PlaySequenceCoroutine());
    }

    private IEnumerator PlaySequenceCoroutine()
    {
        isPlaying = true;

        foreach (var data in voiceLines)
        {
            if (data.line == null) continue;

            // play the line
            voiceManager.PlayVoice(data.line);

            // wait for the clip length + extra delay
            float duration = (data.line.audio != null ? data.line.audio.length : 0f) + data.delayAfter;
            yield return new WaitForSeconds(duration);
        }

        isPlaying = false;

        if (DestroyAfterPlay)
        {
            yield return new WaitForSeconds(0.7f);
            Destroy(gameObject);
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPlaying)
            StartCoroutine(PlaySequenceCoroutine());
    }
}
