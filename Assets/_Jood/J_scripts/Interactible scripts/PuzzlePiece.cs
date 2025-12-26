using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        //GameManager.Instance.CollectPuzzlePiece();
        Destroy(gameObject);
    }
}
