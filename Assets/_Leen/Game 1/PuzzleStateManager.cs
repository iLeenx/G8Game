using UnityEngine;

public static class PuzzleStateManager
{
    // true = puzzle solved, false = not solved
    public static bool[] laserSolved = new bool[3] { false, false, false };

    public static void SolveLaser(int index)
    {
        if (index < 0 || index >= laserSolved.Length) return;
        laserSolved[index] = true;
        Debug.Log("Laser " + index + " marked as solved!");
    }

    public static bool IsLaserSolved(int index)
    {
        if (index < 0 || index >= laserSolved.Length) return false;
        return laserSolved[index];
    }

    public static bool AllLasersSolved()
    {
        foreach (bool solved in laserSolved)
        {
            if (!solved) return false;
        }
        return true;
    }
}
