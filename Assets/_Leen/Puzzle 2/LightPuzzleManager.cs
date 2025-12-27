using UnityEngine;

public class LightPuzzleManager : MonoBehaviour
{
    public CubePiece[] cubes; // drag the 9 cubes here

    void Update()
    {
        CheckPuzzle();
    }

    void CheckPuzzle()
    {
        foreach (var cube in cubes)
        {
            if (!cube.IsCorrect())
            {
                return; // if one is wrong, stop
            }
        }

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


        // disable manager so it doesn't spam
        enabled = false;
    }
}
