﻿using System.Collections;
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
    private float jumpSpeed = 150;
    private float gravity = 9.82f;

    private int nrOfJumps = 1;
    private int maxNrOfJumps = 1;

    private bool isJumping = false;

    private Transform referenceTransform = null;

    private CharacterController controller = null;

    private InputController inputController;

    private Vector3 gravityVector;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        referenceTransform = GameObject.FindGameObjectWithTag("MovementReference").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            Jump();
        }
    }

    private void Jump()
    {
        gravityVector.y += jumpSpeed * Time.deltaTime;
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
