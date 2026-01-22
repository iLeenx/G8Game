using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void _GoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }
    public void _GoPlay()
    {
        CutsceneOnce.ResetForNewGame();
        SceneManager.LoadScene("cutscene 2");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }
    public void _GoToCutScene2()
    {
        CutsceneOnce.ResetForNewGame();
        SceneManager.LoadScene("final cutscene 1");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void _BackPlay()
    {
        CutsceneOnce.ResetForNewGame();
        SceneManager.LoadScene("Game 1");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void _GoSettings()
    {
        SceneManager.LoadScene("Settings");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void _GoCredits()
    {
        SceneManager.LoadScene("Credits");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void _GoHowTo()
    {
        SceneManager.LoadScene("How To");
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void _GoGame1()
    {
        CutsceneOnce.ResetForNewGame();
        SceneManager.LoadScene("Game 1");

        Cursor.visible = true;
        Time.timeScale = 1f;
    }

}
