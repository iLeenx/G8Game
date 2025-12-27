using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WinChecker : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject startPanel;
    public GameObject solverPanel;
    public GameObject winPanel; // assign a panel with text/images in inspector
    public GameObject leavePanel;
    
    [Header("Audio")]
    public AudioSource audioSource; // assign an AudioSource
    public AudioClip winClip;       // assign a victory sound

    private CubeState cubeState;
    private string solvedState;
    private bool won = false;

    //public bool playerHasMoved = false;
    private bool ready = false;
    private bool playerMoved = false;

    // to show the solver button

    [Header("The hidden solver button UI")]
    public GameObject solverButton;

    [Header("Which keys unlock it?")]
    public KeyCode key1 = KeyCode.LeftShift;
    public KeyCode key2 = KeyCode.RightShift;
    public KeyCode key3 = KeyCode.LeftControl;
    public KeyCode key4 = KeyCode.RightControl;

    private bool unlocked = false;

    void Start()
    {
        Debug.Log($"player has moved =  / ready = {ready} / player mover = {playerMoved}");
        // {playerHasMoved}

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
        {
            winPanel.SetActive(false);
        }
        if (startPanel != null)
        {
            startPanel.SetActive(true);
        }
        if (solverPanel != null)
        {
            solverPanel.SetActive(true);
        }
        if (leavePanel != null)
        {
            leavePanel.SetActive(false);
        }
        if (audioSource != null)
        {
            audioSource.enabled = false;
        }

        Debug.Log("Current: " + cubeState.GetStateString());
        Debug.Log("Solved: " + solvedState);


        if (solverButton != null)
        {
            solverButton.SetActive(false);
        }

    }

    void Update()
    {
        // if already unlocked, stop checking
        if (unlocked) return;

        if (Input.GetKey(key1) && Input.GetKey(key2) && Input.GetKey(key3) && Input.GetKey(key4))
        {
            solverButton.SetActive(true);
            unlocked = true;
            Debug.Log("Solver unlocked by secret key combo!");
        }
    }

    public void ReadyCheck()
    {
        ready = true;
    }

    // call this after every move/rotation
    public void CheckWin()
    {
        //if (!playerHasMoved) return;

        //Debug.Log("CheckWin called");

        //Debug.Log("Current: " + cubeState.GetStateString());
        //Debug.Log("Solved: " + solvedState);

        //if (won || cubeState == null) return;

        //if (cubeState.GetStateString() == solvedState)
        //{


        //    won = true;
        //    Debug.Log("Cube Solved!");

        //    // show win panel
        //    if (winPanel != null)
        //        winPanel.SetActive(true);

        //    if (winText != null)
        //        winText.text = "You solved the cube!";

        //    // play audio
        //    if (audioSource != null && winClip != null)
        //    {
        //        audioSource.PlayOneShot(winClip);
        //    }
        //}

        if (startPanel != null && startPanel.activeSelf) return;

        if (!ready || !playerMoved) return; // ignore before first move
        if (won || cubeState == null) return;

        if (cubeState.GetStateString() == solvedState)
        {
            won = true;
            Debug.Log("Cube Solved!");

            if (winPanel != null)
            {
                winPanel.SetActive(true);
            }

            if (audioSource != null && audioSource.enabled == false)
            {
                audioSource.enabled = true;
            }

            if (audioSource != null && winClip != null)
            {
                audioSource.PlayOneShot(winClip);
            }

            //FindObjectOfType<LaserManager>().DisableLaser(0);
            //Object.FindFirstObjectByType<LaserManager>().DisableLaser(0);

            // Example for laser 0
            PuzzleStateManager.SolveLaser(0);

            // Optional: tell LaserManager to update
            LaserManager lm = Object.FindFirstObjectByType<LaserManager>();
            if (lm != null) lm.CheckAllLasers();

        }
    }

    public void PlayerMoved()
    {
        playerMoved = true;
    }

    public void CheckStateOfBool()
    {
        Debug.Log($"player has moved =  / ready = {ready} / player mover = {playerMoved}");
        //{playerHasMoved}
    }

    public void OnShufflePressed()
    {
        // enable all 6 cube faces
        PivotRotation[] faces = PivotRotation.FindObjectsByType<PivotRotation>(FindObjectsSortMode.None);
        foreach (PivotRotation face in faces)
        {
            face.canInteract = true;
        }
    }
}
