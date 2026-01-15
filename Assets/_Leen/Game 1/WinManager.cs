using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public GameObject winningPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( winningPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
