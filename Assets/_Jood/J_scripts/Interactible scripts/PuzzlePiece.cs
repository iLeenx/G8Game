using TMPro;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour, IInteractable
{
    public Outline outline;
    public TextMeshProUGUI promptText;

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
        promptText.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
