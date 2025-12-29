using UnityEngine;

[CreateAssetMenu(fileName = "NewVoiceLine", menuName = "VoiceOver/Voice Line")]
public class VoiceLine : ScriptableObject
{
    public AudioClip audio;          // drag your .wav/.mp3 here
    [TextArea] public string subtitleText; // write subtitle here
}
