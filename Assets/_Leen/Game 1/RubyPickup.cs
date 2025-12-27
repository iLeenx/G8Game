using UnityEngine;

public class RubyPickup : MonoBehaviour
{
    private bool canPickUp = false;
    public GameObject pickUpPanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
            canPickUp = true;
            pickUpPanel.SetActive(true);

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
            canPickUp = false;
            pickUpPanel.SetActive(true);
    }

    void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Ruby Stolen!");
            Destroy(gameObject); // or start cutscene
        }
    }
}
