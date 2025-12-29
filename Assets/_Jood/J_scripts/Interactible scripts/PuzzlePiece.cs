using TMPro;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IInteractable
{
    public Outline outline;
    public TextMeshProUGUI promptText;

    public int pieceID;

    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void ShowOutline()
    {
        outline.enabled = true;
        promptText.text = "Press E to collect";
        promptText.gameObject.SetActive(true);
    }

    public void HideOutline()
    {
        outline.enabled = false;
        promptText.gameObject.SetActive(false);
    }

    public void Interact()
    {
        ThirdGameManager.Instance.CollectPiece();
        promptText.gameObject.SetActive(false);

        JigsawStateManager.piecesCollected[pieceID] = true;

        Destroy(gameObject);
    }
}
