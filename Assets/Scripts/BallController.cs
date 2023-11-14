using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float acceleration = 10;
    //public Transform ballCamera;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update ()
    {
        float moveLeftRight = Input.GetAxis ("Horizontal");
        float moveForwardBack = Input.GetAxis ("Vertical");
        Vector3 xAcceleration = new Vector3(1, 0, 0) * moveLeftRight * Time.deltaTime * acceleration;
        Vector3 zAceleration = new Vector3(0, 0, 1) * moveForwardBack * Time.deltaTime * acceleration;
        rb.velocity += xAcceleration + zAceleration;
    }
}