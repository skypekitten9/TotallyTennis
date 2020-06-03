using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int scorePoints;
    int startScorePoints;
    public int lifePoints;
    int maxLifePoints;
    GameObject gameCanvas, scoreText, heart1, heart2, heart3, gameOverPanel, gameOverCanvas, finalScoreText;
    bool gameOver;

    void Start()
    {
        scorePoints = 0;
        startScorePoints = scorePoints;
        lifePoints = 3;
        maxLifePoints = lifePoints;
        gameOver = false;

        gameCanvas = gameObject.transform.Find("GameCanvas").gameObject;
        scoreText = gameCanvas.transform.Find("ScoreInt").gameObject;
        heart1 = gameCanvas.transform.Find("Heart1").gameObject;
        heart2 = gameCanvas.transform.Find("Heart2").gameObject;
        heart3 = gameCanvas.transform.Find("Heart3").gameObject;

        gameOverPanel = gameObject.transform.Find("GameOverPanel").gameObject;
        gameOverCanvas = gameObject.transform.Find("GameOverCanvas").gameObject;
        finalScoreText = gameOverCanvas.transform.Find("FinalScoreInt").gameObject;

        gameOverPanel.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        
    }

    public void GainScore()
    {
        if(!gameOver)
        {
            scorePoints += 10;
            scoreText.GetComponent<Text>().text = scorePoints.ToString();
        }
    }

    public void LoseLife()
    {
        if(!gameOver)
        {
            if (lifePoints == 3)
            {
                heart3.SetActive(false);
            }
            else if (lifePoints == 2)
            {
                heart2.SetActive(false);
            }
            else
            {
                heart1.SetActive(false);
                gameOver = true;
                gameOverPanel.SetActive(true);
                gameOverCanvas.gameObject.SetActive(true);
                gameCanvas.gameObject.SetActive(false);
                finalScoreText.gameObject.GetComponent<Text>().text = scorePoints.ToString();
            }
            lifePoints--;
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
