using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{   
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 100f;
    public float brakeforce = 3000f;
    public WheelCollider frontLeftCollider, frontRightCollider, rearLeftCollider, rearRightCollider;
    public Transform frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;
    private Rigidbody rb;
    private MeshCollider mCollider;
    public InputActionReference wheelAction;
    public InputActionReference gasAction;
    public InputActionReference breakAction;
    public InputActionReference reverseAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.0f, -.5f, 0.0f);
        mCollider = GetComponent<MeshCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        UpdateWheels();
    }

    void HandleInput()
    {
        float steerInput = wheelAction.action.ReadValue<float>();
        float moveInput = gasAction.action.ReadValue<float>();
        float breakInput = breakAction.action.ReadValue<float>();
        float reverseInput = reverseAction.action.ReadValue<float>();
        moveInput = Mathf.Lerp(5, 0, moveInput);
        breakInput = Mathf.Lerp(5, 0, breakInput);
        
        if (reverseAction.action.ReadValue<float>() != 0)
        {
            rearLeftCollider.motorTorque = moveInput * -maxMotorTorque;
            rearRightCollider.motorTorque = moveInput * -maxMotorTorque;
        }
        else
        {
            rearLeftCollider.motorTorque = moveInput * maxMotorTorque;
            rearRightCollider.motorTorque = moveInput * maxMotorTorque;
        } 
        
        
        if (moveInput == 0)
        {
            rearLeftCollider.brakeTorque = breakInput * brakeforce;
            rearRightCollider.brakeTorque = breakInput * brakeforce;
        }
        else
        {
            rearLeftCollider.brakeTorque = 0;
            rearRightCollider.brakeTorque = 0;
        }
        float steering = steerInput * maxSteeringAngle;
        frontLeftCollider.steerAngle = steering;
        frontRightCollider.steerAngle = steering;
    }

    void UpdateWheels()
    {
        UpdateWheelPosition(frontRightCollider, frontRightWheel);
        UpdateWheelPosition(frontLeftCollider, frontLeftWheel);
        UpdateWheelPosition(rearRightCollider, rearRightWheel);
        UpdateWheelPosition(rearLeftCollider, rearLeftWheel);
    }

    void UpdateWheelPosition(WheelCollider wc, Transform wheel)
    {
        Vector3 pos;
        Quaternion rot;
        wc.GetWorldPose(out pos, out rot);
        wheel.position = pos;
        wheel.rotation = rot;
    }
}
