using UnityEngine;
using UnityEngine.UI;

public class WinChecker : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winPanel; // assign a panel with text/images in inspector
    public Text winText;        // optional, assign a Text component
    [Header("Audio")]
    public AudioSource audioSource; // assign an AudioSource
    public AudioClip winClip;       // assign a victory sound

    private CubeState cubeState;
    private string solvedState;
    private bool won = false;

    public bool playerHasMoved = false;


    void Start()
    {
        cubeState = Object.FindFirstObjectByType<CubeState>();
        if (cubeState == null)
        {
            Debug.LogError("WinChecker: CubeState not found in scene!");
            return;
        }

        // store the solved cube state at start
        //solvedState = cubeState.GetStateString();
        solvedState = "UUUUUUUUURRRRRRRRRFFFFFFFFFDDDDDDDDDLLLLLLLLLBBBBBBBBB";


        // hide the win panel at start
        if (winPanel != null)
            winPanel.SetActive(false);
    }

    // call this after every move/rotation
    public void CheckWin()
    {
        if (!playerHasMoved) return;

        Debug.Log("CheckWin called");

        Debug.Log("Current: " + cubeState.GetStateString());
        Debug.Log("Solved: " + solvedState);

        if (won || cubeState == null) return;

        if (cubeState.GetStateString() == solvedState)
        {


            won = true;
            Debug.Log("Cube Solved!");

            // show win panel
            if (winPanel != null)
                winPanel.SetActive(true);

            if (winText != null)
                winText.text = "You solved the cube!";

            // play audio
            if (audioSource != null && winClip != null)
            {
                audioSource.PlayOneShot(winClip);
            }
        }
    }
}
