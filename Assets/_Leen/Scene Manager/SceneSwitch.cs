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
        SceneManager.LoadScene("How to");
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
