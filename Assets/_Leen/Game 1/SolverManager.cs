using UnityEngine;

public class SolverManager : MonoBehaviour
{
    [Header("Which keys unlock it?")]
    public KeyCode key1 = KeyCode.LeftShift;
    public KeyCode key2 = KeyCode.RightShift;
    public KeyCode key3 = KeyCode.LeftControl;
    public KeyCode key4 = KeyCode.RightControl;

    private bool unlocked = false;

    public GameObject solverUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        solverUI.SetActive(false);
        unlocked = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if already unlocked, stop checking
        if (unlocked) return;

        if (Input.GetKey(key1) && Input.GetKey(key2) && Input.GetKey(key3) && Input.GetKey(key4))
        {
            solverUI.SetActive(true);
            unlocked = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Debug.Log("Solver unlocked by secret key combo!");
        }
    }

    public void SolvePuzzle0()
    {
        // If we reach here -> all are correct
        Debug.Log("WIN! Image Completed!");

        // Example for laser 0
        PuzzleStateManager.SolveLaser(0);

        // Optional: tell LaserManager to update
        LaserManager lm = Object.FindFirstObjectByType<LaserManager>();
        if (lm != null)
        {
            lm.CheckAllLasers();
            lm.CheckLaserState();
        }
    }
    public void SolvePuzzle1()
    {
        // If we reach here -> all are correct
        Debug.Log("WIN! Image Completed!");

        // Example for laser 1
        PuzzleStateManager.SolveLaser(1);

        // Optional: tell LaserManager to update
        LaserManager lm = Object.FindFirstObjectByType<LaserManager>();
        if (lm != null)
        {
            lm.CheckAllLasers();
            lm.CheckLaserState();
        }
    }
    public void SolvePuzzle2()
    {
        // If we reach here -> all are correct
        Debug.Log("WIN! Image Completed!");

        // Example for laser 2
        PuzzleStateManager.SolveLaser(2);

        // Optional: tell LaserManager to update
        LaserManager lm = Object.FindFirstObjectByType<LaserManager>();
        if (lm != null)
        {
            lm.CheckAllLasers();
            lm.CheckLaserState();
        }
    }
    public void CloseSolverUI()
    {
        solverUI.SetActive(false);
        unlocked = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
