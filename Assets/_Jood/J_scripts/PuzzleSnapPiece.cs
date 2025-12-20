using UnityEngine;

public class PuzzleSnapPiece : MonoBehaviour
{
    [Header("Snap Settings")]
    public float snapDistance = 0.6f;   // XZ distance
    public float snappedY = 0.25f;      // match drag height
    public bool lockAfterSnap = true;

    [Header("Rotation Requirement")]
    public bool requireCorrectRotation = true;
    public float angleTolerance = 5f;   // degrees tolerance (good for float errors)

    private Vector3 correctPos;
    private Quaternion correctRot;

    public bool IsSnapped { get; private set; }

    void Start()
    {
        // Captures the solved layout rotation/position at play start
        correctPos = transform.position;
        correctRot = transform.rotation;
    }

    public void TrySnap()
    {
        if (IsSnapped) return;

        // 1) Check closeness in XZ (ignore height)
        Vector2 p = new Vector2(transform.position.x, transform.position.z);
        Vector2 t = new Vector2(correctPos.x, correctPos.z);
        float d = Vector2.Distance(p, t);

        if (d > snapDistance) return;

        // 2) Check rotation (Y axis) if required
        if (requireCorrectRotation)
        {
            float currentY = NormalizeAngle(transform.eulerAngles.y);
            float correctY = NormalizeAngle(correctRot.eulerAngles.y);

            float diff = Mathf.Abs(Mathf.DeltaAngle(currentY, correctY));
            if (diff > angleTolerance) return; // rotation wrong then don't snap
        }

        //  Snap (NOTE: do NOT "fix" rotation unless already correct)
        transform.position = new Vector3(correctPos.x, snappedY, correctPos.z);

        // Optional: If you want it to keep rotation exactly as-is (since it's already correct)
        // transform.rotation = transform.rotation;

        // Or you can set it to correctRot (safe now because we already verified it's correct)
        transform.rotation = correctRot;

        IsSnapped = true;

        if (lockAfterSnap)
        {
            foreach (var c in GetComponentsInChildren<Collider>())
                c.enabled = false;

            gameObject.tag = "Untagged";
            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }

    private float NormalizeAngle(float a)
    {
        a %= 360f;
        if (a < 0f) a += 360f;
        return a;
    }
}
