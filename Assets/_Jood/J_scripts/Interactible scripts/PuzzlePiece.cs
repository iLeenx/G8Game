using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IInteractable
{
    public Outline outline;

    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void ShowOutline()
    {
        outline.enabled = true;
    }

    public void HideOutline()
    {
        outline.enabled = false;
    }

    public void Interact()
    {
        Destroy(gameObject);
    }
}
