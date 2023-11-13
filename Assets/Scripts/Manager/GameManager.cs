using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    public static GameManager Instance => instance;

    public bool gameOver;

    private PanelController panelController;
    private TextMeshProUGUI scoreText;
    int score;

    public string levelUnlock = "LevelUnlock";

    private void Awake()
    {
       if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       else
            Destroy(gameObject);
  

    }

    private void Start()
    {
        
    }

    public void StartResolveGame()
    {
        StopCoroutine(nameof(StartResolveGame));
        StartCoroutine(WaitForResolveGame());
    }

    private IEnumerator WaitForResolveGame()
    {
        yield return new WaitForSeconds(2);
        ResolveGame();
    }

    public void ResolveGame()
    {
        if(gameOver == false)
        {
            WinGame();
        }
        else
        {
            LoseGame();
        }
    }

    public void WinGame()
    {
        UpdateHighScore();
        panelController.ActivateWinScreen();
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if(nextLevel > PlayerPrefs.GetInt(levelUnlock, 0))
        {
            PlayerPrefs.SetInt(levelUnlock, nextLevel);
        }
    }

    public void LoseGame()
    {
        UpdateHighScore();
        panelController.ActivateLoseScreen();
    }

    public void RegisterPanelController(PanelController panelController)
    {
        this.panelController = panelController;
    }

    public void RegisterScoreText(TextMeshProUGUI scoreText)
    {
        this.scoreText = scoreText;
    }


    public void UpdateScore(int addScore)
    {
        score += addScore;
        scoreText.text = "SCORE: " + score;
    }

    private void UpdateHighScore()
    {
        PlayerPrefs.SetInt("Score" + SceneManager.GetActiveScene().name, score);
        int highScore = PlayerPrefs.GetInt("HighScore" + SceneManager.GetActiveScene().name, 0);
        if(score > highScore)
        {
            PlayerPrefs.SetInt("HighScore" + SceneManager.GetActiveScene().name, score);

        }
        score = 0;
    }
     
}
