using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutScene : MonoBehaviour
{
    //public string SceneToLoad;
    public void _GoMainMenu(string SceneToLoad)
    {
        SceneManager.LoadScene(SceneToLoad);

        Cursor.visible = true;
        Time.timeScale = 1f;
    }
}
