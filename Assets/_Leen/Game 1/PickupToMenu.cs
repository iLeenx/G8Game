using UnityEngine;
using UnityEngine.SceneManagement; // Needed to load scenes

public class PickupToMenu : MonoBehaviour
{
    public RubyPickup rubyPickup; // assign the RubyPickup component in Inspector

    public KeyCode interactKey = KeyCode.P; // key to press

    void Update()
    {
        // Check if the object is active in hierarchy
        if (gameObject.activeInHierarchy && rubyPickup != null && rubyPickup.canPickUp)
        {
            // Check if player presses the key
            if (Input.GetKeyDown(interactKey))
            {
                // Load Main Menu
                SceneManager.LoadScene("main menu");
            }
        }
    }
}
