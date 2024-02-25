using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : ScoreIncrease

{
    [SerializeField] private AudioSource m_AudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            m_AudioSource.Play();
            ScoreManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
