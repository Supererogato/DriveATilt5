using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{   
    public float maxMotorTorque = 1500f;
    public float maxSteeringAngle = 100f;
    public float brakeforce = 3000f;
    public WheelCollider frontLeftCollider, frontRightCollider, rearLeftCollider, rearRightCollider;
    public Transform frontLeftWheel, frontRightWheel, rearLeftWheel, rearRightWheel;
    private Rigidbody rb;
    public string sceneNameToLoad;
    public InputActionReference resetAction;
    public InputActionReference wheelAction;
    public InputActionReference gasAction;
    public InputActionReference breakAction;
    public InputActionReference reverseAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0.0f, -.5f, 0.0f);
        wheelAction.action.Enable();
        gasAction.action.Enable();
        breakAction.action.Enable();
        reverseAction.action.Enable();
        resetAction.action.Enable();
        
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
        float resetInput = resetAction.action.ReadValue<float>();
        moveInput = Mathf.Lerp(0, 5, moveInput);
        breakInput = Mathf.Lerp(5, 0, breakInput);
       
        if (reverseInput != 0)
        {
            rearLeftCollider.motorTorque = moveInput * -maxMotorTorque;
            rearRightCollider.motorTorque = moveInput * -maxMotorTorque;
        }
        else
        {
            rearLeftCollider.motorTorque = moveInput * maxMotorTorque;
            rearRightCollider.motorTorque = moveInput * maxMotorTorque;
        } 
   
       rearLeftCollider.brakeTorque = breakInput * brakeforce; 
       rearRightCollider.brakeTorque = breakInput * brakeforce;
        
        float steering = steerInput * maxSteeringAngle;
        frontLeftCollider.steerAngle = steering;
        frontRightCollider.steerAngle = steering;

        if (resetInput == 1)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
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
