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
        scoreText.text = "������: " + score.ToString(); 
    }
    void UpdateScoreTextStatistic()
    {
        scoreTextStatistic.text = "������: " + score.ToString();
    }
    void UpdateEnemyText()
    {
        deadEnemyText.text = "����� ������: " + deadEnemy.ToString();
    }
    public void UpdateTextAll()
    {
        scoreText.text = "������: " + score.ToString();
        scoreTextStatistic.text = "������: " + score.ToString();
        deadEnemyText.text = "����� ������: " + deadEnemy.ToString();
    }
    public void UpdateTextAllDead()
    {
        scoreTextStatisticDead.text = "������: " + score.ToString();
        deadEnemyTextDead.text = "����� ������: " + deadEnemy.ToString();
    }

}
