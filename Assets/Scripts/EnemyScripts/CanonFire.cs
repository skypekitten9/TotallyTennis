using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonFire : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ammo;

    private float shootTimer;

    void Start()
    {
        shootTimer = Random.Range(1.5f, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;

        if (shootTimer <= 0)
        {
            Fire();
        }
    }

    public void Fire()
    {
        Instantiate(ammo);
        ammo.transform.position = gameObject.GetComponentInChildren<Transform>().position;
        shootTimer = Random.Range(1.5f, 3f);
    }
}
