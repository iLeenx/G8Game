using UnityEngine;
using UnityEngine.UI; // needed for Button

public class LookUIInteract : MonoBehaviour
{
    public float interactDistance = 5f;
    public LayerMask uiLayer; // create a layer for UI objects to filter raycasts

    void Update()
    {
        // Cast a ray from the center of the camera forward
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, uiLayer))
        {
            // Optional: show debug hit
            Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.purple);

            // Check if the object has a Button component
            Button button = hit.collider.GetComponent<Button>();
            if (button != null)
            {
                // If player presses "E", call button
                if (Input.GetKeyDown(KeyCode.E))
                {
                    button.onClick.Invoke();
                    Debug.Log("Pressed button: " + button.name);
                }
            }
        }
        else
        {
            // Not looking at UI
            Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.yellow);
        }
    }
}
