using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFloorManager : MonoBehaviour
{
    Transform platformSpawnPos;

    List<GameObject> platforms;

    float platformTimer = 2f;
    float platformTimerReset;

    void Start()
    {
        platforms = new List<GameObject>();

        platformSpawnPos = GameObject.Find("PlatformSpawner").transform;

        platformTimerReset = platformTimer;
    }

    void Update()
    {
        platformTimer -= Time.deltaTime;

        if (platformTimer <= 0)
        {
            GameObject platform = GameObject.CreatePrimitive(PrimitiveType.Cube);
            platform.transform.position = platformSpawnPos.position;
            platforms.Add(platform);
            platformTimer = platformTimerReset;
        }

        foreach (GameObject platform in platforms)
        {
            
        }
    }
}
