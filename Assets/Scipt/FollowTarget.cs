using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

public class FollowTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playerTransform;
    // public float transformOffsetX;
    // public float transformOffsetY;
    // public float transformOffsetZ;

    private void Start()
    {
        //var Tilt5Offset = new Vector3(transformOffsetX, transformOffsetY, transformOffsetZ);
    }

    private void Update()
    {
        transform.position = playerTransform.position;
        transform.rotation = playerTransform.rotation;
    }
}
