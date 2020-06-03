using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float bulletSpeed;
    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = 7f;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(-Vector3.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().LoseLife();
            Destroy(gameObject);
        }
    }
}
