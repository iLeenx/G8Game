using UnityEngine;

public interface IInteractable
{
    void Interact();
}

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactLayer;

    PuzzlePiece currentPiece;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            PuzzlePiece piece = hit.collider.GetComponent<PuzzlePiece>();

            if (piece != null)
            {
                if (currentPiece != piece)
                {
                    ClearOutline();
                    currentPiece = piece;
                    currentPiece.ShowOutline();
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    piece.Interact();
                }

                return;
            }
        }

        // If ray hits nothing or something else
        ClearOutline();
    }

    void ClearOutline()
    {
        if (currentPiece != null)
        {
            currentPiece.HideOutline();
            currentPiece = null;
        }
    }
}
