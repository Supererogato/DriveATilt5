using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public float acceleration = 1500f;
    public float maxSpeed = 20f;
    public float turnSpeed = 50f;
    public float drag = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearDamping = drag;
        rb.centerOfMass = new Vector3(0, -0.5f, 0); // helps with stability
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Forward movement
        

        
    }
}