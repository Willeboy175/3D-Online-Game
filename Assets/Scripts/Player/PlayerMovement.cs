using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float sprintSpeed = 12f;
    public float maxVelocityChange = 10f;

    private Vector2 input;
    private Rigidbody rb;

    private bool sprinting;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector2(InputController.HorizontalAxis(), InputController.VerticalAxis());
        input.Normalize();

        if (Input.GetKey(SettingsController.keyBinds["sprint"]))
        {
            sprinting = true;
        }
        else
        {
            sprinting = false;
        }
    }

    void FixedUpdate()
    {
        if (input.magnitude > 0.5f)
        {
            rb.AddForce(CalculateMovement(sprinting ? sprintSpeed : walkSpeed), ForceMode.VelocityChange);
        }
        else
        {
            var velocity1 = rb.velocity;
            velocity1 = new Vector3(velocity1.x * 0.2f * Time.deltaTime, velocity1.y, velocity1.z * 0.2f * Time.deltaTime);
            rb.velocity = velocity1;
        }
    }

    Vector3 CalculateMovement(float speed)
    {
        //Sets target velocity and rotates it in the direction of the player
        Vector3 targetVelocity = new Vector3(input.x, 0, input.y);
        targetVelocity = transform.TransformDirection(targetVelocity);

        targetVelocity *= speed;

        Vector3 velocity = rb.velocity;

        if (input.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity - velocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

            return velocityChange;
        }
        else
        {
            return new Vector3();
        }
    }
}
