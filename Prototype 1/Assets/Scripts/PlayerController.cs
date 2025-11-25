using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;
    private bool isGrounded = true;
    private Rigidbody rb;
    private float jumpForce = 5000.0f;
    private bool jumpPressed = false;
    private Vector3 startPosition = new Vector3(-0.32f, -0.13f, 5.39f);
    private Quaternion startRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move the vehicle forward
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // Moves the car forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

        //Detect if the car fell off the road
        if (transform.position.y < -3f)
        {
            Respawn();
        }
        //Detect jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = true;
        }
    }

    void Respawn()
    {
        if (rb != null)
        {
           rb.linearVelocity = Vector3.zero;
           rb.angularVelocity = Vector3.zero;
        }
        
        transform.position = startPosition;
        transform.rotation = startRotation;
    }

    void FixedUpdate()
    {
        //make car jump
        if (isGrounded && jumpPressed)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            jumpPressed = false;
        }
    }
}