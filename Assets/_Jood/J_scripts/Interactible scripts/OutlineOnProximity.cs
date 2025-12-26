using UnityEngine;

[RequireComponent(typeof(Outline))]
public class OutlineOnProximity : MonoBehaviour
{
    private Outline outline;

    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false; // OFF by default
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            outline.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            outline.enabled = false;
    }
}
