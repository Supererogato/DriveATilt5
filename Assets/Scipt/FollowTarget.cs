using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    private Vector3 offset;
    private Quaternion rotationOffset;

    private void Start()
    {
        offset = transform.position - playerTransform.position;
        //rotationOffset = Quaternion.Inverse(playerTransform.rotation) * transform.rotation;
    }

    private void Update()
    {
        transform.position = playerTransform.position + offset;
        //transform.rotation = playerTransform.rotation * rotationOffset;
    }
}
