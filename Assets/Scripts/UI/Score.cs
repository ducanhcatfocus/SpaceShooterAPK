using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "SCORE: 0";

        GameManager.Instance.RegisterScoreText(scoreText);
    }

   
}
