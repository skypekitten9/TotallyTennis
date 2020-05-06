using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWall : MonoBehaviour
{
    Transform target;
    public float force;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("TargetAI").transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector3 direction = target.position - transform.position;
            other.gameObject.GetComponent<Rigidbody>().velocity = direction.normalized * force + new Vector3(0, 6, 0);
        }
    }
}
