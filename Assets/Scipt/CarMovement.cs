using UnityEngine;
using UnityEngine.InputSystem;

public class CarMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 50.0f;
    public Rigidbody rb;
    public InputActionReference wheelAction;
    public InputActionReference gasAction;

    private void Awake()
    {
        wheelAction.action.Enable();
        gasAction.action.Enable();
    }

    private void OnDestroy()
    {
        wheelAction.action.Disable();
        gasAction.action.Disable();
    }

    void FixedUpdate()
    {
        float s = wheelAction.action.ReadValue<float>(); // Steering input (-1 to 1)
        float g = gasAction.action.ReadValue<float>();   // Acceleration input (0 to 1)

        // Movement and rotation calculations
        float translation = Mathf.Lerp(0, 20, g) * speed * Time.fixedDeltaTime;
        float rotation = (g == 0) ? 0 : -Mathf.LerpUnclamped(50, -50, s) * rotationSpeed * Time.fixedDeltaTime;

        // Apply physics movement
        Vector3 moveDirection = transform.forward * translation;
        rb.MovePosition(rb.position + moveDirection);

        Quaternion turnRotation = Quaternion.Euler(0, rotation, 0);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}