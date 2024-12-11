using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Audio")]
    public AudioSource walkAudio; // Reference to the Audio Source component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Ensure the AudioSource is assigned
        if (walkAudio == null)
        {
            walkAudio = GetComponent<AudioSource>();
        }

        // Initialize readyToJump as true at the start
        readyToJump = true;
    }

    private void Update()
    {
        // Check if the player is on the ground using a raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        Debug.Log("Grounded: " + grounded);  // Debugging ground status

        MyInput();
        SpeedControl();

        // Handle ground drag
        if (grounded)
        {
            rb.linearDamping = groundDrag;

            // Play walking audio if moving
            if (horizontalInput != 0 || verticalInput != 0)
            {
                if (!walkAudio.isPlaying)
                {
                    walkAudio.Play(); // Start playing the walking sound
                }
            }
            else
            {
                walkAudio.Stop(); // Stop walking sound when player stops
            }
        }
        else
        {
            rb.linearDamping = 0;

            // Stop the walking sound if not on the ground
            walkAudio.Stop();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Jump logic
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            Debug.Log("Jump key pressed");  // Debugging jump key input
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);  // Reset jump after cooldown
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply movement forces
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Limit velocity to moveSpeed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // Reset vertical velocity before jumping
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z); // Zero out the y velocity

        // Apply jump force
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        Debug.Log("Jump applied with force: " + jumpForce);  // Debugging jump force application
    }

    private void ResetJump()
    {
        readyToJump = true;
        Debug.Log("Ready to jump again!");  // Debugging reset jump
    }
}
