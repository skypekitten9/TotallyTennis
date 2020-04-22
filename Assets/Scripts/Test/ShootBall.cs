using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    public Vector3 direction;
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
            rb.AddForce(direction * force);
            shootBall = false;
        }

    }

    private InputController inputController;
    void Awake()
    {
        inputController = new InputController();
        inputController.Player.Jump.performed += ctx => Shoot();
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
        force = deltaP/ Time.deltaTime;
        shootBall = true;
    }
}
