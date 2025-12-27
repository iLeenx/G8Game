using UnityEngine;
using TMPro;


public class FlashlightPickup : MonoBehaviour, IInteractable
{
    public Outline outline;
    public ScannerFlashEffect scanner;
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
        scanner.isUnlocked = true;
        Debug.Log("Flashlight picked up");
        promptText.text = "Press F to turn it on";
        Destroy(gameObject);
    }
}
