using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement settings")]
    public float walkSpeed = 4f;
    public float sprintSpeed = 12f;
    public float maxVelocityChange = 10f;
    [Space]
    public float airControl = 0.5f;
    [Space]

    [Header("Jump settings")]
    public float jumpHeight = 5f;

    private Vector2 playerInput;
    private Rigidbody rb;

    private bool sprinting;
    private bool jumping;

    [SerializeField]
    private bool grounded = false;

    PlayerControls controls;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //playerInput = new Vector2(InputController.HorizontalAxis(), InputController.VerticalAxis());
        //playerInput.Normalize();

        sprinting = Input.GetKey(SettingsController.keyBinds["sprint"]);
        jumping = Input.GetKey(SettingsController.keyBinds["jump"]);
    }

    private void OnTriggerStay(Collider other)
    {
        grounded = true;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            if (jumping)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
            }
            if (playerInput.magnitude > 0.5f)
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
        else
        {
            if (playerInput.magnitude > 0.5f)
            {
                rb.AddForce(CalculateMovement(sprinting ? sprintSpeed*airControl : walkSpeed*airControl), ForceMode.VelocityChange);
            }
            else
            {
                var velocity1 = rb.velocity;
                velocity1 = new Vector3(velocity1.x * 0.2f * Time.deltaTime, velocity1.y, velocity1.z * 0.2f * Time.deltaTime);
                rb.velocity = velocity1;
            }
        }

        grounded = false;
    }

    Vector3 CalculateMovement(float speed)
    {
        //Sets target velocity and rotates it in the direction of the player
        Vector3 targetVelocity = new Vector3(playerInput.x, 0, playerInput.y);
        targetVelocity = transform.TransformDirection(targetVelocity);

        targetVelocity *= speed;

        Vector3 velocity = rb.velocity;

        if (playerInput.magnitude > 0.5f)
        {
            Vector3 velocityChange = targetVelocity - velocity;

            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);

            velocityChange.y += rb.velocity.y;

            return velocityChange;
        }
        else
        {
            return new Vector3();
        }
    }
    public void OnEnable()
    {
        if (controls == null)
        {
            controls = new PlayerControls();
            //controls.Player.SetCallbacks(PlayerControls.IPlayerActions);
        }
        controls.Player.Enable();
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {

    }
}
