using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreIncrease : MonoBehaviour
{
    public string playerTag = "Damageable";
    public int scoreValue = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject); 
        }
    }
}
