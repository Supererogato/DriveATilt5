using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    
    

    private void Start()
    {
        //rotationOffset = Quaternion.Inverse(playerTransform.rotation) * transform.rotation;
    }

    private void Update()
    {
        // transform.position = playerTransform.position;
        transform.position = playerTransform.forward;
        //transform.rotation = playerTransform.rotation * rotationOffset;
    }
}
