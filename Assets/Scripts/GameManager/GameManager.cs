using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scorePoints;
    int startScorePoints;
    public int lifePoints;
    int maxLifePoints;

    void Start()
    {
        scorePoints = 0;
        startScorePoints = scorePoints;
        lifePoints = 3;
        maxLifePoints = lifePoints;
    }

    void Update()
    {
        
    }

    public void GainScore()
    {
        scorePoints++;
    }

    public void LoseLife()
    {
        lifePoints--;
    }
}
