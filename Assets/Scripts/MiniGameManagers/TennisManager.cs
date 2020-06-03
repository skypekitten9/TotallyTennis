using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class TennisManager : MonoBehaviour
{
    GameObject tennisBall;
    GameObject fieldReference;
    GameObject gameManager;
    public GameObject nextMiniGame;

    Transform tennisBallTransform;
    Transform fieldReferenceTransform;

    [SerializeField] float minigameDuration;
    float minigameDurationReset;

    void Start()
    {
        tennisBall = GameObject.Find("TennisBall");
        fieldReference = GameObject.Find("FieldReference");
        gameManager = GameObject.Find("GameManager");

        tennisBallTransform = tennisBall.GetComponent<Transform>();
        fieldReferenceTransform = fieldReference.GetComponent<Transform>();

        minigameDuration = 15f;
        minigameDurationReset = minigameDuration;
    }

    void Update()
    {
        minigameDuration -= Time.deltaTime;

        if (tennisBall.GetComponent<TennisBall>().numberOfBounces > 1)
        {
            if (tennisBallTransform.position.z > fieldReferenceTransform.position.z)
            {
                gameManager.GetComponent<GameManager>().GainScore();
            }

            else if (tennisBallTransform.position.z < fieldReferenceTransform.position.z)
            {
                gameManager.GetComponent<GameManager>().LoseLife();
                Destroy(gameObject);
            }
        }

        if(minigameDuration <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(nextMiniGame);
    }
}
