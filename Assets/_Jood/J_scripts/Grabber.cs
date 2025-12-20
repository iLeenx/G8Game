using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;

    void Update()
    {
        // Pick
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = CastRay();
            if (hit.collider != null && hit.collider.CompareTag("drag"))
            {
                selectedObject = hit.collider.gameObject;
                Cursor.visible = false;
            }
        }

        // Drag while holding left click
        if (selectedObject != null && Input.GetMouseButton(0))
        {
            Vector3 position = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedObject.transform.position).z
            );

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, 0.25f, worldPosition.z);

            // Rotate with right click while dragging
            if (Input.GetMouseButtonDown(1))
            {
                selectedObject.transform.Rotate(0f, 90f, 0f, Space.World);
            }
        }

        // Drop when releasing left click
        if (Input.GetMouseButtonUp(0) && selectedObject != null)
        {
            Vector3 p = selectedObject.transform.position;
            selectedObject.transform.position = new Vector3(p.x, 0f, p.z);

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
