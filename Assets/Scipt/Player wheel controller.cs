
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWheelController : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 50.0f;
    public Rigidbody rigidbody;
    public InputActionReference wheelAction;
    public InputActionReference gasAction;

    private void Awake()
    {
        wheelAction.action.Enable();
        gasAction.action.Enable();
    }
    float _rotation = 0.0f;
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default, they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        var s = wheelAction.action.ReadValue<float>();
        var g = gasAction.action.ReadValue<float>();
        
        float translation = Mathf.Lerp(0,20,g) * speed;
        if (translation == 0)
        {
            _rotation = 0f;
        }
        else
        {
            _rotation = -Mathf.Lerp(50,-50,s) * rotationSpeed;
        }
        
        print(translation);
        
        

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        _rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
         transform.Translate(0, 0, translation);
        
        //move position
        // Rotate around our y-axis
        transform.Rotate(0, _rotation, 0);
    }
}
