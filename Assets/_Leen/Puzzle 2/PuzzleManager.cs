using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public CubePiece[] cubes; // Drag the 9 cubes here

    void Update()
    {
        bool allCorrect = true;

        foreach (CubePiece cube in cubes)
        {
            if (!cube.IsCorrect())
            {
                allCorrect = false;
                break;
            }
        }

        if (allCorrect)
        {
            Debug.Log("WIN! Puzzle Completed!");
            // You can call here animation, UI, sound, etc.
            enabled = false; // stop checking after win
        }
    }
}
