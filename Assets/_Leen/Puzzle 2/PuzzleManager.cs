using UnityEngine;

public class PuzzleManager : MonoBehaviour
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
        // disable manager so it doesn't spam
        enabled = false;
    }
}
