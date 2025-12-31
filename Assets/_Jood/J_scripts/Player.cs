using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float gravity = -9.81f;

    private float moveHorizontal;
    private float moveForward;

    private CharacterController controller;
    private float verticalVelocity;

    // audio
    public float footstepDelay = 1f;  // adjust for speed
    private float footstepTimer = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // Input
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        RotateCamera();
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector3 move = transform.right * moveHorizontal + transform.forward * moveForward;
        move = move.normalized * moveSpeed;

        // Gravity handling
        if (controller.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f; // keeps player grounded
        }

        StepsSFX();

        verticalVelocity += gravity * Time.deltaTime;
        move.y = verticalVelocity;

        controller.Move(move * Time.deltaTime);
    }

    void RotateCamera()
    {
        // Horizontal rotation (player body)
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        // Vertical rotation (camera only)
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

    private void StepsSFX()
    {
        if (controller.isGrounded && moveHorizontal != 0 || moveForward != 0)
        {

            footstepTimer -= Time.fixedDeltaTime;

            if (footstepTimer <= 0f)
            {
                AudioManager.instance.playSFX("Step");
                footstepTimer = footstepDelay;
            }

            //AudioManager.instance.playSFX("Step");

            //if (!audioSource.isPlaying && isGrounded)
            //{
            //    audioSource.Play();
            //}

        }
    }
}
