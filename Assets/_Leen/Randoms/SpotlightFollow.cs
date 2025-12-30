using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public Transform target; // the object to always light

    void Update()
    {
        if (target != null)
        {
            // rotate spotlight to face the target
            transform.LookAt(target);
        }
    }
}
