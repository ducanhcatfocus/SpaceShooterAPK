using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreEndGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI hightScoreText;

    private void OnEnable()
    {
        int score = PlayerPrefs.GetInt("Score" + SceneManager.GetActiveScene().name, 0);
        int hScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);

      
        scoreText.text = "Score: " + score;
        if (score >= hScore)
        {
            hightScoreText.text = "New Record!";
        }
        else
            hightScoreText.text = "";
    }
}
