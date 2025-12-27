using UnityEngine;

public class FlashlightPickup : MonoBehaviour, IInteractable
{
    public Outline outline;
    public ScannerFlashEffect scanner; 

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
        scanner.isUnlocked = true;
        Debug.Log("Flashlight picked up");
        Destroy(gameObject);
    }
}
