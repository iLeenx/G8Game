using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleCompletionChecker : MonoBehaviour
{
    [Header("Auto-find pieces")]
    public PuzzleSnapPiece[] pieces;

    private int snappedCount = 0;
    private bool hasWon = false;

    void Awake()
    {
        // Auto-fill if you forget to assign
        if (pieces == null || pieces.Length == 0)
            pieces = Object.FindObjectsByType<PuzzleSnapPiece>(FindObjectsSortMode.None);
    }

    public void NotifyPieceSnapped()
    {
        if (hasWon) return;

        snappedCount++;

        if (snappedCount >= pieces.Length)
        {
            hasWon = true;

            // WIN
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            SceneManager.LoadScene("Game 1");
        }
    }
}
