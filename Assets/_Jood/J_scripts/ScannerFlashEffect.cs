using UnityEngine;

public class ScannerFlashEffect : MonoBehaviour
{
    [Header("References")]
    public Camera cam;                // Main camera
    public Light scannerLight;        // Spot Light (ScannerLight)
    public AudioSource audioSource;
    public AudioClip flashSfx;

    [Header("Reveal Layer")]
    public string hiddenLayerName = "HiddenPieces";

    [Header("Unlock")]
    public bool isUnlocked = false; // set true when flashlight is picked up

    private int hiddenLayer;
    private bool isScanning = false;

    void Awake()
    {
        if (cam == null) cam = GetComponent<Camera>();
        hiddenLayer = LayerMask.NameToLayer(hiddenLayerName);
    }

    void Start()
    {
        // Hidden by default
        cam.cullingMask &= ~(1 << hiddenLayer);

        if (scannerLight != null)
            scannerLight.enabled = false;
    }

    void Update()
    {
        if (!isUnlocked)
        {
            if (Input.GetKeyDown(KeyCode.F))
                Debug.Log("Scanner locked. Pick up the flashlight first.");
            return;
        }

        if (Input.GetKeyDown(KeyCode.F))
            ToggleScanner();
    }

    void ToggleScanner()
    {
        isScanning = !isScanning;

        if (isScanning)
        {
            // ON
            cam.cullingMask |= (1 << hiddenLayer);

            if (scannerLight != null)
                scannerLight.enabled = true;

            if (audioSource != null && flashSfx != null)
                audioSource.PlayOneShot(flashSfx);
        }
        else
        {
            // OFF
            cam.cullingMask &= ~(1 << hiddenLayer);

            if (scannerLight != null)
                scannerLight.enabled = false;
        }
    }
}
