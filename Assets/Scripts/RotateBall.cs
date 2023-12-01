using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBall : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Rotate the ball around its up axis (Y-axis) over time
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
