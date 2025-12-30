using UnityEngine;

public class RotateOn : MonoBehaviour
{
    public float rotationSpeed = 50f; // speed in degrees per second

    void Update()
    {
        // rotate on Y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
