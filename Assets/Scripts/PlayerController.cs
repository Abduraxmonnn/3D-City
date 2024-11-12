using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50.0f;
    public float turnSpeed = 25.0f;
    public float groundRayDistance = 1.5f;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the car using Rigidbody
        Vector3 movement = transform.forward * speed * forwardInput * Time.deltaTime;
        rb.AddForce(movement * Time.deltaTime, ForceMode.Acceleration);
        rb.MovePosition(rb.position + movement);
        Quaternion turnRotation = Quaternion.Euler(0f, horizontalInput * turnSpeed * Time.deltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Check for ground below the car
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundRayDistance))
        {
            // Align the car with the ground normal
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, Time.deltaTime * turnSpeed));
        }
    }
}
