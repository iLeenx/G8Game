using UnityEngine;

public class RubyPickup : MonoBehaviour
{
    private bool canPickUp = false;
    public GameObject pickUpPanel;
    public GameObject rubyInHand = null;

    private void Start()
    {
        pickUpPanel.SetActive(false);
        rubyInHand.SetActive(false);
    }

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

            if (rubyInHand != null)
            {
                rubyInHand.SetActive(true);
            }

            Destroy(gameObject); // or start cutscene
        }
    }
}
