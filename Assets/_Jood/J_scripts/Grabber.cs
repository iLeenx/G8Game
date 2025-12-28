using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    [SerializeField] private float dragHeight = 0.25f;

    void Update()
    {
        // PICK
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();
            if (hit.collider == null) return;

            Debug.Log("Hit: " + hit.collider.name);

            // We only allow dragging objects tagged "drag"
            if (!hit.collider.CompareTag("drag")) return;

            // Always grab the ROOT object that has PuzzleSnapPiece
            var snap = hit.collider.GetComponentInParent<PuzzleSnapPiece>();
            if (snap == null)
            {
                Debug.LogError("Clicked something tagged drag but no PuzzleSnapPiece found in parent!");
                return;
            }

            if (snap.IsSnapped)
            {
                Debug.Log("This piece is already snapped, can't pick it.");
                return;
            }

            selectedObject = snap.gameObject;
            Cursor.visible = false;
            Debug.Log("Picked: " + selectedObject.name);
        }

        // DRAG
        if (selectedObject != null && Input.GetMouseButton(0))
        {
            Vector3 screenPos = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedObject.transform.position).z
            );

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            selectedObject.transform.position = new Vector3(worldPos.x, dragHeight, worldPos.z);

            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.Rotate(0f, 90f, 0f, Space.World);
            }
        }

        // DROP
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            Debug.Log("Dropped: " + selectedObject.name);

            var snap = selectedObject.GetComponent<PuzzleSnapPiece>();
            if (snap == null)
            {
                Debug.LogError("Dropped object has no PuzzleSnapPiece!");
            }
            else
            {
                snap.TrySnap();
            }

            selectedObject = null;
            Cursor.visible = true;
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        Vector3 dir = (worldMousePosFar - worldMousePosNear).normalized;
        float dist = Vector3.Distance(worldMousePosNear, worldMousePosFar);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, dir, out hit, dist);
        return hit;
    }
}
