using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeballManager : MonoBehaviour
{
    public GameObject nextMinigame;
    GameObject gameManager;

    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        duration = 15f;
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        duration -= Time.deltaTime;

        if (duration <= 0)
        {
            gameManager.GetComponent<GameManager>().GainScore();
            Destroy(gameObject);
            
        }
    }

    private void OnDestroy()
    {
        Instantiate(nextMinigame);
    }
}
