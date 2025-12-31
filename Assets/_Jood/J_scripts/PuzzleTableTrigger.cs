using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTableTrigger : MonoBehaviour
{
    public GameObject promptPanel;
    public string puzzleSceneName = "ThirdGame";

    private bool playerInside;

    void Start()
    {
        promptPanel.SetActive(false);
    }

    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(puzzleSceneName);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            promptPanel.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            promptPanel.SetActive(false);
        }
    }
}
