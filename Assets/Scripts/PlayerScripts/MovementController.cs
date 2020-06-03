using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private float currentSpeed = 0f;
    private float speedSmoothVelocity = 0f;
    private float speedSmoothTime = 0.1f;
    private float jumpSpeed = 5;
    private float gravity = 9.82f;

    private int nrOfJumps = 1;
    private int maxNrOfJumps = 1;

    private bool isJumping = false;

    private Transform referenceTransform = null;

    private CharacterController controller = null;

    private InputController inputController;

    private Animator animator;

    private Vector3 gravityVector;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        referenceTransform = GameObject.FindGameObjectWithTag("MovementReference").transform;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && nrOfJumps > 0)
        {
            Jump();
        }

        if (controller.isGrounded)
        {
            nrOfJumps = 1;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("rightRunning", true);
            animator.SetBool("leftRunning", false);
            animator.SetBool("frontRunning", false);
        }
        else
        {
            animator.SetBool("leftRunning", true);
            animator.SetBool("rightRunning", false);
            animator.SetBool("frontRunning", false);
        }

        if (Input.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("frontRunning", true);
            animator.SetBool("rightRunning", false);
            animator.SetBool("leftRunning", false);
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            animator.SetBool("frontRunning", false);
            animator.SetBool("rightRunning", false);
            animator.SetBool("leftRunning", false);
        }
        
    }

    private void Jump()
    {
        nrOfJumps--;
        gravityVector.y += jumpSpeed;
        controller.Move(gravityVector * Time.deltaTime);
    }

    private void Move()
    {
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), (Input.GetAxisRaw("Vertical")));

        Vector3 forward = referenceTransform.forward;
        Vector3 right = referenceTransform.right;

        forward.Normalize();
        right.Normalize();

        Vector3 desiredMoveDirection = (forward * movementInput.y + right * movementInput.x).normalized;

        if (!controller.isGrounded)
        {
            gravityVector.y -= gravity * Time.deltaTime;
        }

        if (controller.isGrounded)
        {
            gravityVector.y = gravity * Time.deltaTime;
            nrOfJumps = maxNrOfJumps;
        }

        if (desiredMoveDirection != Vector3.zero)
        {
            //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), rotationSpeed);
        }

        float targetSpeed = movementSpeed * movementInput.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
        Mathf.Clamp(currentSpeed, 0, 6.5f);

        controller.Move(desiredMoveDirection * currentSpeed * Time.deltaTime);
        controller.Move(gravityVector * Time.deltaTime);
    }
}
