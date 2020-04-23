using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public Vector3 direction;
    public Vector3 direction2;
    Vector3 currentDirection;
    public float speed;
    bool shootBall;
    float force;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(shootBall)
        {
            PhysicsHelper.ApplyForceToReachVelocity(rb, currentDirection * speed, force);
            shootBall = false;
        }

    }

    private InputController inputController;
    void Awake()
    {
        inputController = new InputController();
        inputController.Player.Jump.performed += ctx => Shoot();
        inputController.Player.Swing.performed += ctx => Shoot2();
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Shoot()
    {
        float p0 = rb.velocity.magnitude;
        float p = rb.mass * speed;
        float deltaP = p - p0;
        force = deltaP / Time.deltaTime;
        force = Mathf.Abs(force);
        shootBall = true;
        currentDirection = direction;
    }

    private void Shoot2()
    {
        float p0 = rb.velocity.magnitude;
        float p = rb.mass * speed;
        float deltaP = p - p0;
        force = deltaP / Time.deltaTime;
        force = Mathf.Abs(force);
        shootBall = true;
        currentDirection = direction2;
    }
}
