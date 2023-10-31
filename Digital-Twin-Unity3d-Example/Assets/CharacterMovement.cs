using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Movement speed
    public float gravity = -9.81f; // Gravity force
    public float jumpHeight = 2.0f; // Jump height
    public Transform playerCamera; // Reference to the camera

    private CharacterController controller;
    private Vector3 playerVelocity;

    private bool isGrounded;

    private float mouseX; // Mouse X rotation
    private float mouseY; // Mouse Y rotation
    public float mouseSensitivity = 2.0f; // Mouse sensitivity
    public float maxLookUpAngle = 90f; // Maximum angle to look up
    public float maxLookDownAngle = -60f; // Maximum angle to look down

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Apply movement speed
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);

        // Apply gravity to make the character fall
        playerVelocity.y += gravity * Time.deltaTime;

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Mouse rotation
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        mouseY = Mathf.Clamp(mouseY, maxLookDownAngle, maxLookUpAngle); // Clamp the Y rotation

        // Rotate the character horizontally
        transform.rotation = Quaternion.Euler(0, mouseX, 0);

        // Rotate the camera vertically
        playerCamera.localRotation = Quaternion.Euler(mouseY, 0, 0);

        // Apply the final vertical movement
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
