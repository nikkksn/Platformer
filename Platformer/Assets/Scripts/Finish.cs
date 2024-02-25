using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public string playerTag = "Player";
    public ScoreManager scoreManager;
    public GameObject statisticScore;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Time.timeScale = 0f;
            statisticScore.SetActive(true);
            scoreManager.UpdateTextAll();
        }
    }
}
