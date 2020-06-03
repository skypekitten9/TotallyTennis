using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBall : MonoBehaviour
{
    public int numberOfBounces;

    private void Start()
    {
        numberOfBounces = 0;
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player" || collision.gameObject.tag != "Enemy")
        {
            numberOfBounces++;
        }
    }
}
