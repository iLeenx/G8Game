using UnityEngine;

public class MouseState : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("MouseState Awake: Cursor locked and hidden.");
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("MouseState Start: Cursor locked and hidden.");
    }
}
