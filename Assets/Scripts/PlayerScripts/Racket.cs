using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    InputController inputController;
    Transform target;
    Vector3 moveTargetDirection;
    Vector3 targetDefaultPosition;
    public float force;
    public float swingTime;
    public float aimSpeed;
    float timer;
    bool swing;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("TargetPlayer").transform;
        targetDefaultPosition = target.position;
    }
    void Awake()
    {
        inputController = new InputController();
        inputController.Player.Swing.performed += ctx => Swing();
    }

    private void FixedUpdate()
    {
        target.position = targetDefaultPosition;
        target.Translate(moveTargetDirection * aimSpeed * Time.deltaTime);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0.0f)
        {
            swing = false;
        }

        moveTargetDirection.x = Input.GetAxis("Mouse X");
        moveTargetDirection.z = Input.GetAxis("Mouse Y");
        if (moveTargetDirection.x > 1) moveTargetDirection.x = 1;
        if (moveTargetDirection.z > 1) moveTargetDirection.z = 1;
        if (moveTargetDirection.x < -1) moveTargetDirection.x = -1;
        if (moveTargetDirection.z < -1) moveTargetDirection.z = -1;
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Swing()
    {
        swing = true;
        timer = swingTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball") && swing) 
        {
            Vector3 direction = target.position - transform.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);
            other.gameObject.GetComponent<TennisBall>().numberOfBounces = 0;
        }
    }
}
