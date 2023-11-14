using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float acceleration = 10;

    public float bounceDuration = 0.25f;
    public float peakHeight = 2f;
    private float initialSpeed;
    private float calculatedGravity;


    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, -10, 0);
        calculatedGravity = (2 * peakHeight) / Mathf.Pow((bounceDuration / 2), 2);
        Physics.gravity = new Vector3(0f, -calculatedGravity, 0f);
        //initialSpeed = calculatedGravity * (bounceDuration / 4);
        initialSpeed = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * peakHeight);
        rb.velocity = new Vector3(0f, initialSpeed, 0f);

    }

    void Update ()
    {
        float moveLeftRight = Input.GetAxis ("Horizontal");
        float moveForwardBack = Input.GetAxis ("Vertical");
        Vector3 xAcceleration = new Vector3(1, 0, 0) * moveLeftRight * Time.deltaTime * acceleration;
        // Vector3 yAcceleration = new Vector3(0, 1, 0) * acceleration;
        Vector3 zAceleration = new Vector3(0, 0, 1) * moveForwardBack * Time.deltaTime * acceleration;
        rb.velocity += xAcceleration + zAceleration;
    }

    void OnCollisionEnter(Collision collision)
    {
            // Calculate the new velocity after the bounce
            Vector3 newVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);

            // Set the y-component of the new velocity to the initial speed (maintaining constant bounce height)
            newVelocity.y = initialSpeed;

            // Apply the new velocity to the Rigidbody
            rb.velocity = newVelocity;
    }
}