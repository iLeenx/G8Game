using UnityEngine;

public class p3solved : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("you solved 3!");

        // Example for laser 2
        PuzzleStateManager.SolveLaser(0);
        PuzzleStateManager.SolveLaser(1);
        PuzzleStateManager.SolveLaser(2);

        // Optional: tell LaserManager to update
        LaserManager lm = Object.FindFirstObjectByType<LaserManager>();
        if (lm != null)
        {
            lm.CheckAllLasers();
            lm.CheckLaserState();
        }
    }
}
