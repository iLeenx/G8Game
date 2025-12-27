using UnityEngine;

public class CubePiece : MonoBehaviour
{
    public Vector3 correctRotation; // Set this in Inspector

    public bool IsCorrect()
    {
        Vector3 current = transform.eulerAngles;

        Debug.Log("Current Rotation: " + current + " | Correct Rotation: " + correctRotation);

        // Allow a little margin to avoid floats issues
        return Mathf.Abs(Mathf.DeltaAngle(current.x, correctRotation.x)) < 1f &&
               Mathf.Abs(Mathf.DeltaAngle(current.y, correctRotation.y)) < 1f &&
               Mathf.Abs(Mathf.DeltaAngle(current.z, correctRotation.z)) < 1f;

    }
}
