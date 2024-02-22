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

    private bool sprinting = false;
    private bool jumping = false;
    private bool grounded = false;

    private PlayerControls controls;
    private InputAction move;
    private InputAction sprint;
    private InputAction jump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Enable();
    }

    private void OnEnable()
    {
        move = controls.Player.Move;
        sprint = controls.Player.Sprint;
        jump = controls.Player.Jump;

        move.Enable();
        sprint.Enable();
        jump.Enable();

        sprint.started += OnSprint;
        sprint.canceled += OnSprint;
        jump.started += OnJump;
        jump.canceled += OnJump;
    }

    private void OnDisable()
    {
        move.Disable();
        sprint.Disable();
        jump.Disable();

        sprint.started -= OnSprint;
        sprint.canceled -= OnSprint;
        jump.started -= OnJump;
        jump.canceled -= OnJump;
    }

    private void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            sprinting = true;
            Debug.Log("Start sprinting");
        }

        if (context.canceled)
        {
            sprinting = false;
            Debug.Log("Stop sprinting");
        }
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumping = true;
            Debug.Log("Start jumping");
        }

        if (context.canceled)
        {
            jumping = false;
            Debug.Log("Stop jumping");
        }
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = move.ReadValue<Vector2>();
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
}
