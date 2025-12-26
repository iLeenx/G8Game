using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScannerFlashEffect : MonoBehaviour
{
    [Header("References")]
    public Camera cam;                // Main camera
    public Light scannerLight;        // Spot Light (ScannerLight)
    public AudioSource audioSource;
    public AudioClip flashSfx;        

    [Header("Reveal Layer")]
    public string hiddenLayerName = "HiddenPieces";

    [Header("Timing")]
    public KeyCode flashKey = KeyCode.F;
    public float flashDuration = 3f;
    public float cooldown = 6f;

    private int hiddenLayer;
    private bool onCooldown;

    void Awake()
    {
        if (cam == null) cam = GetComponent<Camera>();
        hiddenLayer = LayerMask.NameToLayer(hiddenLayerName);
    }

    void Start()
    {
        // Ensure hidden pieces are invisible by default
        cam.cullingMask &= ~(1 << hiddenLayer);

        if (scannerLight != null) scannerLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(flashKey) && !onCooldown)
            StartCoroutine(FlashRoutine());
    }

    IEnumerator FlashRoutine()
    {
        onCooldown = true;

        // 1) Turn on light
        if (scannerLight != null) scannerLight.enabled = true;

        // 2) Play SFX
        audioSource.PlayOneShot(flashSfx);


        // 3) Reveal hidden pieces
        cam.cullingMask |= (1 << hiddenLayer);

        // Keep scan active
        yield return new WaitForSeconds(flashDuration);

        // 4) Hide pieces + turn off light
        cam.cullingMask &= ~(1 << hiddenLayer);
        if (scannerLight != null) scannerLight.enabled = false;

        // Cooldown
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
}
