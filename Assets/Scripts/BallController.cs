using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float acceleration = 10;
    public float speed;

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
        initialSpeed = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * peakHeight);
        rb.velocity = new Vector3(0f, initialSpeed, 0f);

    }

    void Update ()
    {
        float horizontalInput = Input.GetAxis ("Horizontal");
        float verticalInput = Input.GetAxis ("Vertical");

        Vector3 newVelocity = rb.velocity;
        newVelocity.x = horizontalInput * speed;
        newVelocity.z = verticalInput * speed;
        rb.velocity = newVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
            // Calculate the new velocity after the bounce
            Vector3 newVelocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal);

            // Set the y-component of the new velocity to the initial speed (maintaining constant bounce height)
            newVelocity.y = initialSpeed;

            // Apply the new velocity to the Rigidbody
            rb.velocity = newVelocity;

        if (collision.gameObject.GetComponent<thisTile>() != null)
        {
                // Call the Glow method on the Tile script directly
                thisTile tileScript = collision.gameObject.GetComponent<thisTile>();

                if (tileScript != null)
                {
                    tileScript.Glow();
                }

        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<thisTile>() != null)
        {
            // Call the Glow method on the Tile script directly
            thisTile tileScript = collision.gameObject.GetComponent<thisTile>();

            if (tileScript != null)
            {
                tileScript.stopGlow();
            }
        }
    }
}