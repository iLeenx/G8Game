using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPuzzleTrigger : MonoBehaviour
{
    public GameObject puzzlePanel; // The "Press E to Start" canvas
    public string puzzleSceneName = "Main Menu";
    private bool playerInside = false;

    void Start()
    {
        puzzlePanel.SetActive(false); // Hide at start
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            puzzlePanel.SetActive(true);
            playerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger exited by: " + other.name);
        if (other.CompareTag("Player"))
        {
            puzzlePanel.SetActive(false);
            playerInside = false;
        }
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(puzzleSceneName);
        }
    }


}
