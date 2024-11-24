using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2f;
    public float gravity = -9.8f;
    public float jumpHeight = 1f;

    private float currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x; // Ruch w osi X
        moveDirection.z = input.y; // Ruch w osi Z
        controller.Move(transform.TransformDirection(moveDirection) * currentSpeed * Time.deltaTime);
    }

    public void SetCrouch(bool isCrouching)
    {
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
            controller.height = 1f;
        }
        else
        {
            currentSpeed = walkSpeed;
            controller.height = 2f;
        }
    }

    public void SetSprint(bool isSprinting)
    {
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
    }
}
