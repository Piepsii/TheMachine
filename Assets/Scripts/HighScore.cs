using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text currentScoreText, highScoreText;
    public static int currentScore, highScore;

    void Start()
    {
        currentScore = 1;
        highScore = PlayerPrefs.GetInt("Highscore", 1);
        currentScoreText.text = currentScore.ToString();
        highScoreText.text = highScore.ToString();

    }

    void Update()
    {
        currentScore = WaveSpawner.currentWaveIndex;
        currentScoreText.text = currentScore.ToString();
    }
}
