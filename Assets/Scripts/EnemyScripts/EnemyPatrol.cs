using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class EnemyPatrol : MonoBehaviour
{
    public Transform startTransform;
    private Vector3 rightPos;
    private Vector3 leftPos;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        startTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Patrol()
    {
        transform.position = Vector3.Lerp(rightPos, leftPos, (Mathf.Sin(speed * Time.deltaTime) + 1.0f) / 2.0f);
    }
}
