using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatforms : MonoBehaviour
{
    public Transform movingPlatform;
    public Transform position1;
    public Transform position2;
    public Vector3 newposition;
    public string currentState;
    public float smooth;
    public float resetTime;


    [SerializeField] float minigameDuration;
    float minigameDurationReset;
    public GameObject nextMiniGame;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTarget();
        minigameDuration = 15f;
        minigameDurationReset = minigameDuration;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        minigameDuration -= Time.deltaTime;
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newposition, smooth *  Time.deltaTime);

        if (minigameDuration <= 0)
        {
            Destroy(gameObject);
        }
    }
    void ChangeTarget()
    {
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newposition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 1";
            newposition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newposition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
    private void OnDestroy()
    {
        Instantiate(nextMiniGame);
    }
}
