using UnityEngine;

public class RotateCube : MonoBehaviour
{
    public void RotateClockwise()
    {
        transform.Rotate(0, 0, 90);  // example on Y axis
    }

    public void RotateAntiClockwise()
    {
        transform.Rotate(0, 0, -90);
    }
}
