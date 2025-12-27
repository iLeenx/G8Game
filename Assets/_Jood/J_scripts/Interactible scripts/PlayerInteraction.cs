using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    // We’ll store the currently outlined object (any script that has ShowOutline/HideOutline)
    MonoBehaviour currentOutlined;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            // Interact with ANY interactable (PuzzlePiece, FlashlightPickup, etc.)
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            // Outline (optional): works if the object has Outline + methods
            MonoBehaviour outlineOwner =
                hit.collider.GetComponentInParent<PuzzlePiece>() as MonoBehaviour ??
                hit.collider.GetComponentInParent<FlashlightPickup>() as MonoBehaviour;

            HandleOutline(outlineOwner);

            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }

            return;
        }

        HandleOutline(null);
    }

    void HandleOutline(MonoBehaviour newOutlined)
    {
        if (currentOutlined == newOutlined) return;

        // turn off previous outline
        if (currentOutlined != null)
            currentOutlined.SendMessage("HideOutline", SendMessageOptions.DontRequireReceiver);

        currentOutlined = newOutlined;

        // turn on new outline
        if (currentOutlined != null)
            currentOutlined.SendMessage("ShowOutline", SendMessageOptions.DontRequireReceiver);
    }
}
