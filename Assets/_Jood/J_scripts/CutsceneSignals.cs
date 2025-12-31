using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneSignals : MonoBehaviour
{
    public string nextSceneName = "Game 1";

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
