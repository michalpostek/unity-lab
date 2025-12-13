using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 5.0f;
    private const float JumpHeight = 1.5f;
    private const float Gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    [Header("Input Actions")]
    public InputActionReference moveAction; // expects Vector2
    public InputActionReference jumpAction; // expects Button

    private void Awake()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        if (jumpAction.action.triggered && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpHeight * -2.0f * Gravity);
        }

        velocity.y += Gravity * Time.deltaTime;


        Vector3 finalMove = (move * Speed) + (velocity.y * Vector3.up);
        controller.Move(finalMove * Time.deltaTime);
    }
}
