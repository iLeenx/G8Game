using UnityEngine;
using UnityEngine.Playables;

public class CutsceneOnce : MonoBehaviour
{
    public PlayableDirector director;

    // Runtime-only flag: resets when the app closes
    private static bool introPlayedThisSession = false;

    void Start()
    {
        if (introPlayedThisSession)
        {
            // Skip cleanly
            director.time = director.duration;
            director.Evaluate();
            return;
        }

        director.stopped += OnCutsceneFinished;
        director.Play();
    }

    void OnCutsceneFinished(PlayableDirector d)
    {
        introPlayedThisSession = true;
        director.stopped -= OnCutsceneFinished; // good practice
    }

    // Call this from Main Menu when starting a NEW game
    public static void ResetForNewGame()
    {
        introPlayedThisSession = false;
    }
}
