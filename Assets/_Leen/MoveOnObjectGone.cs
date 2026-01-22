using UnityEngine;

public class MoveOnObjectGone : MonoBehaviour
{
    public GameObject objectToCheck;   // gameObject1
    public GameObject objectToMove;    // gameObject2

    public Vector3 targetPosition;     // x, y, z

    void Update()
    {
        // null or destroyed
        if (objectToCheck == null || !objectToCheck.activeInHierarchy)
        {
            objectToMove.transform.position = targetPosition;
        }
    }
}
