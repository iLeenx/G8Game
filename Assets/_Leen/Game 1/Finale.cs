using UnityEngine;
using UnityEngine.SceneManagement;

public class Finale : MonoBehaviour
{
    public bool won = false;

    public GameObject FinaleCutSceneTrigger;
    public GameObject EscapePanel;

    private void Start()
    {
        FinaleCutSceneTrigger.SetActive(false);
    }

    public void WinningButtonActivation()
    {
        won = true;
    }

    private void Update()
    {
        if (won)
        {
            FinaleCutSceneTrigger.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && won)
        {
            SceneManager.LoadScene("final cutscene");
        }
    }

    public void ButtonActivation()
    {
        won = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        EscapePanel.SetActive(false);
    }
}
