using UnityEngine;
using System.Collections;

public class PuzzleShuffle : MonoBehaviour
{
    public Transform[] pieces;
    public Transform[] spawnPoints;

    IEnumerator Start()
    {
        // Wait 1 frame so PuzzleSnapAuto.Start() runs first
        yield return null;

        // Shuffle spawn point positions
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int r = Random.Range(i, spawnPoints.Length);
            (spawnPoints[i].position, spawnPoints[r].position) =
            (spawnPoints[r].position, spawnPoints[i].position);
        }

        // Move pieces + rotate randomly
        for (int i = 0; i < pieces.Length; i++)
        {
            // Move piece
            pieces[i].position = spawnPoints[i].position;

            // Rotate piece randomly (0, 90, 180, 270)
            float randomY = Random.Range(0, 4) * 90f;

            // Preserve X and Z rotation (important for flat pieces)
            Vector3 euler = pieces[i].rotation.eulerAngles;
            pieces[i].rotation = Quaternion.Euler(euler.x, randomY, euler.z);
        }
    }
}
