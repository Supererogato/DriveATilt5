using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;

public class BreakInputActionBinding : MonoBehaviour
{
    public InputActionReference breakAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var device in InputSystem.devices)
        {
            if (device.name == "Logitech G920 Driving Force Racing Wheel for Xbox One")
            {
                foreach (var control in device.allControls)
                {
                    if (control.name == "z")
                    {
                        Debug.Log("Adding Binding");
                        breakAction.action.AddBinding(control);
                    }
                }

            }
        }
        breakAction.action.Enable();
    }
}
