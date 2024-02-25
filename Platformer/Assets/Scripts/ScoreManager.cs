using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreTextStatistic;
    [SerializeField] private TextMeshProUGUI deadEnemyText;
    [SerializeField] private TextMeshProUGUI scoreTextStatisticDead;
    [SerializeField] private TextMeshProUGUI deadEnemyTextDead;
    [SerializeField] private int score = 0;
    [SerializeField] private int deadEnemy = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void AddScore(int value)
    {
        score += value; 
        UpdateScoreText();
        UpdateScoreTextStatistic();
    }

    public void AddDeadEnemy(int value)
    {
        deadEnemy += value;
        UpdateEnemyText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Монеты: " + score.ToString(); 
    }
    void UpdateScoreTextStatistic()
    {
        scoreTextStatistic.text = "Монеты: " + score.ToString();
    }
    void UpdateEnemyText()
    {
        deadEnemyText.text = "Убито врагов: " + deadEnemy.ToString();
    }
    public void UpdateTextAll()
    {
        scoreText.text = "Монеты: " + score.ToString();
        scoreTextStatistic.text = "Монеты: " + score.ToString();
        deadEnemyText.text = "Убито врагов: " + deadEnemy.ToString();
    }
    public void UpdateTextAllDead()
    {
        scoreTextStatisticDead.text = "Монеты: " + score.ToString();
        deadEnemyTextDead.text = "Убито врагов: " + deadEnemy.ToString();
    }

}
